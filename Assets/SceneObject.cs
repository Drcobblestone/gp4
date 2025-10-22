using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneObject : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent<bool> flagUpdated;
    public void SetFlag(bool flag)
    {
        flagUpdated.Invoke(flag);
    }

}
