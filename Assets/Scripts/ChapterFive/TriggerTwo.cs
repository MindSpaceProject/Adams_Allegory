using UnityEngine;
using UnityEngine.UI;

public class TriggerTwo : MonoBehaviour
{
    public NPC npc;
    float curResponseTracker = 0;
    float anxietyQuestions = 0;
    public AudioSource audioSource;
    public AudioSource HeartBeat;
    // UI Game Objects
    public GameObject dialogueUI;
    public GameObject tempWall;
 
    public GameObject playerPanel1;
    public GameObject playerPanel2;
    public GameObject playerPanel3;
    

    // UI Text References
    public Text playerName;
    public Text playerResponse;
    public Text playerResponse1;
    public Text playerResponse2;
    public Text playerResponse3;
    public Button btn;
    public Button btn2;
    public Button btn3;
    public bool adamEntered = false;

    // Anxiety scoring
    public static int chapterScore = 0; // Keep track of chapter score
    public int tempValue = 0; // Keep track of temp chapter score value
    bool buttonWasClicked = false;

    void Start(){
        dialogueUI.SetActive(false);
    }
     void Update() {
         if(adamEntered) {
             handleDialogue();

         }

     }
    void OnTriggerEnter(Collider other) {  
        AdamMovement.canMove = false;
        dialogueUI.SetActive(true);
        playerName.text = npc.playerName;
        playerResponse.text = npc.playerDialogue[0];
        HeartBeat.volume = 0.8f;
        adamEntered = true;
        audioSource.volume = 0.8f;
    }

    void handleDialogue() {
         // Adam updates
        if (curResponseTracker == 0) {
           updateAdam(1);
        }

        else if (curResponseTracker == 1) {
            updateAdam(2); 
        }

        else if (curResponseTracker == 2) {
            updateAdam(3); 
        }

        // Anxiety Question
        else if (anxietyQuestions == 0) {
            AnxietyQuestion(4);
            
        }

        // after every anxiety question, perform calculations and update manually
        else if (curResponseTracker == 3) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                chapterScore += tempValue;
                clearAnxietyQuestions();
                playerResponse.text = npc.playerDialogue[7];

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTracker++;
                }
            }
        }

        // Anxiety Question
        else if (anxietyQuestions == 1) {
            AnxietyQuestion(8);
            
        }

        else if (curResponseTracker == 4) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                chapterScore += tempValue;
                clearAnxietyQuestions();
                playerResponse.text = npc.playerDialogue[11];

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTracker++;
                }
            }
        }

        else if (curResponseTracker == 5) {
            audioSource.volume = 1;
            updateAdam(12); 
        }

        else if (curResponseTracker == 6) {
            updateAdam(13); 
        }

        // Once dialogue is finished
       else if (Input.GetKeyDown(KeyCode.E) && curResponseTracker == 7) {
         AdamMovement.canMove = true;
         dialogueUI.SetActive(false);
         tempWall.SetActive(false);
         Destroy(gameObject);
    }
    }

    // Use this method to update Adam
    void updateAdam(int value) {
        if (Input.GetKeyDown(KeyCode.Return)) {
            // Set text to next dialogue response
            playerResponse.text = npc.playerDialogue[value];
            playerName.text = npc.playerName;

            // Wait until user has finished reading and presses Enter
            if (Input.GetKeyDown(KeyCode.Return)) {
                curResponseTracker++;
            }
        }
    }

    // Calculating anxiety responses
    public void onClickResponseOne() {
        tempValue = 2;
        buttonWasClicked = true;
    }

    public void onClickResponseTwo() {
        tempValue = 1;
        buttonWasClicked = true;
    }

    public void onClickResponseThree() {
        tempValue = 0;
        buttonWasClicked = true;
    }

    // Method for presenting anxiety questions on screen
    void AnxietyQuestion(int value) {
        if (Input.GetKeyDown(KeyCode.Return)) {
            playerPanel1.SetActive(true);
            playerPanel2.SetActive(true);
            playerPanel3.SetActive(true);
            playerResponse1.text = npc.playerDialogue[value];
            playerResponse2.text = npc.playerDialogue[value + 1];
            playerResponse3.text = npc.playerDialogue[value + 2];
            btn.interactable = true;
            btn2.interactable = true;
            btn3.interactable = true;
            if (Input.GetKeyDown(KeyCode.Return)) {
                anxietyQuestions++;
            }
        }
    }

    // Method for clearing anxiety questions off screen
    void clearAnxietyQuestions() {
        btn.interactable = false;
        btn2.interactable = false;
        btn3.interactable = false;
        playerResponse1.text = "";
        playerResponse2.text = "";
        playerResponse3.text = "";
        playerPanel1.SetActive(false);
        playerPanel2.SetActive(false);
        playerPanel3.SetActive(false);
    }
}
