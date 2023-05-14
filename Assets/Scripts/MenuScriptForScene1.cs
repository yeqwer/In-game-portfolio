using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScriptForScene1 : MonoBehaviour
{
    private SoundController soundController;
    private CheckLocationForScene1 checkLoc;
    public NewControls controls;

    public GameObject textPressE;
    public GameObject textRestart;

    private void Awake()
    {
        soundController = FindObjectOfType<SoundController>();
        checkLoc = FindObjectOfType<CheckLocationForScene1>();
        controls = new NewControls();
    }
    private void Update()
    {
        if (checkLoc.pressE)
        {
            textPressE.SetActive(true);
            
        }
        else { textPressE.SetActive(false); }

        if (controls.Menu.Restart.triggered)
        {
            Restart();
        }
    }

    public void Restart()
    {
        soundController.Click();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
