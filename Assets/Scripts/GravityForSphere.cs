using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityForSphere : MonoBehaviour
{
    public Rigidbody attractorRigidbody;
    public float attractionForce = 10f;
    
    public Rigidbody followerRigidbody;

    void Start()
    {
        followerRigidbody = GetComponent<Rigidbody>();
        attractorRigidbody = GameObject.FindGameObjectWithTag("Water").GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float distance = Vector3.Distance(attractorRigidbody.position, followerRigidbody.transform.position);
        Vector3 direction = attractorRigidbody.position - followerRigidbody.position;
        followerRigidbody.AddForce(direction.normalized * attractionForce * distance);
    }
}
