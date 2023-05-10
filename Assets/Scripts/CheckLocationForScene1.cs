using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class CheckLocationForScene1 : MonoBehaviour
{
    [HideInInspector] public bool itWater = true;
    [HideInInspector] public Collider groundCollider;
    [HideInInspector] public bool pressE = false;
    [HideInInspector] public bool pressRestart = false;
    [HideInInspector] public ChangeCameraForScene1 changeCam;
    [HideInInspector] public ShipDrive movement;
    [HideInInspector] public List<GameObject> colliderDots = new List<GameObject>();
    public float dotsInGround;

    private void Awake()
    {
        changeCam = FindObjectOfType<ChangeCameraForScene1>();
        movement = FindObjectOfType<ShipDrive>();
        colliderDots.AddRange(GameObject.FindGameObjectsWithTag("TriggerDot"));
    }
    private void Start()
    {
        foreach (GameObject go in colliderDots)
        {
            go.AddComponent<CheckGround>();
        }
    }

    private void Update()
    {
        /*
        if (dotsInGround == 2f)
        {
            movement.maxSpeed = 4f;
            pressRestart = true;
        }
        else if (dotsInGround == 4f)
        {
            movement.maxSpeed = 0f;
            pressRestart = true;
        }
        else
        {
            movement.maxSpeed = movement.maxSpeedStart;
            pressRestart = false;
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        var tag = other.gameObject;

        if (tag.CompareTag("Ground") | tag.CompareTag("Wall"))
        {
            itWater = false;
            //groundCollider = other;
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
            //groundCollider = null; 
        }
        if (tag.CompareTag("TriggerOne") | tag.CompareTag("TriggerTwo") | tag.CompareTag("TriggerThree") | tag.CompareTag("TriggerFour") | tag.CompareTag("TriggerFive"))
        {
            pressE = false;
            changeCam.TargetFollowObject = null;
            changeCam.TargetLookAtObject = null;
        }
    }
}

