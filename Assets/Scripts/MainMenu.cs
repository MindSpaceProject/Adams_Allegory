using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);// this can load the scene number 1 (game)//SceneManager.GetActiveScene().buildIndex +1
    }
    public void AboutGame()
    {

        // go to about page
    }
}
