using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.Events;

public class BookContentsrScript : MonoBehaviour
{
    [TextArea(10, 20)]
    [SerializeField] private string content; 

    [SerializeField] private TextMeshProUGUI leftSide; 
    [SerializeField] private TextMeshProUGUI rightSide; 

    [SerializeField] private TextMeshProUGUI leftPagination;
    [SerializeField] private TextMeshProUGUI rightPagination;
    public UnityEvent reachedEnd;
    int pageCount;

/*
#if (UNITY_EDITOR)
    private void OnValidate()
    {
        UpdatePagination();

        /*if (leftSide.text == content)
            return;
        
        SetupContent();
    }
#endif
*/

    private void Awake()
    {
        SetupContent();
        UpdatePagination();
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
        pageCount = leftSide.textInfo.pageCount; //Causes null-reference-exception.
    }

    public void PreviousPage()
    {
        print("PreviousPage");
        leftSide.pageToDisplay -= 2;
        leftSide.pageToDisplay = Mathf.Max(1, leftSide.pageToDisplay);
        /*if (leftSide.pageToDisplay < 1)

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
        /*if (rightSide.pageToDisplay <= rightSide.textInfo.pageCount)

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
        }*/
        rightSide.pageToDisplay = leftSide.pageToDisplay + 1;
        UpdatePagination();
        print(pageCount);
        if (leftSide.pageToDisplay >= pageCount + 1)
        {
            reachedEnd.Invoke();
        }

    }

}
        

        

