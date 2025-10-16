using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro; //We get the textmeshpro library.
using UnityEngine.InputSystem;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject contButton;
    public float wordSpeed; //This lets us set how fast the words appear.

    private void Awake()
    {
        //We'll get a reference to the text component.
        //Since we are using the base class type (TMP_Text), this component could be either the TextMeshPro or the TextMeshProUGUI component...
        //...but we want to only use the component designed to replace UI.Text & designed to work with the CanvasRenderer and Canvas system.
        //Not sure if this is the right thing we're summoning! xD

        dialogueText = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        dialogueText.text = ""; //This is needed because the length of dialogueText starts as 1.
    }


    public void OnClicked() //Clicking the character starts the dialogue-panels. | Small issue... this is UPDATE function in the tutorial... not sure if work.
    {
        if (dialoguePanel.activeInHierarchy)
        {
            zeroText();
        }
        else
        {
            dialoguePanel.SetActive(true); //...otherwise we activate the dialogue-panel in the hierarchy.
            StartCoroutine(Typing()); //... and start making words appear.
        }

        if (dialogueText.text == dialogue[index]) //If our dialogue-text is the same as our dialogue-index, then...
        {
            contButton.SetActive(true); //...activate the Continue-Button and let us move to the next dialogue.
        }
    }


    IEnumerator Typing() //This is our typing-effect, where the letters come out bit by bit.
    {
        foreach (char letter  in dialogue[index].ToCharArray()) 
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine() //To load the next part of the conversation.
    {
        contButton.SetActive(false); //We turn off the continue-button, since now we're going to load the next conversation.
        
        if(index < dialogue.Length -1) //If our dialogue-index is shorter than our dialogue-length
        {
            index++; //...the we start another conversation.
            dialogueText.text = ""; //We set the text to nothing, since we have a list of lines that's going to load instead.
            StartCoroutine(Typing()); //...and we'll start making the words appear again as well.
        }

        else //But If we don't want to load the next part of the conversation...
        { 
            zeroText() ; //We zero out our conversation.
        }

    }


    public void zeroText() //This is to reset our text-conversation.
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false); //We turn off our dialogue-panel.
    }


}
