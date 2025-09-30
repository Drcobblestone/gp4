using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] bool goNextLevel;
    [SerializeField] string levelName;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player")) //Checks if the player enters the collider
        {
            if (goNextLevel)
            {
                SceneController.instance.NextLevel();
            }

            else
            {
                SceneController.instance.LoadScene(levelName);
            }
        }
    }
}

            //go to the next scene / level
            //
