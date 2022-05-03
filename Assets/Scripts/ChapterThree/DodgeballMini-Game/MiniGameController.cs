using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MiniGameController : MonoBehaviour
{

    //adam/enemy character objects
    public GameObject adamCharacter;
    public GameObject opp1;
    public GameObject opp2;
    public GameObject opp3;
    public GameObject opp4;
    public GameObject opp5;
    //private variables, needed to cue losing/winning screen
    int hitCounter;
    bool gotHit;
    //UI objects activated upon circumstances
    public GameObject winScreen;
    public GameObject loseScren;

    // Start is called before the first frame update
    void Start()
    {
        winScreen.SetActive(false);
        loseScren.SetActive(false);
        hitCounter = 0;
        gotHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        loadWin();
        loadLose();
    }



    void loadLose(){
        if(gotHit){
            loseScren.SetActive(true);
        }
    }
    void loadWin(){
        if(hitCounter == 5){
            winScreen.SetActive(true);
        }
    }

    public void onClickRestart(){
        Debug.Log("Restart buton was clicked");
        SceneManager.LoadScene("Cafeteria");
     //   Scene scene = SceneManager.GetActiveScene();
      //  SceneManager.LoadScene(scene.name);

    }

    public void onClickWin() {
        Debug.Log("Win button was clicked.");
        SceneManager.LoadScene("Cafeteria");

    }

    public int getHitCounter(){
        return hitCounter;
    }
    public void setHitCounter(int hitCounter){
        this.hitCounter = hitCounter;
    }
    public bool getGotHit(){
        return gotHit;
    }
    public void setGotHit(bool gotHit){
        this.gotHit = gotHit;
    }
}
