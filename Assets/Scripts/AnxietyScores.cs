using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnxietyScores : MonoBehaviour
{
    public Text total;
    public Text chapter1;
    public Text chapter2;
    public Text chapter3;
    public Text chapter4;
    public Text chapter5;
    public int totalScore = 0;
    
    // Start is called before the first frame update
    void Start() {
        // Add all scores together
        totalScore = AdamRoomDialogue.chapterScore + AdamPlaysGame.chapterScore + WalkSchoolTommy.chapterScore + MomDance.chapterScore + TriggerTwo.chapterScore;
         
     //    Display all scores
         total.text = total.text + totalScore;
         chapter1.text = chapter1.text + AdamRoomDialogue.chapterScore;
         chapter2.text = chapter2.text + AdamPlaysGame.chapterScore;
         chapter3.text = chapter3.text + WalkSchoolTommy.chapterScore;
         chapter4.text = chapter4.text + MomDance.chapterScore;
         chapter5.text = chapter5.text + TriggerTwo.chapterScore;

    }
    
    public void onClickMainMenu() {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Viewed Anxiety Results");
    }
}
