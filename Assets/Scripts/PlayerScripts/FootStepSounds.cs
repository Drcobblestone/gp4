using UnityEngine;


public class FootStepSounds : MonoBehaviour
{
    [SerializeField] AudioClip footStep1;
    [SerializeField] AudioClip footStep2;
    [SerializeField] Camera mainCamera;

    [Range(0,1)] //We make the below float a range, that shows up in the Editor.
    public float clipVolume; //We make a volume-slider for our clips.


    public void playFootstep1()
    {
        AudioSource.PlayClipAtPoint(footStep1, mainCamera.transform.position, clipVolume); 
    }

    public void playFootstep2()
    {
        AudioSource.PlayClipAtPoint(footStep2, mainCamera.transform.position, clipVolume);
    }


}
