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
    public bool[] convoFlags = new bool[8]; //This is an idea to keep track of what things the NPC has said, via flags.
}
