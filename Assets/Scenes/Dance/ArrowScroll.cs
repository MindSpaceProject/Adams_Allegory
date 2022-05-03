
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScroll : MonoBehaviour
{
    public float arrowSpeed;
    public bool hasStarted;
    
    void Start()
    {
        arrowSpeed = arrowSpeed / 60f; // how fast it should move per second 
    }

    void Update()
    {
        if(!hasStarted)
        {
            // if(Input.anyKeyDown)
            // {
            //     hasStarted = true;
            // }
        } else
        {
            transform.position -= new Vector3(0f, arrowSpeed * Time.deltaTime, 0f);
        }
    }
}