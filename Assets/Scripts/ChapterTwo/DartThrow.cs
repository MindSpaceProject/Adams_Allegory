using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class DartThrow : MonoBehaviour
{
    private Rigidbody rb;
    public float impulse = 0f;
    public float maxImpulse;
    public float torque = 0.1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            impulse += 5f;
            if (impulse > maxImpulse)
            {
                impulse = maxImpulse;
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            rb.isKinematic = false;
            rb.AddRelativeForce(Vector3.up * impulse); // Up because the dart is a rotated cylinder at the moment
            rb.AddTorque(torque, 0, 0);
        }
    }
}