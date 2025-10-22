using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro; //We get the textmeshpro library.
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public string[] dialogue;
    private int index;
    ClickHandler clickHandler;
    public GameObject contButton;
    public float wordSpeed; //This lets us set how fast the words appear.

    [SerializeField] BoxCollider2D npcBoxcollider; //We make a field where we can get the NPC's box-collider.
    public bool resetDialougeAtEnd = false;
    public bool cantClickNPC = false; //We define a condition wherein you can't click the NPC 

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

    }


    IEnumerator Typing() //This is our typing-effect, where the letters come out bit by bit.
    {
        foreach (char letter  in dialogue[index].ToCharArray()) 
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
            
        }
        //
        contButton.SetActive(true);
        ButtonMiddleman button = contButton.GetComponent<ButtonMiddleman>();
        button.onClicked.RemoveAllListeners();
        button.onClicked.AddListener(NextLine);

        //We disable clicking on the NPC while the text is loading, and the Continue-button is active.
        if (dialoguePanel.activeInHierarchy)
        {
            cantClickNPC = true; //We make it so we can't click the NPC while the dialogue-panel is active.
            npcBoxcollider.enabled = false; //We do this by turning off the collider who detects the player.
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
        cantClickNPC = !resetDialougeAtEnd;
        npcBoxcollider.enabled = !cantClickNPC;
        dialoguePanel.SetActive(false); //We turn off our dialogue-panel.
    }


}
