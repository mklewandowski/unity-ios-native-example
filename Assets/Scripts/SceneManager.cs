using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneManager : MonoBehaviour
{
    public TextMeshProUGUI Value;

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
}
