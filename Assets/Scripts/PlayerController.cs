using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rBody;
    [SerializeField] GameObject player; //The player body
    //[SerializeField] Transform[] feetPoints; //The points at the bottom of each side of the player
    [SerializeField] float movementSpeed = 10f; //Movement speed
    //[SerializeField] float jumpStrength = 5.0f; //Height of jump
    //[SerializeField] float knockBack = 5.0f; //Distance of knock back
    [SerializeField] float timeMovementLocked = 0.4f; //How long after damage before the player can move again
    [SerializeField] Transform flipTransform; //Flips components of player body
    //private int hit; //Used to detect damage
    float facing; //Used to determine direction the player is facing
    bool movementLocked = false; //Prevents the player from moving if true
    [SerializeField] Animator anime; //Gets the animator
    //private float jumper = 0.1f; //Used to reset the jumping bool in the animator
    //bool attacking = false; //Checks if the player is in the attack animation
    bool pickUp = false;
    //[SerializeField] float bossPushBack = -50f;
    //[SerializeField] float pushedAwayTime = 1f;

    private void Start()
    {
        rBody = player.GetComponent<Rigidbody2D>(); //Gets the player gameobjects rigidbody, meaning that the below code will affect it
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
        float jumpForce = 0;
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
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Transform foot in feetPoints) //Checks raycasts at feet to see if the player can jump
            {
                RaycastHit2D hit = Physics2D.Raycast(foot.position, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
                Debug.DrawRay(foot.position, Vector2.down * 0.1f, Color.magenta, 1.0f);
                if (hit.collider != null)
                {
                    jumpForce += jumpStrength;
                    anime.SetBool("Jumping", true);
                    StartCoroutine(Jumped(jumper));
                    break; //Stops jump force from being applied twice if both raycasts hit the ground
                }
            }
        }*/

        float appliedGravity = rBody.velocity.y;

        Vector2 newVelocity = moveDirection;
        newVelocity.x *= movementSpeed;
        newVelocity.y = appliedGravity + jumpForce;

        /*if (hit == 1) //Knock back effect triggers 
        {
            newVelocity.x = -facing * knockBack;
            newVelocity.y = appliedGravity + knockBack;
            hit = 0; //Stops the knock back effect from continuing after complete
            movementLocked = true; //Locks player movement during knock back
            PlayerAttack harm = FindAnyObjectByType<PlayerAttack>();
            harm.canAttack = false;
            StartCoroutine(Locked(timeMovementLocked)); //Starts coroutine to give the player controll back
        }*/

        rBody.velocity = newVelocity;
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
    /*public void PushBack()
    {
        rBody.velocity = new Vector2(bossPushBack, 10);
        movementLocked = true; //Locks player movement during knock back
        PlayerAttack harm = FindAnyObjectByType<PlayerAttack>();
        harm.canAttack = false;
        StartCoroutine(PushedBack(pushedAwayTime)); //Starts coroutine to give the player controll back
    }
    public void KnockBack()
    {
        hit = 1; //Triggers knock back effect above
    }
    public void Attacking()
    {
        attacking = true;
    }
    public void NotAttacking()
    {
        attacking = false;
    }
    */
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
    private IEnumerator Locked(float timeMovementLocked) //Re enables movement after a set time
    {
        yield return new WaitForSeconds(timeMovementLocked);
        movementLocked = false;
        //PlayerAttack harm = FindAnyObjectByType<PlayerAttack>();
        //harm.canAttack = true;
    }
    /*private IEnumerator Jumped(float jumper) //Resets the jumping bool in the animator
    {
        yield return new WaitForSeconds(jumper);
        anime.SetBool("Jumping", false);
    }
    private IEnumerator PushedBack(float pushedAwayTime)
    {
        yield return new WaitForSeconds(pushedAwayTime);
        movementLocked = false;
        PlayerAttack harm = FindAnyObjectByType<PlayerAttack>();
        harm.canAttack = true;
    }*/
}