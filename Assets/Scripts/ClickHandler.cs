using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private bool _hasToBeInRange; //We make sure that the object isn't clickable unless the player is close to it.

    [SerializeField] private UnityEvent _clicked;

    private BoxCollider2D _collider; //We make sure that we separate the clicks to only this clickable item, using it's Box-collider.

    [Header("-Player Component References-")]
    [Header("-Put MouseInputProvider script here")]
    //Remember to drag the player in the editor to get this in here...
    private MouseInputProvider _mouse;

    public bool _isInRange; //If the player is in range, then stuff will happen.

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();

    }
    private void Start()
    {
        _mouse = MouseInputProvider.Instance;
        _mouse.Clicked += MouseOnClicked;
    }
    private void MouseOnClicked()
    {
        bool rangeCheck = (_isInRange || !_hasToBeInRange); //If it is in range or does not have to be
        if (_collider.bounds.Contains((Vector3)_mouse.WorldPosition) && rangeCheck) //If the collider of the clickable object contains the mouse Worldposition and is in range,                                                                                                  //*or* if it's not required to be in range, then I...
        {
            _clicked.Invoke(); //... invoke the click.
            print(gameObject.name + " Clicked");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //The player enters the clickable zone.
    {
        PlayerController player = collision.GetComponent<PlayerController>(); //Finds the PlayerController, aka the Player, and put the value in there.
        if (player != null) //Then we check if it really is the player...
        {
            _isInRange = true; //And say that the Player is in range.
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //The player *EXITS* the clickable zone.
    {
        PlayerController player = collision.GetComponent<PlayerController>(); //Finds the PlayerController, aka the Player, and put the value in there.
        if (player != null) //Then we check if it really is the player...
        {
            _isInRange = false; //And say that the Player is *NOT* in range.
        }
    }

}