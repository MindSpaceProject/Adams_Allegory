using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChapterTransition : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 2f;
    public static int chapter = 1;
    public Text chapterText;

    //extra useless text
    // Start is called before the first frame update
    void Start() {
        currentTime = 0f;
        startingTime = 2f;
        currentTime = startingTime;

        if(chapter == 1) {
            chapterText.text = "Chapter One";
        } else if(chapter == 2) {
            chapterText.text = "Chapter Two";
        } else if(chapter == 3) {
            chapterText.text = "Chapter Three";    
        } else if(chapter == 4) {
            chapterText.text = "Chapter Four";   
        }
        else if(chapter == 5) {
            chapterText.text = "Chapter Five";
            
        } else if(chapter == 6) {
            chapterText.text = "Final Chapter";          
        } else if(chapter == 7) {
            chapterText.text = "Anxiety Results";          
        } 
    }

    // Update is called once per frame
    void Update()  {
        if(currentTime>0f) {
        currentTime -= 1 * Time.deltaTime;
        }

        if(currentTime<=0f) {
           loadLevel();
           chapter ++;
        }
    }

    void loadLevel() {
        if(chapter == 1) {
            SceneManager.LoadScene("AdamRoom");
        } else if(chapter == 2) {
            SceneManager.LoadScene("AdamRoomTwo");
        } else if(chapter == 3) {
            SceneManager.LoadScene("Park");
        } else if(chapter == 4) {
            SceneManager.LoadScene("MomDance");
        }
        else if(chapter == 5) {
            SceneManager.LoadScene("PanicDisorder");
        } else if(chapter == 6) {
            SceneManager.LoadScene("TommyHouse");     
        } else if(chapter == 7) {
            SceneManager.LoadScene("AnxietyResults");     
        } 
    }
}
