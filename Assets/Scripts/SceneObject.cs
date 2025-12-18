using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneObject : MonoBehaviour
{
    public UnityEvent startFlagOff;
    public UnityEvent startFlagOn;
    
    [HideInInspector]
    public UnityEvent<bool> flagUpdated;
    public UnityEvent flagToggled;
    public void SetFlag(bool flag)
    {
        flagUpdated.Invoke(flag);
    }
    public void ToggleFlag()
    {
        flagToggled.Invoke();
    }
    public void StartWithFlag(bool flag)
    {
        if (flag)
        {
            startFlagOn.Invoke();
            return;
        }
        startFlagOff.Invoke();
    }

}
