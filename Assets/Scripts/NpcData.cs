using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NpcData", menuName = "ScriptableObjects/NpcData", order = 1)] //We create a scriptable Object, and where we want to store it.


public class NpcData : ScriptableObject
{
    public string npcName = ""; //We can use any name for the NPC in the script.
    public NpcID nId; //Let's us assign one of the itemid's we have in the GameEnums script.
    public string description; //Sadly we can't use name, as that is an inherited property too, but this is just a name.
    public Sprite icon; //This is an actual sprite/texture that's going to be visible in the UI.
    public bool talkedTo = false;
    [Header("The Conversations the NPC has when loaded.")] //Tells us what conversations the NPC is meant to have.
    public List<Conversations> conversations = new List<Conversations>(); //This creates the list of conversations the NPC is supposed to have.

}

[System.Serializable] //This lets us create a custom class, struct, or field that can be saved. (serialised)
                      //It also makes it visible in the Unity-editor. 
public class Conversations
{
    [TextArea(3, 10)] //TextAreaAttribute(int minLines, int maxLines);
    public string dialogue;
    public bool waitForQuest;
    public Item givenItem;
}