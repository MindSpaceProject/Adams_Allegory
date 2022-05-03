using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabLunch : MonoBehaviour
{
    public GameObject lunchItem;
        void Start()
    {
     lunchItem.SetActive(false);
    }

    // when player hits collider, this method triggers
    void OnTriggerStay(Collider other) {
           lunchItem.SetActive(true);
            
    }
}
