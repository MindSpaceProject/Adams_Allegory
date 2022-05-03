using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTransition : MonoBehaviour
{

    public GameObject tutorialScreen;
    public GameObject dialogue;

    void OnTriggerStay(Collider other) { 
        dialogue.SetActive(false);  
        tutorialScreen.SetActive(true);
    }

    public void onClickStartGame(){
        SceneManager.LoadScene("ShootingGame");
    }
}
