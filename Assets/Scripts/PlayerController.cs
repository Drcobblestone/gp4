using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("-Player Component References-")]
    [SerializeField] Rigidbody2D rb; //We make the Rigidbody not a public class as we need to keep it private, but since we need to see it in the editor, we make it a serializedfield.
    //[SerializeField] private SpriteRenderer spriteRenderer; //We make the sprite renderer private.

    [Header("-Player Settings-")]
    [SerializeField] float speed;

    bool facingLeft = true; //Condition that establishes which way the player-character starts facing.

    private float horizontal; //Horizontal control, for use later.
    private float vertical; //Vertical control, for use later.
    
    public Animator animator; //We summon the animator.
    

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
        Vector2 movement = new Vector2(horizontal, vertical);
        movement = movement.normalized; 

        animator.SetFloat("Speed", movement.magnitude); //We set the the speed of the player. 

        // We check that rigidbody's velocity is now controlled via a timer that checks if horizontal as well as vertical movement multiplies the speed of the rigidbody.
        rb.velocity = movement * speed * Time.deltaTime; //

        //Code to flip the character when walking
        if (horizontal < 0 && !facingLeft) //If we are moving in a negative direction on the X-axis and looking left, then...
        {
            Flip();
            //gameObject.transform.localScale = new Vector3(1, 1, 1); //Then we make a new "scale" for our player-object. (we flip)
        }

        else if (horizontal > 0 && facingLeft) //But if we are *instead* moving in a positive direction on the X-axis, and not looking left, then...
        {
            Flip();
            //gameObject.transform.localScale = new Vector3(-1, 1, 1); //Then we make a new "scale" for our player-object, and flip the other way.
        }
    }

    void Flip() //This function controls the flipping of the character, making sure we don't do it unnecessarily, thereby saving some performance.
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingLeft = !facingLeft;
    }


}
