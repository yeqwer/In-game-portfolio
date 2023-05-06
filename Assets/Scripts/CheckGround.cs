using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public CheckLocation checkLoc;

    private void Awake()
    {
        checkLoc = FindObjectOfType<CheckLocation>();   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            checkLoc.dotsInGround++;
        } 
    }    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            checkLoc.dotsInGround--;
        } 
    }
}
