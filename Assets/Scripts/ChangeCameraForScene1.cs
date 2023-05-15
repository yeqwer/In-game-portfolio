using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class ChangeCameraForScene1 : MonoBehaviour
{
    public CheckLocationForScene1 checkLoc;
    public NewControls controls;
    public ShipDrive shipDrive;

    public CinemachineVirtualCamera cam;
    public CinemachineComponentBase camBody;
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
    public float startRotationSpeed;
    public float startSpeedUpRotation;
    public float startAfterMoveVelocity;

    public SoundController soundController;

    private void Awake()
    {
        soundController = FindObjectOfType<SoundController>();
        cam = GetComponent<CinemachineVirtualCamera>();
        controls = new NewControls();
        checkLoc = FindObjectOfType<CheckLocationForScene1>();
        shipDrive = FindObjectOfType<ShipDrive>();
    }

    private void Start()
    {
        canActiveButton = true;

        camBody = cam.GetCinemachineComponent(CinemachineCore.Stage.Body);
        transposerCam = cam.GetCinemachineComponent<CinemachineTransposer>();

        startCameraRotation = cam.transform.rotation;
        //startCameraOffset = transposerCam.m_FollowOffset; //Offset Camera
        startCameraOffset = (camBody as CinemachineFramingTransposer).m_TrackedObjectOffset;
        startCameraDistance = (camBody as CinemachineFramingTransposer).m_CameraDistance;
        startLookAtObject = cam.LookAt;
        startFollowObject = cam.Follow;

        startMaxSpeed = shipDrive.maxSpeed;
        startRotationSpeed = shipDrive.rotationSpeed;
        startSpeedUpRotation = shipDrive.speedUpRotation;
        startAfterMoveVelocity = shipDrive.afterMoveVelocity;
    }

    private void Update()
    {
        if (checkLoc.pressE & controls.Menu.E.triggered)
        {
            ChangeCamTarget();
        }

        if (!canActiveButton)
        {
            cam.transform.rotation = Quaternion.Lerp(transform.rotation, TargetLookAtObject.transform.rotation, Time.deltaTime * 10f);
        }
        else
        {
            cam.transform.rotation = Quaternion.Lerp(transform.rotation, startCameraRotation, Time.deltaTime * 10f);
        }
    }

    public void ChangeCamTarget()
    {
        soundController.Click();

        if (canActiveButton)
        {

            //cam.transform.rotation = Quaternion.Lerp(transform.rotation, TargetLookAtObject.transform.rotation, Time.deltaTime * 10f);
            startFollowObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            shipDrive.maxSpeed = 0f;
            shipDrive.rotationSpeed = 0f;
            shipDrive.speedUpRotation = 0f;
            shipDrive.afterMoveVelocity = 0f;

            cam.LookAt = TargetLookAtObject.transform;
            cam.Follow = TargetFollowObject.transform;
            //transposerCam.m_FollowOffset = new Vector3(0, 0, -1.3f); //Offset Camera    
            (camBody as CinemachineFramingTransposer).m_CameraDistance = 2.5f;
            (camBody as CinemachineFramingTransposer).m_TrackedObjectOffset = Vector3.zero;



            canActiveButton = false;
        }
        else
        {
            //cam.transform.rotation = Quaternion.Lerp(transform.rotation, startCameraRotation, Time.deltaTime * 10f);
            startFollowObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            shipDrive.maxSpeed = startMaxSpeed;
            shipDrive.rotationSpeed = startRotationSpeed;
            shipDrive.speedUpRotation = startSpeedUpRotation;
            shipDrive.afterMoveVelocity = startAfterMoveVelocity;

            cam.LookAt = startLookAtObject;
            cam.Follow = startFollowObject;
            //transposerCam.m_FollowOffset = startCameraOffset; //Offset Camera
            (camBody as CinemachineFramingTransposer).m_CameraDistance = startCameraDistance;
            (camBody as CinemachineFramingTransposer).m_TrackedObjectOffset = startCameraOffset;

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