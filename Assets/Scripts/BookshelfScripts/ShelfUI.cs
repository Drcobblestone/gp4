using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShelfUI : MonoBehaviour
{
    [Header("fgfgf.")]
    [SerializeField] GameObject uiBook; //Put the book-prefabs here.

    public void OnClicked()
    {
        uiBook.SetActive(true); //When we click the book, we activate the prefab in Singleton.
    }

}
