using UnityEngine;

//These enums are the items we can pick up. We can make as many as we want, and then use them in every other script.
public enum ItemID
{
    COCAINE,
    JOINT,
    PRINCESSI,
    TURNTABLE,
    //---------
    //Below are the reward-items.
    BREMENBOOK,
    SNOWBOOK,
    REDBOOK,
    FROGBOOK,
    //---------
    NONE //No Item as an ID
}

//These enums are the NPCs we can talk to. We can make as many as we want, and then use them in every other script.
public enum NpcID
{
    DWARF,
    BREMEN,
    FROGPRINCE,
    PRINCESSN,
    REDHOOD
}

//This is the Quest-Enums. They define types of objectives.
public enum ObjectiveType
{
    CollectItem,
    TalkNPC,
    GiveItem,
    Custom
}

public enum RewardType
{
    ItemID,
    CustomReward //This could be something like Cut-scene ID et c.
}