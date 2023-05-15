using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject joystick;
    public GameObject forceButton;
    public GameObject textBinds;

    public GameObject textPressAction;
    public GameObject textPressRestart;

    private void Start()
    {
        if (CheckDevice.IsMobileBrowser())
        {
            joystick.SetActive(true);
            forceButton.SetActive(true);

            textBinds.SetActive(false);

            textPressRestart.transform.localScale = new Vector3(2, 2, 2);
            textPressAction.transform.localScale = new Vector3(2, 2, 2);
            textPressAction.GetComponentInChildren<TextMeshProUGUI>().text = "Press Here";
            
        }
        else
        {
            joystick.SetActive(false);
            forceButton.SetActive(false);

            textBinds.SetActive(true);

            textPressRestart.transform.localScale = new Vector3(1, 1, 1);
            textPressAction.transform.localScale = new Vector3(1, 1, 1);
            textPressAction.GetComponentInChildren<TextMeshProUGUI>().text = "Press E";
        }
    }
}
