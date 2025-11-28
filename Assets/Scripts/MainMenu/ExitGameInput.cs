using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class ExitGameInput : MonoBehaviour
{
    [SerializeField] public InputActionReference cancelAction; //We get the cancel-action from the input action asset - we're going to use that to Quit.

    private void OnEnable()
    {
        cancelAction.action.Enable(); //When we enable the Cancel-action...
        Debug.Log("We can Cancel");
        cancelAction.action.performed += ctx => Application.Quit(); //...Then we quit the game.
        //cancelAction.action.performed += ctx => EditorApplication.ExitPlaymode();
    }

    private void OnDisable()
    {
        Debug.Log("We Stopped"); //This will only be visible in-editor.
        cancelAction.action.Disable(); //We turn off the ability to quit the game with the Cancel-action - when we don't need it.
        Debug.Log("Turning off Cancel.");
    }
}
