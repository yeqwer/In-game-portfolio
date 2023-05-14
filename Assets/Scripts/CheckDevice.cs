using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDevice : MonoBehaviour
{
    public GameObject joystick;
    public GameObject forceButton;

    void Start()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            forceButton.SetActive(true);
            joystick.SetActive(true);
        } else
        {
            forceButton.SetActive(false);
            joystick.SetActive(false);
        }
    }
}
