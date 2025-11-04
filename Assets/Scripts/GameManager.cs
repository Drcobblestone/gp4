using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] ItemDBData itemDB;
    [SerializeField] SceneData data;
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform[] entryPoints; //We create an array of entry-points within a scene.
    [SerializeField] SceneObject[] sceneObjects = new SceneObject[8];
    [SerializeField] List<DroppedItem> droppedItems = new List<DroppedItem>();
    public static GameManager current;
    // Start is called before the first frame update
    private void Awake()
    {
        current = this;
    }
    void Start()
    {
        for (int i = 0; i < sceneObjects.Length; i++)
        {
            SceneObject obj = sceneObjects[i];
            int index = i; //Neccesary, i is acting like a reference somehow... Unity-devs are mooks!
            if (obj == null)
            {
                continue;
            }
            obj.flagUpdated.AddListener((bool flag) => SetFlag(index, flag));
            bool startingFlag = data.sceneFlags[index];
            obj.StartWithFlag(startingFlag);

        }
        if (data.entryIndex == -1) //If we start the game, we will get this error, which will tell us that we have reset the entryindex.
        {
            Debug.LogError("Custom Error SceneEntry: Entry Index was not valid.");
            return;
        }
        //SPAWN IN ALL DROPPED ITEMS
        for (int i = 0; i < data.itemsToSpawn.Count; i++)
        {
            ItemToSpawn temp = data.itemsToSpawn[i]; //Neccesary, itemS is acting like a reference.
            DroppedItem droppedItem = SpawnItem(temp.itemData.id, temp.position);
            droppedItem.pickedUp.AddListener(delegate {
                this.data.itemsToSpawn.Remove(temp);
                print("Temp is: " + temp);
            }); //REMOVE FROM SCENE DATA IF ITEM GETS PICKED UP
        }

        playerTransform.position = entryPoints[data.entryIndex].position; //This will tell us which entrypoint the player is using, and where it is.
    }
    public void SetFlag(int index, bool flag){
        print(index);
        data.sceneFlags[index] = flag;
    }
    public void DropItem(DroppedItem droppedItem)
    {
        if (droppedItems.Contains(droppedItem))
        {
            return;
        }
        droppedItems.Add(droppedItem);
        data.DropItem(droppedItem);
        //REMOVE FROM SCENE DATA IF ITEM GETS PICKED UP
    }
    public DroppedItem SpawnItem(ItemID inventoryId, Vector2 dropPosition) //This spawns and returns the spawned item so we can use it in another function / script
    {
        Item item = itemDB.GetItem(inventoryId);
        DroppedItem droppedItem = Instantiate(item.prefab, dropPosition, Quaternion.identity).GetComponent<DroppedItem>();
        droppedItem.Initialize(item);
        return droppedItem;
    }
}
