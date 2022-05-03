using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AdamPlaysGame : MonoBehaviour {
    public NPC npc;
    bool isTalking = false;
    bool conversationFinished = false; 
    public static float curResponseTrackerNPC = 0;
    public static float curResponseTrackerPlayer = 0;
    float anxietyQuestions = 0;
    public GameObject npcCharacter;
    public GameObject adam1;
    public GameObject adam2;

    // UI Game Objects
    public GameObject dialogueUI;
    public GameObject npcPanel;
    public GameObject playerPanel;
    public GameObject playerPanel1;
    public GameObject playerPanel2;
    public GameObject playerPanel3;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject AdamsMom;

    // UI Text References
    public Text playerName;
    public Text npcName;
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
    public static bool gameFinished = false;
    public static int chapterScore = 0; // Keep track of chapter score

    // Start is called before the first frame update
    void Start() {
        AdamsMom.SetActive(false);

        if(gameFinished) {
            isTalking = true;
            curResponseTrackerPlayer = 2;
            curResponseTrackerNPC = 2;
            anxietyQuestions = 1;
            npcCharacter.SetActive(true);
            cam1.SetActive(true);
            cam2.SetActive(false);
            adam1.SetActive(true);
            adam2.SetActive(false);

            // Continue conversation
            dialogueUI.SetActive(true);
            clearAnxietyQuestions();
            npcName.text = "";
            npcDialogueText.text = "";
            showHidePanel(npcPanel);
            playerName.text = npc.playerName;
            AdamsMom.SetActive(true);
            playerResponse.text = "Well that was fun..";

        } else {

        cam1.SetActive(true);
        cam2.SetActive(false);
        adam1.SetActive(true);
        adam2.SetActive(false);
        dialogueUI.SetActive(false);
        npcCharacter.SetActive(false);
        }
    }

    void OnMouseOver() {
        // Trigger dialogue
        if (Input.GetKeyDown(KeyCode.E) && isTalking == false) {
            StartConversation();
        }

        // Anxiety question
        if (anxietyQuestions == 0 && isTalking == true) {
            AnxietyQuestion(1);
        }

        // Adam updates
        else if (curResponseTrackerNPC == 0) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                chapterScore += tempValue;
                clearAnxietyQuestions();
                playerResponse.text = npc.playerDialogue[4];

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTrackerNPC++;
                    curResponseTrackerPlayer++;
                }
            }
        }

        else if (curResponseTrackerNPC == 1) {
            if (Input.GetKeyDown(KeyCode.Return)) {
            // TODO: Adam walks to game console
            cam1.SetActive(false);
            cam2.SetActive(true); 
            adam1.SetActive(false);
            adam2.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return)) {
            // Scene transition to shooting game
            }
            }
        }

        // Mom Updates
        else if (curResponseTrackerPlayer == 2 && gameFinished == true) {
            MomSpeaks(0);
        }

        // Adam Updates
        else if (curResponseTrackerNPC == 3) {
            UpdateAdam(5);
        }

        // Adam updates
        else if (curResponseTrackerNPC == 4) {
            if (Input.GetKeyDown(KeyCode.Return)) {
            // Set text to next dialogue response
            playerResponse.text = npc.playerDialogue[6];
            playerName.text = npc.playerName;

            // Wait until user has finished reading and presses Enter
            if (Input.GetKeyDown(KeyCode.Return)) {
                curResponseTrackerPlayer++;
                curResponseTrackerNPC++;
            }
        }
        }

        // Mom updates
        else if (curResponseTrackerPlayer == 5) {
            MomSpeaks(1);
        }

        // Adam updates
        else if (curResponseTrackerNPC == 6) {
            UpdateAdam(7);
        }

        // Mom updates
        else if (curResponseTrackerPlayer == 7) {
            MomSpeaks(2);
        }

        // Anxiety question
        else if (anxietyQuestions == 3) {
            AnxietyQuestion(8);
        }

        // Adam updates
        else if (curResponseTrackerNPC == 8) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                chapterScore += tempValue;
                clearAnxietyQuestions();
                npcDialogueText.text = "";
                npcName.text = "";
                showHidePanel(playerPanel);
                showHidePanel(npcPanel);
                playerResponse.text = npc.playerDialogue[11];
                playerName.text = npc.playerName;

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTrackerNPC++;
                    curResponseTrackerPlayer++;
                }
            }
        }

        // Mom updates
        else if (curResponseTrackerPlayer == 9) {
            MomSpeaks(3);
        }

        // Mom updates
        else if (curResponseTrackerPlayer == 10) {
           if (Input.GetKeyDown(KeyCode.Return)) {
            // Set text to next dialogue response
            npcDialogueText.text = npc.dialogue[4];
            npcName.text = npc.npcName;

            // Wait until user has finished reading and presses Enter
            if (Input.GetKeyDown(KeyCode.Return)) {
                curResponseTrackerPlayer++;
                curResponseTrackerNPC++;
            }
        }
        }

        // Adam updates
        else if (curResponseTrackerNPC == 11) {
            UpdateAdam(12);
        }

        // Mom updates and dialogue ends
        else if (curResponseTrackerPlayer == 12) {
            MomSpeaks(5);
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

    // Method for showing Mom's dialogue
    void MomSpeaks(int value) {
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
        showHidePanel(npcPanel);
        isTalking = true;
        playerName.text = npc.playerName;
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

    void EndDialogue() {
        isTalking = false;
        dialogueUI.SetActive(false);
        Debug.Log("Current Chapter Score: " + chapterScore);
        SceneManager.LoadScene("Kitchen");
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