using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("-Player Component References-")]
    [SerializeField] Rigidbody2D rb; //We make the Rigidbody not a public class as we need to keep it private, but since we need to see it in the editor, we make it a serializedfield.

    [Header("-Player Settings-")]
    [SerializeField] float speed;

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
    }
}
