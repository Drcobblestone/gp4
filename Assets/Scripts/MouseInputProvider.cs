using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInputProvider : MonoBehaviour
{
    public Vector2 WorldPosition
    {
        get; private set;
    }
    public event Action Clicked;

    public void OnMousePosition(InputAction.CallbackContext context) //When your mouse is over a clickable item
    {   
        //context.ReadValue<Vector2>()
        WorldPosition = (Vector2)Camera.main.ScreenToWorldPoint(position: (Vector3) context.ReadValue<Vector2>()); //We send the value to world-position
    }

    public void OnInterAction(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }
        Clicked?.Invoke(); //And register a click
    }

}
