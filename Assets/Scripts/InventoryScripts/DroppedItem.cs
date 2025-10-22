using System.Collections;
using UnityEngine;
using UnityEngine.Events;

//This handles item-representation in the game-world.

[RequireComponent(typeof(Collider2D))] //We make sure only things with colliders can use the script.
public class DroppedItem : MonoBehaviour
{

    public UnityEvent pickedUp;
    [Header("Settings")]
    [SerializeField] bool autoStart; //This controls if the item is initialized automatically when we start the game, or manually by a script.

    [SerializeField] float enabledPickupDelay = 1.0f; //How long it takes after initialization, before the Player can pick up the item.

    [Header("State")]
    public Item item;
    //public bool pickedUp = false;
    public bool canBePickedUp = true;
    
    public Vector3 _initialPos = Vector3.zero; //We try to make a value for where the item is first located.

    private void Awake()
    {
        Drop();
        /*if (autoStart && item != null)
        {
            Initialize(item);
        }*/

    }

    private void Start()
    {
        _initialPos = transform.position; //Save initial position of the item? I hope.
    }

    public void Initialize(Item item) //When we initialize the dropped item...
    {
        //this.item = item;
        //Drop();
        //GameObject droppedItem = Instantiate(item.prefab, transform); //...we instantiate the dropped item and...
        //droppedItem.transform.SetLocalPositionAndRotation(Vector2.zero, Quaternion.identity); //...set its position and rotation in the place.

    }
    public void PickUp()
    {
        pickedUp.Invoke();
        Destroy(gameObject);
    }
    public void Drop()
    {
        StartCoroutine(PickupDelay()); //A small co-routine creates a delay before enabling the trigger.
    }

    IEnumerator PickupDelay()
    {
        canBePickedUp = false;
        yield return new WaitForSeconds(enabledPickupDelay);
        canBePickedUp = true;
    }
}
