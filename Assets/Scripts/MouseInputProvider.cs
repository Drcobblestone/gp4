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

    private void OnMousePosition(InputValue value) //When your mouse is over a clickable item
    {
        WorldPosition = (Vector2)Camera.main.ScreenToWorldPoint(position: (Vector3)value.Get<Vector2>()); //We send the value to world-position
    }

    private void OnInterAction(InputValue _)
    {
        Clicked?.Invoke(); //And register a click
    }

}
