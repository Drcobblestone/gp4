using UnityEngine;

//This handles item-representation in the game-world.

[RequireComponent(typeof(Collider2D))] //We make sure only things with colliders can use the script.
public class DroppedItem : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] bool autoStart; //This controls if the item is initialized automatically when we start the game, or manually by a script.

    [SerializeField] float enabledPickupDelay = 3.0f; //How long it takes after initialization, before the Player can pick up the item.

    [Header("State")]
    public Item item;
    public bool pickedUp = false;

    private void Start()
    {
        if (autoStart && item != null)
        {
            Initialize(item);
        }
    }

    public void Initialize(Item item) //When we initialize the dropped item...
    {
        this.item = item;
        GameObject droppedItem = Instantiate(item.prefab, transform); //...we instantiate the dropped item and...
        droppedItem.transform.SetLocalPositionAndRotation(Vector2.zero, Quaternion.identity); //...set its position and rotation in the place.

        //StartCoroutine(EnablePickup(enabledPickupDelay)); //A small co-routine creates a delay before enabling the trigger.
    }
}
