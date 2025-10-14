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
        if (!context.performed) //IO is faster than Start, so if the context for inputaction is started or cancelled, it is too fast for the compiler... hence this!
        {
            return; //...we return to wait.
        }
        WorldPosition = (Vector2) Camera.main.ScreenToWorldPoint(position: (Vector3) context.ReadValue<Vector2>()); //We send the value to world-position
    }

    public void OnInterAction(InputAction.CallbackContext context)
    {
        if (!context.performed) //...if we don't have the right context (not in range of clicking et c), then...
        {
            return; //... we go back and look again.
        }
        Clicked?.Invoke(); //If all conditions are met we register a click
    }

}
