using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItem : MonoBehaviour {
    // Float logic
    Vector3 currentPosition;
    [SerializeField]Vector3 movementVector;
    [SerializeField][Range(0,1)]float movementFactor;
    [SerializeField]float period = 2f;
    private bool itemGrabbed = false;
 
    private void Start() {
        currentPosition = transform.position;
    }

    void Update() {
        if(!itemGrabbed) {
        if(period <= Mathf.Epsilon) return; // Mathf.Epsilon is the number closest to 0
        float cycles = Time.time / period; // loop period between -1 and 1 or depends on given value
        const float tau = Mathf.PI * 2; // tau is the loop around a whole circle, which is the sound wave, constant value of 6.283
        float sinWave = Mathf.Sin(cycles * tau); // sin takes input angle in radians from -1 to 1
        movementFactor = (sinWave + 1f) / 2f; // recalculated to go from 0 to 1 so its cleaner
        Vector3 offset = movementVector * movementFactor;
        transform.position = currentPosition + offset;
        }
    }

    // when player hits collider, this method triggers
    void OnTriggerStay(Collider other) {   
            itemGrabbed = true;
            Destroy(gameObject);
    }

}
