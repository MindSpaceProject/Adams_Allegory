using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreludeDialogue : MonoBehaviour
{

    //UI elements
    public GameObject preludeBanckground;
    
    //UI text references
    public Text adamText;  
    public Text momText;

    int dialogueCounter;

    // Start is called before the first frame update
    void Start()
    {
        dialogueCounter = 0;
        adamText.text = "";
        momText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickNextDialogue(){
        if(dialogueCounter == 0){
            adamText.text = "Why do we have to move to Iowa again...";
            dialogueCounter++;
        }
        else if(dialogueCounter == 1){
            momText.text = "Come on Adam. We've talked about this already. We really need the money from this new job";
            dialogueCounter++;
        }
        else if(dialogueCounter == 2){
            momText.text = "";
            adamText.text = "I know, I know. I’m just really gonna miss all my friends. And transferring to a new school halfway into the semester is just… weird.";
            dialogueCounter++;
        }
        else if(dialogueCounter == 3){
            momText.text = "Do you remember Tommy, your childhood friend? His family lives in our new neighborhood! And he goes to your school. Isn’t that nice?";
            dialogueCounter++;
        }
        else if(dialogueCounter == 4){
            momText.text = "";
            adamText.text = "Tommy?! I guess that's nice, we were really good friends. We haven’t talked that much since he moved. Maybe this won’t be as bad as I thought.";
            dialogueCounter++;
        }
        else if(dialogueCounter == 5){
            SceneManager.LoadScene("ChapterTransition");
        }
    }
}
