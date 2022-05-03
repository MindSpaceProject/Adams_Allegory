using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TommyGym : MonoBehaviour
{
    public NPC npc;
    bool isTalking = false;
    bool conversationFinished = false;
    float curResponseTrackerNPC = 0;
    float curResponseTrackerPlayer = 0;
    float anxietyQuestions = 0;

    // UI Game Objects
    public GameObject dialogueUI;
    public GameObject npcPanel;
    public GameObject playerPanel;
    public GameObject playerPanel1;
    public GameObject playerPanel2;
    public GameObject playerPanel3;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject npcCharacter;
    public GameObject npcCharacter1;
    public GameObject playerCharacter;
    public GameObject playerCharacter1;
    public GameObject miniGame;
    public GameObject tutorialScreen;

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
    public int tempValue = 0; // Keep track of temp chapter score value
    bool buttonWasClicked = false;

    // Start is called before the first frame update
    void Start() {
        dialogueUI.SetActive(false); 
        tutorialScreen.SetActive(false);
        cam1.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);
        npcCharacter1.SetActive(false);
        playerCharacter1.SetActive(false);
        miniGame.SetActive(false);      
        
    }

    void OnMouseOver() {
        // Trigger dialogue
        if (Input.GetKeyDown(KeyCode.E) && isTalking == false) {
            StartConversation();
        }

        // Adam updates
        if (curResponseTrackerNPC == 0 && isTalking == true) {
            AdamSpeaks(0);
        }

        // Tommy updates
        else if (curResponseTrackerPlayer == 1) {
            TommySpeaks(1);
        }

        //anxiety question
        else if (anxietyQuestions == 1) {
            AnxietyQuestion(1);
        }

        // Tommy updates manually no score
        else if (curResponseTrackerPlayer == 2) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                clearAnxietyQuestions();
                npcDialogueText.text = npc.dialogue[2];
                npcName.text = npc.npcName;

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTrackerNPC++;
                    curResponseTrackerPlayer++;
                }
            }   
        }

        // Adam updates
        else if (curResponseTrackerNPC == 3) {
            AdamSpeaks(4);
        }

        // Tommy updates
        else if (curResponseTrackerPlayer == 4) {
            TommySpeaks(3);
        }

        //anxiety question
        else if (anxietyQuestions == 3) {
            AnxietyQuestion(5);
        }

        // Adam updates add score
        else if (curResponseTrackerNPC == 5) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                WalkSchoolTommy.chapterScore += tempValue;
                clearAnxietyQuestions();
                AdamSpeaks(8);
            }
        }

        // Tommy updates
        else if (curResponseTrackerPlayer == 6) {
            TommySpeaks(4);
        }

        //anxiety question
        else if (anxietyQuestions == 5) {
            AnxietyQuestion(9);
        }

        // Tommy updates again, do calculation
        else if (curResponseTrackerPlayer == 7) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                WalkSchoolTommy.chapterScore += tempValue;
                clearAnxietyQuestions();

                npcDialogueText.text = npc.dialogue[5];
                npcName.text = npc.npcName;

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTrackerNPC++;
                    curResponseTrackerPlayer++;
                }
            }
        }

        // Adam updates to conclude conversation
        else if (curResponseTrackerNPC == 8) {
            AdamSpeaks(12);
            conversationFinished = true;
        }
        
        // End dialogue
        else if (Input.GetKeyDown(KeyCode.E) && isTalking == true && conversationFinished == true) {
            EndDialogue();
        }
    }

    // Method for showing Adam's dialogue
    void AdamSpeaks(int value) {
        if (Input.GetKeyDown(KeyCode.Return)) {
            // Hide NPC Panel and text, show Adam's panel and text
            npcDialogueText.text = "";
            npcName.text = "";
            showHidePanel(playerPanel);
            showHidePanel(npcPanel);

            // Set text to next dialogue response
            playerResponse.text = npc.playerDialogue[value];
            playerName.text = npc.playerName;

            // Wait until user has finished reading and presses Enter
            if (Input.GetKeyDown(KeyCode.Return)) {
                curResponseTrackerPlayer++;
                curResponseTrackerNPC++;
                anxietyQuestions++;
            }
        }
    }

    // Method for showing Tommy's dialogue
    void TommySpeaks(int value) {
        if (Input.GetKeyDown(KeyCode.Return)) {
            playerResponse.text = "";
            playerName.text = "";
            showHidePanel(playerPanel);
            showHidePanel(npcPanel);
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
            buttonWasClicked = false;
            showHidePanel(playerPanel1);
            showHidePanel(playerPanel2);
            showHidePanel(playerPanel3);
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
        showHidePanel(playerPanel1);
        showHidePanel(playerPanel2);
        showHidePanel(playerPanel3);
    }

    void StartConversation() {
        dialogueUI.SetActive(true);
        clearAnxietyQuestions();
        playerName.text = "";
        playerResponse.text = "";
        showHidePanel(playerPanel);
        curResponseTrackerNPC = 0;
        curResponseTrackerPlayer = 0;
        isTalking = true;
        npcName.text = npc.npcName;
        npcDialogueText.text = npc.dialogue[0];
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

    //method to cue the tutorial screen and activate minigame upon clicking the button
    public void onClickTutorial(){
        Debug.Log("Tutorial finished");
        tutorialScreen.SetActive(false);
        miniGame.SetActive(true);
    }
    void EndDialogue() {
        isTalking = false;
        dialogueUI.SetActive(false);
        Debug.Log("Current Chapter Score: " + WalkSchoolTommy.chapterScore);
    // switch cameras and reactivate minigame
        cam1.SetActive(false);
        cam2.SetActive(true);
        tutorialScreen.SetActive(true);
    }

    public static void showHidePanel(GameObject gameObject) {
        var getCanvasGroup = gameObject.GetComponent<CanvasGroup>();
        if (getCanvasGroup.alpha == 0) {
            getCanvasGroup.alpha = 1;
            getCanvasGroup.interactable = true;

        } else {
            getCanvasGroup.alpha = 0;
            getCanvasGroup.interactable = false;
        }
    }
}