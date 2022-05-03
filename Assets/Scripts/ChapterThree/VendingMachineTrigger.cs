using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VendingMachineTrigger : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject adam1;
    public GameObject adam2;
    void OnTriggerEnter(Collider other) {
        cam1.SetActive(false);
        cam2.SetActive(true);
        adam1.SetActive(false);
        adam2.SetActive(true);
    }
}