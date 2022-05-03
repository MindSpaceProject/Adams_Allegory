using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
<<<<<<< HEAD
    public GameObject gameGuide;
    public GameObject responseGuide;
    public GameObject mainMenu;
    
    private void Start() {
        mainMenu.SetActive(true);
        gameGuide.SetActive(false);
        responseGuide.SetActive(false);
    }
    
    public void onClickGameGuide(){
        mainMenu.SetActive(false);
        gameGuide.SetActive(true);
    }

    public void onClickResponseGuide(){
        gameGuide.SetActive(false);
        responseGuide.SetActive(true);
    }
    
    public void PlayGame()
    {
        ChapterTransition.chapter = 1;
        SceneManager.LoadScene("Prelude");
     //   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);// this can load the scene number 1 (game)//SceneManager.GetActiveScene().buildIndex +1
=======
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);// this can load the scene number 1 (game)//SceneManager.GetActiveScene().buildIndex +1
>>>>>>> f8d1914b4d75aebfa9aa5c3401a882091b087d54
    }
    public void AboutGame()
    {

        // go to about page
    }
<<<<<<< HEAD

    public void HelpGame()
    {

        // go to about page
    }

    public void ExitGame()
    {
        Application.Quit();
    }
=======
>>>>>>> f8d1914b4d75aebfa9aa5c3401a882091b087d54
}
