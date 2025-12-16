using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{   
    public static PlayerController Instance;
    [Header("-Player Component References-")]
    [SerializeField] public Rigidbody2D rb; //We make the Rigidbody not a public class as we need to keep it private, but since we need to see it in the editor, we make it a serializedfield.

    [SerializeField] Transform spriteTransformSize; //We establish a way to do sprite-scaling.

    [Header("-Player Settings-")]
    [SerializeField] float speed;

    bool facingLeft = true; //Condition that establishes which way the player-character starts facing.
    bool facingDown = true; //Condition that establishes which way the player-character looks up or down - it's down.

    public float horizontal; //Horizontal control, for use later.
    public float vertical; //Vertical control, for use later.
    
    public Animator animator; //We summon the animator.

    //public bool movementLocked; //This decides if the player can move. We toggle it when we pause the game.


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        animator.GetBool("flipBackside"); //We get the bool from the animator that tells it to change to back-side.
       
    }


    //A region is a "stylistic choice that allows you to lump together related code and give it a name."
    #region PLAYER_CONTROLS 
    public void Move(InputAction.CallbackContext context) //If the Input System gets input then we shall move.
    {
        horizontal = context.ReadValue<Vector2>().x; //We assign to the horizontal variable whether (context) we are moving left or right.
        vertical = context.ReadValue<Vector2>().y; //We assign to the vertical variable whether (context) we are moving up or down.

    }
    #endregion


    private void FixedUpdate()
    {
        //Guard Clause, to prevent any of the below code from running.
        /*
        if (movementLocked == true)
        {
            return; //If movement locked is true stops any code below from running
        }
        */
        //End guard clause.

        Vector2 movement = new Vector2(horizontal, vertical);
        movement = movement.normalized; 

        animator.SetFloat("Speed", movement.magnitude); //We set the the speed of the player.


        // We check that rigidbody's velocity is now controlled via a timer that checks if horizontal as well as vertical movement multiplies the speed of the rigidbody.
        rb.velocity = movement * speed * Time.deltaTime; //

        //Code to flip the character when walking
        if (horizontal < 0 && !facingLeft) //If we are moving in a negative direction on the X-axis and looking left, then...
        {
            FlipLeftRight();
        }

        else if (horizontal > 0 && facingLeft) //But if we are *instead* moving in a positive direction on the X-axis, and not looking left, then...
        {
            FlipLeftRight();
        }

        //Code to change animation if we are going upwards or downwards.
        
        if (vertical < 0 && facingDown)
        {
            //Time.timeScale = isPaused ? 0 : 1;
            
            FlipBackFront();
            animator.SetBool("flipBackside", false);
            Logging.Log($"Changed to FRONT.");
        }

        else if (vertical > 0 && !facingDown)
        {
            FlipBackFront();
            animator.SetBool("flipBackside", true);
            Logging.Log($"Changed to Back.");
        }
        //End UP-animation.
    }

    void FlipBackFront()
    {
        facingDown = !facingDown;

    }


    void FlipLeftRight() //This function controls the flipping of the character, making sure we don't do it unnecessarily, thereby saving some performance.
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingLeft = !facingLeft;
    }



    /*
    public void Pause()
    {
        movementLocked = true;
    }
    public void Resume()
    {
        movementLocked = false;
    }
    */

}
