using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class ChangeCamera : MonoBehaviour
{
    public CheckLocation checkLoc;
    public NewControls controls;
    public SimpleMovement simpleMovement;

    public CinemachineVirtualCamera cam;
    //public CinemachineComponentBase camBody;
    public CinemachineTransposer transposerCam;

    public GameObject TargetFollowObject;
    public GameObject TargetLookAtObject;

    public bool canActiveButton;

    public Quaternion startCameraRotation;
    public Vector3 startCameraOffset;
    public float startCameraDistance;
    public Transform startLookAtObject;
    public Transform startFollowObject;
    public float startMaxSpeed;
    //public float startRotationSpeed;
    public float startSpeedUpRotation;
    public float startAfterMoveVelocity;

    private void Awake()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        controls = new NewControls();
        checkLoc = FindObjectOfType<CheckLocation>();
        simpleMovement = FindObjectOfType<SimpleMovement>();
    }

    private void Start()
    {
        canActiveButton = true;

        //camBody = cam.GetCinemachineComponent(CinemachineCore.Stage.Body);
        transposerCam = cam.GetCinemachineComponent<CinemachineTransposer>();

        startCameraRotation = cam.transform.rotation;
        startCameraOffset = transposerCam.m_FollowOffset; //Offset Camera
        //startCameraOffset = (camBody as CinemachineFramingTransposer).m_TrackedObjectOffset;
        //startCameraDistance = (camBody as CinemachineFramingTransposer).m_CameraDistance;
        startLookAtObject = cam.LookAt;
        startFollowObject = cam.Follow;

        startMaxSpeed = simpleMovement.maxSpeed;
        //startRotationSpeed = simpleMovement.rotationSpeed;
        startSpeedUpRotation = simpleMovement.speedUpRotation;
        startAfterMoveVelocity = simpleMovement.afterMoveVelocity;
    }

    private void Update()
    {
        if (checkLoc.pressE & controls.Menu.E.triggered)
        {
            ChangeCamTarget();
        }

        if (!canActiveButton)
        {
            //cam.transform.rotation = Quaternion.Lerp(transform.rotation, TargetLookAtObject.transform.rotation, Time.deltaTime * 10f);
        }
        else 
        {
            //cam.transform.rotation = Quaternion.Lerp(transform.rotation, startCameraRotation, Time.deltaTime * 10f);
        }
    }

    private void ChangeCamTarget()
    {
        if (canActiveButton)
        {
            //cam.transform.rotation = Quaternion.Lerp(transform.rotation, TargetLookAtObject.transform.rotation, Time.deltaTime * 10f);
            startFollowObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            simpleMovement.maxSpeed = 0f;
            //simpleMovement.rotationSpeed = 0f;
            simpleMovement.speedUpRotation = 0f;
            simpleMovement.afterMoveVelocity = 0f;

            cam.LookAt = TargetLookAtObject.transform;
            cam.Follow = TargetFollowObject.transform;
            transposerCam.m_FollowOffset = new Vector3(0, 0, -1.3f); //Offset Camera
            //(camBody as CinemachineFramingTransposer).m_CameraDistance = 2.8f;
            //(camBody as CinemachineFramingTransposer).m_TrackedObjectOffset = Vector3.zero;



            canActiveButton = false;
        } 
        else
        {
            //cam.transform.rotation = Quaternion.Lerp(transform.rotation, startCameraRotation, Time.deltaTime * 10f);
            startFollowObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            simpleMovement.maxSpeed = startMaxSpeed;
            //simpleMovement.rotationSpeed = startRotationSpeed;
            simpleMovement.speedUpRotation = startSpeedUpRotation;
            simpleMovement.afterMoveVelocity = startAfterMoveVelocity;
            
            cam.LookAt = startLookAtObject;
            cam.Follow = startFollowObject;
            transposerCam.m_FollowOffset = startCameraOffset; //Offset Camera
            //(camBody as CinemachineFramingTransposer).m_CameraDistance = startCameraDistance;
            //(camBody as CinemachineFramingTransposer).m_TrackedObjectOffset = startCameraOffset;

            canActiveButton = true;
        }

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
