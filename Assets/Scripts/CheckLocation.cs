using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CheckLocation : MonoBehaviour
{
    [HideInInspector] public bool itWater = true;
    [HideInInspector] public Collider groundCollider;
    [HideInInspector] public bool pressE = false;
    [HideInInspector] public ChangeCamera changeCam;
    

    private void Awake()
    {
        changeCam = FindObjectOfType<ChangeCamera>();

    }


    private void OnTriggerEnter(Collider other)
    {
        var tag = other.gameObject;

        if (tag.CompareTag("Ground") | tag.CompareTag("Wall"))
        {
            itWater = false;
            groundCollider = other;
        }

        if (tag.CompareTag("TriggerOne"))
        {
            pressE = true;
            changeCam.TargetFollowObject = GameObject.FindGameObjectWithTag("InfoBoardOne");
            changeCam.TargetLookAtObject = changeCam.TargetFollowObject;
        }
        else if (tag.CompareTag("TriggerTwo"))
        {
            pressE = true;
            changeCam.TargetFollowObject = GameObject.FindGameObjectWithTag("InfoBoardTwo");
            changeCam.TargetLookAtObject = changeCam.TargetFollowObject;
        }
        else if (tag.CompareTag("TriggerThree"))
        {
            pressE = true;
            changeCam.TargetFollowObject = GameObject.FindGameObjectWithTag("InfoBoardThree");
            changeCam.TargetLookAtObject = changeCam.TargetFollowObject;
        }
        else if (tag.CompareTag("TriggerFour"))
        {
            pressE = true;
            changeCam.TargetFollowObject = GameObject.FindGameObjectWithTag("InfoBoardFour");
            changeCam.TargetLookAtObject = changeCam.TargetFollowObject;
        }
        else if (tag.CompareTag("TriggerFive"))
        {
            pressE = true;
            changeCam.TargetFollowObject = GameObject.FindGameObjectWithTag("InfoBoardFive");
            changeCam.TargetLookAtObject = changeCam.TargetFollowObject;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        var tag = other.gameObject;

        if (tag.CompareTag("Ground") | tag.CompareTag("Wall"))
        {
            itWater = true;
            groundCollider = null; 
        }
        if (tag.CompareTag("TriggerOne") | tag.CompareTag("TriggerTwo") | tag.CompareTag("TriggerThree") | tag.CompareTag("TriggerFour") | tag.CompareTag("TriggerFive"))
        {
            pressE = false;
            changeCam.TargetFollowObject = null;
            changeCam.TargetLookAtObject = null;
        }
    }
}

