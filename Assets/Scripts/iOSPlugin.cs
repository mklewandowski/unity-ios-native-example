using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class iOSPlugin : MonoBehaviour
{
#if UNITY_IOS

    [DllImport("__Internal")]
    private static extern void _ShowAlert(string title, string message);
    [DllImport("__Internal")]
    private static extern void _IncrementValue();
    [DllImport("__Internal")]
    private static extern int _GetValue();

    public static void ShowAlert(string title, string message)
    {
        _ShowAlert(title, message);
    }
    public static void IncrementValue()
    {
        _IncrementValue();
    }
    public static int GetValue()
    {
        int val = _GetValue();
        return val;
    }
#else
    public static void ShowAlert(string title, string message)
    {
        Debug.Log("ShowAlert is only supported on iOS");
    }
    public static void IncrementValue()
    {
        Debug.Log("IncrementValue only supported on iOS");
    }
    public static int GetValue()
    {
        Debug.Log("GetValue is only supported on iOS");
    }
#endif
}
