using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    private CheckLocation checkLoc;
    public GameObject textPressE;

    private void Awake()
    {
        checkLoc = FindObjectOfType<CheckLocation>();
    }
    private void Update()
    {
        if (checkLoc.pressE)
        {
            textPressE.SetActive(true);
        }
        else { textPressE.SetActive(false); }
    }
}
