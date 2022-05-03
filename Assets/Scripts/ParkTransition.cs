using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParkTransition : MonoBehaviour
{
    void OnTriggerStay(Collider other) {   
        SceneManager.LoadScene("Classroom");
    }
}
