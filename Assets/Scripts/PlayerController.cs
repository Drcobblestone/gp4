using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    
    public Animator animator;
    
    /*
    #region CHANGING_RIGIDBODY
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    //Let the Rigidbody take control and detect collisions
    void EnableRagdoll(Rigidbody2D rb)
    {
        rb.isKinematic = false;
        rb.coll
    }

    //Let animation take control and ignore collisions.
    void DisableRagDoll() 
    { 
        rb.isKinematic = true; 

    }

    #endregion
    */

    //First we'll disable gravity of the rigidbody, since we don't need it.
    /* void DisableGravity(Rigidbody2D rb)
     {
         rb.useGravity = false;
     }*/


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

        animator.SetFloat("Speed", movement.magnitude); //vilken behöver jag använda horizontal, vertical skulle behöva vara namnet för rörelsen 
       // animator.SetFloat("Speedver", Mathf.Abs(vertical));



        /*rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); //We set the players rigidbody velocity on the x-axis as the speed.
        rb.velocity = new Vector2(vertical * speed, rb.velocity.x); */ //We set the players rigidbody velocity on the y-axis as the speed.

        // We check that rigidbody's velocity is now controlled via a timer that checks if horizontal as well as vertical movement multiplies the speed of the rigidbody.
        rb.velocity = movement * speed * Time.deltaTime; //
    }
}
