using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script should be scalable, so that we can assign whichever music we want, for a scene. Or add conditions to the if-statement, to play something else than standard. (if we want)

public class BackgroundMusic : MonoBehaviour
{
    //We summon the game-manager /LevelManager, so we can know which scene we are in.
    //[Header("(Put the SceneData here.)")]
    //[SerializeField] SceneData sceneData;

    //We make the below fields so we can load whichever music we deem fit, in a scene.
    [Header("(Put the Music-files here)")]
    [SerializeField]  AudioClip standardMusic; //The standard bg-music.
    [SerializeField]  AudioClip winMusic; //The winning-scene music.

    [Header("(Put the AudioSource here)")]
    [SerializeField]  public AudioSource musicSource;



    public void ChangeMusic(bool standard)
    {
        musicSource.Stop(); //We stop playing the music before we change the music-clip.
        musicSource.clip = standard ? standardMusic : winMusic; //Ternary Conditional: Bool ? trueValue : falseValue
        musicSource.Play();
    }

}
