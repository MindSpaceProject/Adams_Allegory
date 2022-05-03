using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NightmareTransition : MonoBehaviour {

// when player hits collider, this method triggers
    void OnTriggerEnter(Collider other) {  
        AdamRoomDialogue.cameraChange = true; 
        SceneManager.LoadScene("AdamRoom");
    }
}