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
    public float ScaleMultiplierMin, ScalemultiplierMax; //The limits to how much we can scale.
    public float ScaleMultiplier; //How much the Player / object shall be scaled.

    private Vector2 initialScale; //The initial size.
    private Vector2 newScale; //The ever-changing new size of the player/object.

    // Awake is called before Start, which is called before the first frame update
    void Awake()
    {
        initialScale = objectToScale.transform.localScale; //We determine the size of the thing to scale, before we scale it locally.
    }

    // FixedUpdate is executed based on the Fixed Timestep (by default 50 times per second)
    //void FixedUpdate(Time.fixedDeltaTime = 1/24)
    private void LateUpdate()
    {
        float distance = Vector2.Distance(center.position, transform.position); //We check the distance first.
        float HowMuchToScale = Mathf.Clamp(ScaleMultiplier, ScaleMultiplierMin, ScalemultiplierMax);

        objectToScale.transform.localScale = initialScale * distance * HowMuchToScale; //We scale the player/objectToScale by using the initialScale and changing it
                                                                                         //depending on the distance to the scale-changer-object.

        Logging.Log($"The player was scaled"); //We check that the scaling was done.
    }
}
