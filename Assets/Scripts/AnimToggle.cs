using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimToggle : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    [SerializeField] string anim_1; //Standard animation, for instance if the object is a chest, it's closed.
    [SerializeField] string anim_2; //Second animation: if the object is a chest, this is an open chest.
    bool toggle = false;
    void Start()
    {
        anim = GetComponent<Animator>();    //We make sure the animator is the animator, so we can access functions.
    }
    public void ToggleAnim() //This helps change between the animations.
    {
        toggle = !toggle;
        string toggleAnim = toggle ? anim_1 : anim_2; //Ternary condition, the toggle now goes between animation 1 and animation 2.
        anim.Play(toggleAnim); //Then the animator plays whichever animation we have toggled it to.
    }
}
