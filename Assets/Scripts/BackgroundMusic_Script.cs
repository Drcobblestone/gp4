using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script should be scalable, so that we can assign whichever music we want, for a scene. Or add conditions to the if-statement, to play something else than standard. (if we want)

public class BackgroundMusic_Script : MonoBehaviour
{
    //We summon the game-manager /LevelManager, so we can know which scene we are in.
    [Header("(Put the SceneData here.)")]
    [SerializeField] SceneData sceneData;

    //We make the below fields so we can load whichever music we deem fit, in a scene.
    [Header("(Put the Music-files here)")]
    [SerializeField]  AudioClip standardMusic; //The standard bg-music.
    [SerializeField]  AudioClip winMusic; //The winning-scene music.

    [Header("(Put the AudioSource here)")]
    [SerializeField]  AudioSource musicSource;

    //public void playMusic() //<- We need Awake, I think...
    public void Awake()

    {
        if (sceneData.sceneName != "BookClub" || sceneData == null) //If the scene isn't named BookClub (aka our win-scene), or we haven't popped in the scene-data, then...
        {
            musicSource.clip = standardMusic; //Assign the regular music.
            musicSource.Play(); //And play it.
            Logging.Log($"We're playing music.");
        }
        
        else //But if it's the BookClub scene, then...
        {
            musicSource.clip = winMusic; //Assign the winning-music to the audio-source and...
            Logging.Log($"Changed music to Party."); //...let us know that you changed music-clip.
            musicSource.Play(); //Play the new music.
        }

    }

}
