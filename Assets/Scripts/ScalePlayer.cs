using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls the players and other objects (whom has the script) size in the scene.

public class ScalePlayer : MonoBehaviour
{
    [Header("-Object to scale Component References-")]
    [SerializeField] GameObject objectToScale;

    //Change this to "vertice"? Aka point along the collider that you interpolate the distance to make the target-object smaller or bigger depending on where
    //the target-object is located in relation to the size-defining object.
    public Transform center; //Reference to what we are scaling in comparison to.
    public float ScaleMultiplierMin = -0.5f, ScalemultiplierMax = 0.5f; //The limits to how much we can scale.
    private float ScaleMultiplier; //How much the Player / object shall be scaled.
    
    private Vector2 initialScale;

    // Awake is called before Start, which is called before the first frame update
    void Awake()
    {
        initialScale = objectToScale.transform.localScale; //We determine the size of the thing to scale, before we scale it locally.
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(center.position, transform.position);
        float HowMuchToScale = Mathf.Clamp(ScaleMultiplier, ScaleMultiplierMin, ScalemultiplierMax);

        objectToScale.transform.localScale = initialScale * HowMuchToScale * distance;
    }
}
