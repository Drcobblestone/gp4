using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D rBody;
    [SerializeField] GameObject player; //The player body
    //[SerializeField] Transform[] feetPoints; //The points at the bottom of each side of the player
    [SerializeField] float movementSpeed = 10f; //Movement speed

    [SerializeField] Transform flipTransform; //Flips components of player body

    float facing; //Used to determine direction the player is facing
    bool movementLocked = false; //Prevents the player from moving if true
    [SerializeField] Animator anime; //Gets the animator
    bool pickUp = false;

    private void Start()
    {
        //rBody = player.GetComponent<Rigidbody2D>(); //Gets the player gameobjects rigidbody, meaning that the below code will affect it
        //hit = 0;
    }
    private void Update()
    {
        GroundCheck();

        if (movementLocked)
        {
            return; //If movement locked is true stops any code below from running
        }
        if (anime.GetBool("Is Dead") == true) //If the player is dead, stops player from moving to the sides and imputs from working
        {
            rBody.velocity = new Vector2(0, rBody.velocity.y);
            return;
        }
        if (pickUp == true)
        {
            rBody.velocity = new Vector2(0, 0);
            return;
        }
        Vector2 moveDirection = Vector2.zero;
        //float jumpForce = 0;
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x += 1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x -= 1.0f;
        }
        //if (moveDirection.x != 0.0f && attacking == false) //Flips the player sprite if they are not in the attack animation
        {
            facing = moveDirection.x;
            flipTransform.localScale = new Vector3(facing, 1.0f, 1.0f);

        }


        //rBody.velocity = newVelocity;
        anime.SetBool("Walking", rBody.velocity.x != 0f);
    }
    private void FixedUpdate()
    {
        //anime.SetBool("Walking", rBody.velocity.x != 0f);
    }
    private void GroundCheck()
    {
        anime.SetBool("Is Grounded", rBody.IsTouchingLayers(LayerMask.GetMask("Ground")));
    }

    public void PickUpStart()
    {
        pickUp = true;
    }
    public void PickUpEnd()
    {
        pickUp = false;
    }
    public void Pause()
    {
        movementLocked = true;
    }
    public void Resume()
    {
        movementLocked = false;
    }
}