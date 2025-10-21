using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonMiddleman : MonoBehaviour
{
    public UnityEvent onClicked;

    public void OnClick()
    {
        onClicked.Invoke();
    }
}
