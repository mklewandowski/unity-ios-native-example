using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneManager : MonoBehaviour
{
    public TextMeshProUGUI Value;
    public TextMeshProUGUI SSID;
    public TextMeshProUGUI RSSI;

    public void SelectShowAlertButton()
    {
        iOSPlugin.ShowAlert("my title", "my message");
    }
    public void SelectIncrementValueButton()
    {
        iOSPlugin.IncrementValue();
    }
    public void SelectGetValueButton()
    {
        int val = iOSPlugin.GetValue();
        Value.text = val.ToString();
    }
    public void SelectInitLocationButton()
    {
        iOSPlugin.InitLocation();
    }
    public void SelectFetchNetworkInfoButton()
    {
        iOSPlugin.FetchNetworkInfo();
    }
    public void SelectGetSSIDButton()
    {
        string val = iOSPlugin.GetSSID();
        SSID.text = val;
    }
    public void SelectGetRSSIButton()
    {
        int val = iOSPlugin.GetRSSI();
        RSSI.text = val.ToString();
    }
}
