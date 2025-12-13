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

    public float horizontal; //Horizontal control, for use later.
    public float vertical; //Vertical control, for use later.
    
    public Animator animator; //We summon the animator.

    public bool movementLocked; //This decides if the player can move. We toggle it when we pause the game.

    //A region is a "stylistic choice that allows you to lump together related code and give it a name."
    #region PLAYER_CONTROLS 
    public void Move(InputAction.CallbackContext context) //If the Input System gets input then we shall move.
    {
        horizontal = context.ReadValue<Vector2>().x; //We assign to the horizontal variable whether (context) we are moving left or right.
        vertical = context.ReadValue<Vector2>().y; //We assign to the vertical variable whether (context) we are moving up or down.

    }
    #endregion

    private void Awake()
    {
        Instance = this;
    }
    private void FixedUpdate()
    {
        //Guard Clause, to prevent any of the below code from running.
        if (movementLocked == true)
        {
            return; //If movement locked is true stops any code below from running
        }

        //End guard clause.

        Vector2 movement = new Vector2(horizontal, vertical);
        movement = movement.normalized; 

        animator.SetFloat("Speed", movement.magnitude); //We set the the speed of the player.
        //animator.SetBool("Flipbackside");         //We set the animation-bool if we are moving upwards.                                       


        // We check that rigidbody's velocity is now controlled via a timer that checks if horizontal as well as vertical movement multiplies the speed of the rigidbody.
        rb.velocity = movement * speed * Time.deltaTime; //

        //Code to flip the character when walking
        if (horizontal < 0 && !facingLeft) //If we are moving in a negative direction on the X-axis and looking left, then...
        {
            Flip();
        }

        else if (horizontal > 0 && facingLeft) //But if we are *instead* moving in a positive direction on the X-axis, and not looking left, then...
        {
            Flip();
        }
    }

    void Flip() //This function controls the flipping of the character, making sure we don't do it unnecessarily, thereby saving some performance.
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
