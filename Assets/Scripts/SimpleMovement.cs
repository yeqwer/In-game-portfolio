using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class SimpleMovement : MonoBehaviour
{
    public float maxSpeed = 8f;
    public float maxSpeedBack = 2f;
    public float rotationSpeed = 2f;
    public float speedUpRotation = -7f;
    public float afterMoveVelocity = 5f;
    
    protected Rigidbody rb;
    private NewControls controls;
    private ParticleSystem partSys;
    private CheckLocation checkLoc;

    private bool flag = false;
    private bool canAfterTimer = true;
    private float timer;

    public void Awake()
    {
        partSys = GetComponentInChildren<ParticleSystem>();
        rb = GetComponent<Rigidbody>();
        controls = new NewControls();
        checkLoc = GetComponent<CheckLocation>();
    }


    private void Update()
    {
        Timer();

        if (checkLoc.itWater)
        {
            Movement();
        }
        else
        {
            Dropper(10f);
        }
    }

    private void Movement()
    {
        if (controls.Movement.Joistisk.inProgress)
        {
            Vector2 move = controls.Movement.Joistisk.ReadValue<Vector2>();
            if (move.y < 0)
            {
                transform.Translate(transform.forward * move.y * Time.deltaTime * maxSpeedBack, Space.World);
                transform.Rotate(Vector3.up * -move.x * rotationSpeed * Time.deltaTime);
                
                partSys.Stop();
            }
            else 
            {
                if (controls.Movement.Shift.inProgress)
                {
                    transform.Translate(transform.forward * Time.deltaTime * maxSpeed * 1.5f, Space.World);
                }
                else if (move.y == 0)
                {
                    transform.Translate(transform.forward * Time.deltaTime * maxSpeed / 2, Space.World);
                } 
                else
                {
                    transform.Translate(transform.forward * Time.deltaTime * maxSpeed, Space.World);
                }

                transform.Rotate(Vector3.up * move.x * rotationSpeed * Time.deltaTime);
                
                partSys.Play();
                flag = true;
            }
        }
        else
        {
            if (canAfterTimer & flag)
            {
                
                Forcer();
            }
            
            partSys.Stop();
        }
    }

    public void Timer()
    {
        if (timer > 0)
        {
            canAfterTimer = false;
            timer -= Time.deltaTime;
        }
        else { canAfterTimer = true; }
    }

    private void Forcer()
    {
        rb.AddForce(transform.forward * afterMoveVelocity, ForceMode.Impulse);
        timer = 1f;
        flag = false;
    }

    private void Dropper(float power)
    {

        controls.Disable();
        rb.AddForce(-transform.forward.normalized * power, ForceMode.Impulse);
        StartCoroutine(StarterDelay(0.5f));
    }

    IEnumerator StarterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        rb.velocity = Vector3.zero;
        controls.Enable();
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
