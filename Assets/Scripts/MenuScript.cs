using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    
    private CheckLocation checkLoc;
    public NewControls controls;

    public GameObject textPressE;
    public GameObject textRestart;

    private void Awake()
    {
        
        checkLoc = FindObjectOfType<CheckLocation>();
        controls = new NewControls();
    }
    private void Update()
    {
        if (checkLoc.pressE)
        {
            textPressE.SetActive(true);
            
        }
        else { textPressE.SetActive(false); }

        if (checkLoc.pressRestart)
        {
            textRestart.SetActive(true);
            
        }
        else { textRestart.SetActive(false); }

        if (controls.Menu.Restart.triggered & textRestart.activeSelf)
        {
            Restart();
        } 
    }

    public void Restart()
    {
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