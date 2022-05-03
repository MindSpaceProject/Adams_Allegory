using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MomDance : MonoBehaviour
{
    public NPC npc;
    bool isTalking = false;
    bool conversationFinished = false;
    float curResponseTrackerNPC = 0;
    float curResponseTrackerPlayer = 0;
    float anxietyQuestions = 0;

    // UI Game Objects
    public GameObject dialogueUI;
    public GameObject npcCharacter;
    public GameObject adam;
    public GameObject adam2;
    public GameObject npcPanel;
    public GameObject playerPanel;
    public GameObject playerPanel1;
    public GameObject playerPanel2;
    public GameObject playerPanel3;
    public GameObject capsule;
    
    // Cameras
    public GameObject cam1;
    public GameObject cam2;

    // UI Text References
    public Text npcName;
    public Text playerName;
    public Text npcDialogueText;
    public Text playerResponse;
    public Text playerResponse1;
    public Text playerResponse2;
    public Text playerResponse3;

    // Anxiety Question Buttons
    public Button btn;
    public Button btn2;
    public Button btn3;
    public static int chapterScore = 0; // Keep track of chapter score
    public int tempValue = 0; // Keep track of temp chapter score value
    bool buttonWasClicked = false;

    // Start is called before the first frame update
    void Start() {
            cam1.SetActive(true);
            cam2.SetActive(false);
            adam2.SetActive(false);
            dialogueUI.SetActive(false);
    }

       void OnMouseOver() {
        // Trigger dialogue
        if (Input.GetKeyDown(KeyCode.E) && isTalking == false) {
            StartConversation();
        }

        // Adam updates
         if (curResponseTrackerNPC == 0 && isTalking == true) {
           if (Input.GetKeyDown(KeyCode.Return)) {
            // Set text to next dialogue response
            playerResponse.text = npc.playerDialogue[1];
            playerName.text = npc.playerName;

            // Wait until user has finished reading and presses Enter
            if (Input.GetKeyDown(KeyCode.Return)) {
                curResponseTrackerPlayer++;
                curResponseTrackerNPC++;
            }
        }
        }

        // Anxiety question
        else if (anxietyQuestions == 0) {
            AnxietyQuestion(2);
        }

        // Adam updates
        else if (curResponseTrackerNPC == 1) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                chapterScore += tempValue;
                clearAnxietyQuestions();
                playerResponse.text = npc.playerDialogue[5];

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTrackerNPC++;
                    curResponseTrackerPlayer++;
                }
            }
        }

        // Mom Updates
        else if (curResponseTrackerPlayer == 2) {
            MomSpeaks(0);
        }

        // Anxiety question no calculation
        else if (anxietyQuestions == 1) {
            
            AnxietyQuestion(6);
        }

        // Adam updates no calculation
        else if (curResponseTrackerNPC == 3) {
           if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                clearAnxietyQuestions();
                playerPanel.SetActive(true);
                npcDialogueText.text = "";
                npcName.text = "";
                npcPanel.SetActive(false);
                playerName.text = npc.playerName;
                playerResponse.text = npc.playerDialogue[9];
                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTrackerNPC++;
                    curResponseTrackerPlayer++;
                }
            }
        }

        // Mom updates
        else if (curResponseTrackerPlayer == 4) {
            MomSpeaks(1);
        }

        // Mom updates again
        else if (curResponseTrackerPlayer == 5) {
            if (Input.GetKeyDown(KeyCode.Return)) {
            // Set text to next dialogue response
            npcDialogueText.text = npc.dialogue[2];
            npcName.text = npc.npcName;

            // Wait until user has finished reading and presses Enter
            if (Input.GetKeyDown(KeyCode.Return)) {
                curResponseTrackerPlayer++;
                curResponseTrackerNPC++;
            }
        }
        }

        // Adam updates
        else if (curResponseTrackerNPC == 6) {
           UpdateAdam(10);
        }

        // Anxiety question
        else if (anxietyQuestions == 2) {
            AnxietyQuestion(11);
        }

        // Adam updates again
        else if (curResponseTrackerNPC == 7) {
           if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                chapterScore += tempValue;
                clearAnxietyQuestions();
                playerResponse.text = npc.playerDialogue[14];

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTrackerNPC++;
                    curResponseTrackerPlayer++;
                }
            }
        }

        // Mom updates
        else if (curResponseTrackerPlayer == 8) {
            MomSpeaks(3);
        }

        //Anxiety question
        else if (anxietyQuestions == 3) {
            AnxietyQuestion(15);
        }
        
        // Mom updates
        else if (curResponseTrackerPlayer == 9) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                WalkSchoolTommy.chapterScore += tempValue;
                clearAnxietyQuestions();

                npcDialogueText.text = npc.dialogue[4];
                npcName.text = npc.npcName;

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTrackerNPC++;
                    curResponseTrackerPlayer++;
                }
            }
        }

        // Adam updates
        else if (curResponseTrackerNPC == 10) {
           UpdateAdam(18);
        }

        // Mom updates
        else if (curResponseTrackerPlayer == 11) {
            MomSpeaks(5);
        }

        // Adam updates
        else if (curResponseTrackerNPC == 12) {
           UpdateAdam(19);
        }

        // Mom updates
        else if (curResponseTrackerPlayer == 13) {
            MomSpeaks(6);
        }

        // Adam updates to conclude conversation
        else if (curResponseTrackerNPC == 14) {
            UpdateAdam(20);
            conversationFinished = true;
        }

        // End dialogue
        else if (Input.GetKeyDown(KeyCode.E) && isTalking == true && conversationFinished == true) {
            EndDialogue();
        }
    }

    // Method for showing Adam's dialogue
    void UpdateAdam(int value) {
        if (Input.GetKeyDown(KeyCode.Return)) {
            // Hide NPC Panel and text, show Adam's panel and text
            npcDialogueText.text = "";
            npcName.text = "";
            playerPanel.SetActive(true);
            npcPanel.SetActive(false);

            // Set text to next dialogue response
            playerResponse.text = npc.playerDialogue[value];
            playerName.text = npc.playerName;

            // Wait until user has finished reading and presses Enter
            if (Input.GetKeyDown(KeyCode.Return)) {
                curResponseTrackerPlayer++;
                curResponseTrackerNPC++;
            }
        }
    }

    // Method for showing Mom's dialogue
    void MomSpeaks(int value) {
        if (Input.GetKeyDown(KeyCode.Return)) {
            playerResponse.text = "";
            playerName.text = "";
            playerPanel.SetActive(false);
            npcPanel.SetActive(true);
            npcDialogueText.text = npc.dialogue[value];
            npcName.text = npc.npcName;

            if (Input.GetKeyDown(KeyCode.Return)) {
                curResponseTrackerNPC++;
                curResponseTrackerPlayer++;
            }
        }
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

    void StartConversation() {
        dialogueUI.SetActive(true);
        clearAnxietyQuestions();
        npcName.text = "";
        npcDialogueText.text = "";
        chapterScore = 0;
        curResponseTrackerNPC = 0;
        curResponseTrackerPlayer = 0;
        npcPanel.SetActive(false);
        isTalking = true;
        playerName.text = "";
        playerResponse.text = npc.playerDialogue[0];
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

    public void onClickRestart() {
        curResponseTrackerNPC = 0;
        curResponseTrackerPlayer = 0;
        anxietyQuestions = 0;
        chapterScore = 0;
        buttonWasClicked = false;
        SceneManager.LoadScene("MomDance");
    }

    void EndDialogue() {
        isTalking = false;
        dialogueUI.SetActive(false);
        Debug.Log("Current Chapter Score: " + chapterScore);
        cam1.SetActive(false);
        cam2.SetActive(true);
        adam2.SetActive(true);
        adam.SetActive(false);
        npcCharacter.SetActive(false);

    }
}