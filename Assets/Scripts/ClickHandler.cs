using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent _clicked;

    private MouseInputProvider _mouse;

    private void Awake()
    {
        _mouse = FindObjectOfType<MouseInputProvider>();
        _mouse.Clicked += MouseOnClicked;
    }
}
