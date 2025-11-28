using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.Events;

public class BookContentsrScript : MonoBehaviour
{
    //public static BookContentsrScript Instance; //We make this script instantiatable, since we will be spawning this when clicking books.

    [TextArea(10, 20)]
    [SerializeField] private string content; 

    [SerializeField] private TextMeshProUGUI leftSide; 
    [SerializeField] private TextMeshProUGUI rightSide; 

    [SerializeField] private TextMeshProUGUI leftPagination;
    [SerializeField] private TextMeshProUGUI rightPagination;
    public UnityEvent reachedEnd;
    int pageCount;

    [SerializeField] GameObject bookType; //Adding this field to sense what kind of book is being read, so we can have an if-statement or case, on how to do it.


/*
#if (UNITY_EDITOR)
    private void OnValidate() //To make sure our contents show up in the Inspector, we validate.
    {
        UpdatePagination(); //This is basically just a double-check to make sure the content has started loading.

        /*if (leftSide.text == content)
            return;
        
        SetupContent(); //Double-check to make sure it's all been set up correctly.
    }
#endif
*/

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
        /*
        if (leftSide.pageToDisplay < 1)

        {
            leftSide.pageToDisplay = 1;
            return;
        }

        if (leftSide.pageToDisplay -2 > 1)
            leftSide.pageToDisplay += 2;
        else
            leftSide.pageToDisplay = 1;
        */
        rightSide.pageToDisplay = leftSide.pageToDisplay + 1;

        UpdatePagination();

    }


    public void NextPage()
    {
        print("NextPage");
        leftSide.pageToDisplay += 2;
        /*
        if (rightSide.pageToDisplay <= rightSide.textInfo.pageCount)

        {
            return;

        }

        if (leftSide.pageToDisplay >= leftSide.textInfo.pageCount - 1)

        {
            leftSide.pageToDisplay = leftSide.textInfo.pageCount - 1;
            rightSide.pageToDisplay = leftSide.pageToDisplay + 1;
        }
        else
        {

            leftSide.pageToDisplay += 2;
            rightSide.pageToDisplay = leftSide.pageToDisplay + 1;
        }
        */
        rightSide.pageToDisplay = leftSide.pageToDisplay + 1;
        UpdatePagination();
        print(pageCount);

        //old way of doing the last part. Disabling temporarily.
        /*
        if (leftSide.pageToDisplay >= pageCount + 1)
        {
            reachedEnd.Invoke();
            leftSide.pageToDisplay = 1;
            rightSide.pageToDisplay = leftSide.pageToDisplay + 1;
            UpdatePagination();
        }
        */

        //--Experimental new way of telling if it's startbook or Readingbook
        if (leftSide.pageToDisplay >= pageCount + 1 && tag == "ReadingBook")
        {
            reachedEnd.Invoke();
            leftSide.pageToDisplay = 1;
            rightSide.pageToDisplay = leftSide.pageToDisplay + 1;
            UpdatePagination();
        }
        else if(leftSide.pageToDisplay >= pageCount + 1 && tag != "ReadingBook")
        {
            reachedEnd.Invoke();
        }


    }

}
        

        

