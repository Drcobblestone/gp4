using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameWithEsc : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
