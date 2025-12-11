using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls the players and other objects (whom has the script) size in the scene.

public class ScalePlayer : MonoBehaviour
{
    [Header("-Object to scale Component References-")]
    [SerializeField] Transform playerTransform;

    public Transform topScreen;
    public Transform botScreen;

    public Vector2 topScreenScale;
    public Vector2 botScreenScale;

    float maxDist; //Distance from topScreen to botScreen, max distance scaling can happen

    private void Start()
    {
       Vector2 posA = topScreen.position;
       posA.x = 0; //We remove scaling based on X-position, since that looks strange.
       Vector2 posB = botScreen.position;
       posB.x = 0;
       maxDist = Vector2.Distance(posA, posB);
   }

   private void LateUpdate()
   {   

       Vector2 posA = topScreen.position;
       posA.x = 0;
       Vector2 posB = playerTransform.position;
       posB.x = 0;

       float distance = Vector2.Distance(posA, posB); //We check the distance first.
       Vector2 newScale = Vector2.Lerp(topScreenScale, botScreenScale, distance / maxDist);
       
       Vector2 scaleSign = playerTransform.localScale;
       scaleSign.x = Mathf.Sign(scaleSign.x);
       scaleSign.y = Mathf.Sign(scaleSign.y);
       playerTransform.localScale = (scaleSign * newScale); //We scale the player/object by using the sca                                                                         
       Logging.Log($"The player was scaled"); //We check that the scaling was done.
       
    }
}
