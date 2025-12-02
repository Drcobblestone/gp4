using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script is used to make a separate logging-class that can be used instead of Unity's standard Debug.log, in order to turn off all logging for certain builds.

public static class Logging
{
    [System.Diagnostics.Conditional("ENABLE_LOG")]
    static public void Log(object message)
    {
        UnityEngine.Debug.Log(message);
    }

    static public void LogWarning(object message)
    {
        UnityEngine.Debug.LogWarning(message);
    }

    static public void LogError(object message)
    {
        UnityEngine.Debug.LogError(message);
    }



    //Use like this: Logging.Log($"debug-message");
    //Instead of the regular debug.log line.
}
