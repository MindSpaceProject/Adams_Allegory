using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StacyCafeDialogue : MonoBehaviour
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
    public GameObject adam1;
    public GameObject adam2;


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
        
        cam1.SetActive(true);
        cam2.SetActive(false);
        adam1.SetActive(true);
        adam2.SetActive(false);
        
        dialogueUI.SetActive(true); 

        clearAnxietyQuestions();
        npcName.text = "";
        npcDialogueText.text = "";
        curResponseTrackerNPC = 0;
        curResponseTrackerPlayer = 0;
        showHidePanel(npcPanel);
        isTalking = true;
        playerName.text = npc.playerName;
        playerResponse.text = npc.playerDialogue[0];      
    }

    void OnMouseOver() {
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

        // Stacy updates
        else if (curResponseTrackerPlayer == 1) {
            StacySpeaks(0);
        }

        // Adam updates
        else if (curResponseTrackerNPC == 2) {
            AdamSpeaks(2);
        }

        // Stacy updates
        else if (curResponseTrackerPlayer == 3) {
            StacySpeaks(1);
        }

        // Adam updates
        else if (curResponseTrackerNPC == 4) {
            AdamSpeaks(3);
        }

        // Stacy updates
        else if (curResponseTrackerPlayer == 5) {
            StacySpeaks(2);
        }

        // Adam updates
        else if (curResponseTrackerNPC == 6) {
            AdamSpeaks(4);
        }

        // Stacy updates
        else if (curResponseTrackerPlayer == 7) {
            StacySpeaks(3);
        }

        //anxiety question
        else if (anxietyQuestions == 3) {
            AnxietyQuestion(5);
        }

        // Stacy updates again
        else if (curResponseTrackerPlayer == 8) {
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
        else if (curResponseTrackerNPC == 9) {
            AdamSpeaks(8);
        }

        // Stacy updates
        else if (curResponseTrackerPlayer == 10) {
            StacySpeaks(5);
        }

        // Stacy updates again
        else if (curResponseTrackerPlayer == 11) {
        if (Input.GetKeyDown(KeyCode.Return)) {
            // Set text to next dialogue response
            npcDialogueText.text = npc.dialogue[6];
            npcName.text = npc.npcName;

            // Wait until user has finished reading and presses Enter
            if (Input.GetKeyDown(KeyCode.Return)) {
                curResponseTrackerPlayer++;
                curResponseTrackerNPC++;
            }
        }
    }

    //anxiety question
        else if (anxietyQuestions == 5) {
            AnxietyQuestion(9);
        }

        // Stacy updates again
        else if (curResponseTrackerPlayer == 12) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                WalkSchoolTommy.chapterScore += tempValue;
                clearAnxietyQuestions();

                npcDialogueText.text = npc.dialogue[7];
                npcName.text = npc.npcName;

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTrackerNPC++;
                    curResponseTrackerPlayer++;
                }
            }
        }

        // Adam updates
        else if (curResponseTrackerNPC == 13) {
            AdamSpeaks(12);
        }

        // Stacy updates
        else if (curResponseTrackerPlayer == 14) {
            StacySpeaks(8);
        }

        // Adam updates
        else if (curResponseTrackerNPC == 15) {
            AdamSpeaks(13);
        }

        // Stacy updates
        else if (curResponseTrackerPlayer == 16) {
            StacySpeaks(9);
        }

        // Adam updates to conclude conversation
        else if (curResponseTrackerNPC == 17) {
            AdamSpeaks(14);
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

    // Method for showing Stacy's dialogue
    void StacySpeaks(int value) {
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

    void EndDialogue() {
        isTalking = false;
        dialogueUI.SetActive(false);
        Debug.Log("Final Chapter Score: " + WalkSchoolTommy.chapterScore);
        ChapterTransition.chapter = 4;
        SceneManager.LoadScene("ChapterTransition");
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