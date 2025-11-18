using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerShake : MonoBehaviour
{

    [SerializeField] Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("Touched");
    }
}
