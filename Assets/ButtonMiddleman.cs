using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//This script helps the ConversationCanvas to get access to the ClickHandler. Unity's "Button" is written as a raw Action, and does not allow it directly.

public class ButtonMiddleman : MonoBehaviour
{
    public UnityEvent onClicked;

    public void OnClick()
    {
        onClicked.Invoke();
    }
}
