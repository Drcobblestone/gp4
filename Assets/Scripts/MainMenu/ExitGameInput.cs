using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class ExitGameInput : MonoBehaviour
{
    [SerializeField] private InputActionReference cancelAction; //We get the cancel-action from the input action asset - we're going to use that to Quit.

    private void OnEnable()
    {
        cancelAction.action.Enable(); //When we enable the Cancel-action...
        cancelAction.action.performed += ctx => Application.Quit(); //...Then we quit the game.
    }

    private void OnDisable()
    {
        cancelAction.action.Disable(); //We turn off the ability to quit the game with the Cancel-action - when we don't need it.
    }
}
