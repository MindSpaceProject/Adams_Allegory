using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AdamWakesUp : MonoBehaviour {
    public NPC npc;
    bool isTalking = false;
    bool conversationFinished = false; 
    float curResponseTrackerNPC = 0;
    float anxietyQuestions = 0;

    // UI Game Objects
    public GameObject dialogueUI;
    public GameObject npcPanel;
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
            UpdateAdam(1);
        }

        // Anxiety question
        else if (anxietyQuestions == 1) {
            AnxietyQuestion(2);
        }

        // Adam updates
        else if (curResponseTrackerNPC == 1) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                AdamRoomDialogue.chapterScore += tempValue;
                clearAnxietyQuestions();
                playerResponse.text = npc.playerDialogue[5];

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTrackerNPC++;
                }
            }
        }

        // Anxiety question
        else if (anxietyQuestions == 2) {
            AnxietyQuestion(6);
        }

        // Ending chapter dialogue
        else if (curResponseTrackerNPC == 2) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                AdamRoomDialogue.chapterScore += tempValue;
                clearAnxietyQuestions();
                playerResponse.text = npc.playerDialogue[9];

                if (Input.GetKeyDown(KeyCode.Return)) {
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

    // Method for updating Adam's dialogue
    void UpdateAdam(int value) {
        if (Input.GetKeyDown(KeyCode.Return)) {
            // Set text to next dialogue response
            playerResponse.text = npc.playerDialogue[value];
            playerName.text = npc.playerName;

            // Wait until user has finished reading and presses Enter
            if (Input.GetKeyDown(KeyCode.Return)) {
                curResponseTrackerNPC++;
                anxietyQuestions++;
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

    void StartConversation() {
        dialogueUI.SetActive(true);
        npcName.text = "";
        npcDialogueText.text = "";
        showHidePanel(npcPanel);
        clearAnxietyQuestions();
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
        Debug.Log("Final Chapter Score: " + AdamRoomDialogue.chapterScore);
<<<<<<< HEAD
        ChapterTransition.chapter = 2;
        SceneManager.LoadScene("ChapterTransition");
=======
>>>>>>> f8d1914b4d75aebfa9aa5c3401a882091b087d54
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