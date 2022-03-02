using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // int currentScene = SceneManager.GetActiveScene().buildIndex;
        // int nextScene = currentScene + 1;
        if(other.tag == "Player") {
            SceneManager.LoadScene("InsideGroceryStore");
        }
    }
}
