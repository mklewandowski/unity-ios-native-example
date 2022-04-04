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
   [DllImport("__Internal")]
    private static extern void _InitLocation();
   [DllImport("__Internal")]
    private static extern void _FetchNetworkInfo();
    [DllImport("__Internal")]
    private static extern string _GetSSID();
    [DllImport("__Internal")]
    private static extern int _GetSignalStrength();

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
    public static void InitLocation()
    {
        _InitLocation();
    }
    public static void FetchNetworkInfo()
    {
        _FetchNetworkInfo();
    }
    public static string GetSSID()
    {
        string val = _GetSSID();
        return val;
    }
    public static int GetRSSI()
    {
        int val = _GetSignalStrength();
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
    public static void InitLocation()
    {
        Debug.Log("InitLocation is only supported on iOS");
    }
    public static void FetchNetworkInfo()
    {
        Debug.Log("FetchNetworkInfo is only supported on iOS");
    }
    public static string GetSSID()
    {
        Debug.Log("GetSSID is only supported on iOS");
    }
    public static int GetRSSI()
    {
        Debug.Log("GetRSSI is only supported on iOS");
    }
#endif
}
