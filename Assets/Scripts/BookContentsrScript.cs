using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BookContentsrScript : MonoBehaviour
{
    //public static BookContentsrScript Instance; //We make this script instantiatable, since we will be spawning this when clicking books.

    [TextArea(10, 20)]
    [SerializeField] private string content; 

    [SerializeField] private TextMeshProUGUI leftSide; 
    [SerializeField] private TextMeshProUGUI rightSide; 

    [SerializeField] private TextMeshProUGUI leftPagination;
    [SerializeField] private TextMeshProUGUI rightPagination;
    [Header("Drag Book-script onto here, if startbook, so we get to Library.")]
    public UnityEvent reachedEnd;
    int pageCount;

    [SerializeField] GameObject bookType; //Adding this field to sense what kind of book is being read, so we can have an if-statement or case, on how to do it.


    private void Awake()
    {
        SetupContent(); //We run our co-routine for setting up how the page is supposed to look and what it should use from the UI-canvas.
        UpdatePagination(); //We start updating our pages, so they will display text.
    }
    private void SetupContent()

    {
        leftSide.text = content;
        rightSide.text = content;
    }

    private void UpdatePagination()

    {
        leftPagination.text = leftSide.pageToDisplay.ToString();    
        rightPagination.text = rightSide.pageToDisplay.ToString();
        pageCount = leftSide.textInfo.pageCount; //
    }

    public void PreviousPage()
    {
        print("PreviousPage");
        leftSide.pageToDisplay -= 2;
        leftSide.pageToDisplay = Mathf.Max(1, leftSide.pageToDisplay);

        rightSide.pageToDisplay = leftSide.pageToDisplay + 1;

        UpdatePagination();

    }


    public void NextPage()
    {
        print("NextPage");
        leftSide.pageToDisplay += 2;
  
        rightSide.pageToDisplay = leftSide.pageToDisplay + 1;
        UpdatePagination();
        print(pageCount);



        //--How to tell if it's a startbook or Readingbook


            
        if (leftSide.pageToDisplay >= pageCount + 1 && tag == "ReadingBook")
        {
            reachedEnd.Invoke(); //When we reach the end, we summon the event-system and the reachedEnd event, which can invoke various things. (such as transitioning to a scene or turning off the book)
            leftSide.pageToDisplay = 1;
            rightSide.pageToDisplay = leftSide.pageToDisplay + 1;
            UpdatePagination();
            Logging.Log($"We reached the story-book end.");
        }

        else if(leftSide.pageToDisplay >= pageCount + 1 && tag == "StartBook")
        {
            reachedEnd.Invoke(); //When we invoke at the end of the startbook, we should have set it via the Editor to load the next Library-Inside, first in-game scene.
            Logging.Log($"We reached the start-book end.");
        }      
    }

    public void GoInGame(string startScene = "LibraryInside") //This brings us to the first game-play scene.
    {
        SceneManager.LoadSceneAsync(startScene); //Pressing play loads the Library Inside scene.
    }

}
        

        

