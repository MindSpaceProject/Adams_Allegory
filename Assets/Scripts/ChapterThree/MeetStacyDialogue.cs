using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MeetStacyDialogue : MonoBehaviour
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

        // Stacy updates
        else if (curResponseTrackerPlayer == 1) {
            StacySpeaks(1);
        }

        // Adam updates
        else if (curResponseTrackerNPC == 2) {
            AdamSpeaks(1);
        }

        // Stacy updates
        else if (curResponseTrackerPlayer == 3) {
            StacySpeaks(2);
        }


        // Adam updates
        else if (curResponseTrackerNPC == 4) {
            AdamSpeaks(2);
        }

        // Stacy updates
        else if (curResponseTrackerPlayer == 5) {
            StacySpeaks(3);
        }

        // Adam updates
        else if (curResponseTrackerNPC == 6) {
            AdamSpeaks(3);
        }

        // Stacy updates
        else if (curResponseTrackerPlayer == 7) {
            StacySpeaks(4);
        }

        // Stacy updates again
        else if (curResponseTrackerPlayer == 8) {
            if (Input.GetKeyDown(KeyCode.Return)) {
            // Set text to next dialogue response
            npcDialogueText.text = npc.dialogue[5];
            npcName.text = npc.npcName;

            // Wait until user has finished reading and presses Enter
            if (Input.GetKeyDown(KeyCode.Return)) {
                curResponseTrackerPlayer++;
                curResponseTrackerNPC++;
            }
        }
        }

        //anxiety question
        else if (anxietyQuestions == 4) {
            AnxietyQuestion(4);
        }

        // Adam updates
        else if (curResponseTrackerNPC == 9) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                WalkSchoolTommy.chapterScore += tempValue;
                clearAnxietyQuestions();
                AdamSpeaks(7);
            }
        }

        // Stacy updates
        else if (curResponseTrackerPlayer == 10) {
            StacySpeaks(6);
        }

        // Adam updates
        else if (curResponseTrackerNPC == 11) {
            AdamSpeaks(8);
        }

        // Adam updates to conclude conversation
        else if (curResponseTrackerNPC == 12) {
            if (Input.GetKeyDown(KeyCode.Return)) {
            // Set text to next dialogue response
            playerResponse.text = npc.playerDialogue[9];
            playerName.text = npc.playerName;

            // Wait until user has finished reading and presses Enter
            if (Input.GetKeyDown(KeyCode.Return)) {
                curResponseTrackerPlayer++;
                curResponseTrackerNPC++;
            }
        }
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
        playerName.text = "";
        playerResponse.text = "";
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

    void EndDialogue() {
        isTalking = false;
        dialogueUI.SetActive(false);
        Debug.Log("Current Chapter Score: " + WalkSchoolTommy.chapterScore);
        SceneManager.LoadScene("Gym");
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
