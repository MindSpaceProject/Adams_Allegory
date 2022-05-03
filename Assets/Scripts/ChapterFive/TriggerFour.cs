using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TriggerFour : MonoBehaviour
{
    public NPC npc;
    float curResponseTracker = 0;
    float anxietyQuestions = 0;

    // UI Game Objects
    public GameObject dialogueUI;
    public GameObject npcPanel;
    public GameObject playerPanel;
    public GameObject playerPanel1;
    public GameObject playerPanel2;
    public GameObject playerPanel3;

    // UI Text References
    public Text playerName;
    public Text npcName;
    public Text npcDialogueText;
    public Text playerResponse;
    public Text playerResponse1;
    public Text playerResponse2;
    public Text playerResponse3;
    public Button btn;
    public Button btn2;
    public Button btn3;
    public bool adamEntered = false;

    // Anxiety scoring
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
        dialogueUI.SetActive(true);
        playerPanel.SetActive(false);
        npcPanel.SetActive(true);
        playerName.text = "";
        playerResponse.text = "";
        npcName.text = npc.npcName;
        npcDialogueText.text = npc.dialogue[0];
        adamEntered = true;
        AdamMovement.canMove = false;
    }

    void handleDialogue() {

        if (curResponseTracker == 0) {
                updateAdam(0);
        } 
        
        else if (curResponseTracker == 1) {
            updateAdam(1); 
        }

        else if (curResponseTracker == 2) {
            updateTeddy(1); 
        }

        else if (curResponseTracker == 3) {
            updateAdam(2); 
        }

        else if (curResponseTracker == 4) {
            updateAdam(3); 
        }

        else if (curResponseTracker == 5) {
            updateTeddy(2); 
        }

        // manual no name
        else if (curResponseTracker == 6) {
             if (Input.GetKeyDown(KeyCode.Return)) {
            // Set text to next dialogue response
            npcDialogueText.text = "";
            npcName.text = "";
            playerPanel.SetActive(true);
            npcPanel.SetActive(false);
            playerResponse.text = npc.playerDialogue[4];
            playerName.text = "";

            // Wait until user has finished reading and presses Enter
            if (Input.GetKeyDown(KeyCode.Return)) {
                curResponseTracker++;
            }
        }
        }

        else if (curResponseTracker == 7) {
            updateTeddy(3); 
        }

        else if (curResponseTracker == 8) {
            updateTeddy(4); 
        }
        
        else if (anxietyQuestions == 0) {
            buttonWasClicked = false;
            AnxietyQuestion(5);
        }

        // after every anxiety question, perform calculations and update manually
        else if (curResponseTracker == 9) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                TriggerTwo.chapterScore += tempValue;
                clearAnxietyQuestions();
                playerResponse.text = "";
                playerName.text = "";
                playerPanel.SetActive(false);
                npcPanel.SetActive(true);
                npcDialogueText.text = npc.dialogue[5];
                npcName.text = npc.npcName;

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTracker++;
                }
            }
        }

        // Anxiety Question
        else if (anxietyQuestions == 1) {
            AnxietyQuestion(5);
        }

        else if (curResponseTracker == 10) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                TriggerTwo.chapterScore += tempValue;
                clearAnxietyQuestions();
                playerResponse.text = "";
                playerName.text = "";
                playerPanel.SetActive(false);
                npcPanel.SetActive(true);
                npcDialogueText.text = npc.dialogue[6];
                npcName.text = npc.npcName;

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTracker++;
                }
            }
        }

        // Anxiety Question
        else if (anxietyQuestions == 2) {
            AnxietyQuestion(5);
        }

        else if (curResponseTracker == 11) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                TriggerTwo.chapterScore += tempValue;
                clearAnxietyQuestions();
                playerResponse.text = "";
                playerName.text = "";
                playerPanel.SetActive(false);
                npcPanel.SetActive(true);
                npcDialogueText.text = npc.dialogue[7];
                npcName.text = npc.npcName;

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTracker++;
                }
            }
        }

        else if (curResponseTracker == 12) {
            updateAdam(8); 
        }

        // Anxiety Question
        else if (anxietyQuestions == 3) {
            AnxietyQuestion(9);
        }

        else if (curResponseTracker == 13) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                TriggerTwo.chapterScore += tempValue;
                clearAnxietyQuestions();
                playerResponse.text = "";
                playerName.text = "";
                playerPanel.SetActive(false);
                npcPanel.SetActive(true);
                npcDialogueText.text = npc.dialogue[8];
                npcName.text = npc.npcName;

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTracker++;
                }
            }
        }

        else if (curResponseTracker == 14) {
            updateTeddy(9); 
        }

        else if (curResponseTracker == 15) {
            updateAdam(12); 
        }

        else if (curResponseTracker == 16) {
            updateAdam(13); 
        }

        // Anxiety Question
        else if (anxietyQuestions == 4) {
            AnxietyQuestion(14);
        }

        else if (curResponseTracker == 17) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                TriggerTwo.chapterScore += tempValue;
                clearAnxietyQuestions();
                playerResponse.text = "";
                playerName.text = "";
                playerPanel.SetActive(false);
                npcPanel.SetActive(true);
                npcDialogueText.text = npc.dialogue[10];
                npcName.text = npc.npcName;

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTracker++;
                }
            }
        }

        // Anxiety Question
        else if (anxietyQuestions == 5) {
            AnxietyQuestion(17);
        }

        else if (curResponseTracker == 18) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                TriggerTwo.chapterScore += tempValue;
                clearAnxietyQuestions();
                playerResponse.text = "";
                playerName.text = "";
                playerPanel.SetActive(false);
                npcPanel.SetActive(true);
                npcDialogueText.text = npc.dialogue[11];
                npcName.text = npc.npcName;

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTracker++;
                }
            }
        }

        else if (curResponseTracker == 19) {
            updateAdam(20); 
        }

        else if (curResponseTracker == 20) {
            updateTeddy(12); 
        }

        else if (curResponseTracker == 21) {
            updateTeddy(13); 
        }

        else if (curResponseTracker == 22) {
            updateAdam(21); 
        }

        else if (curResponseTracker == 23) {
            updateTeddy(14); 
        }

         else if (curResponseTracker == 24) {
            updateAdam(22); 
        }

        else if (curResponseTracker == 25) {
            updateTeddy(15); 
        }

        else if (curResponseTracker == 26) {
            updateAdam(23); 
        }

        // Once dialogue is finished
       else if (Input.GetKeyDown(KeyCode.E) && curResponseTracker == 27) {
            // End conversation, scene transition
            dialogueUI.SetActive(false);
            AdamMovement.canMove = true;
            Debug.Log("Final Chapter Score: " + TriggerTwo.chapterScore);
            ChapterTransition.chapter = 6;
            SceneManager.LoadScene("ChapterTransition");
            Destroy(gameObject);
        }
    }

    // Use this method to update Adam
    void updateAdam(int value) {
        if (Input.GetKeyDown(KeyCode.Return)) {
            // Set text to next dialogue response
            npcDialogueText.text = "";
            npcName.text = "";
            playerPanel.SetActive(true);
            npcPanel.SetActive(false);
            playerResponse.text = npc.playerDialogue[value];
            playerName.text = npc.playerName;

            // Wait until user has finished reading and presses Enter
            if (Input.GetKeyDown(KeyCode.Return)) {
                curResponseTracker++;
            }
        }
    }

    void updateTeddy(int value) {
        if (Input.GetKeyDown(KeyCode.Return)) {
            playerResponse.text = "";
            playerName.text = "";
            playerPanel.SetActive(false);
            npcPanel.SetActive(true);
            npcDialogueText.text = npc.dialogue[value];
            npcName.text = npc.npcName;

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
