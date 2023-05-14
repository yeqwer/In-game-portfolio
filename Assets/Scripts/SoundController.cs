using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    public AudioSource clickSound;
    public AudioSource motorSound;

    public void Click()
    {
        clickSound.Play();
    }

    public void SoundDrive(float pitch)
    {
        motorSound.pitch = pitch;
    }
}
