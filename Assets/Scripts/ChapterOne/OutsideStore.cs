using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class OutsideStore : MonoBehaviour {
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

        // Mom updates
        if (curResponseTrackerPlayer == 0 && isTalking == true) {
            NPCSpeaks(0, true);
        }

        // Tommy's mom updates
        else if (curResponseTrackerPlayer == 1) {
            if (Input.GetKeyDown(KeyCode.Return)) {
                npcDialogueText.text = npc.dialogue[1];
                npcName.text = npc.npcName2;
                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTrackerNPC++;
                    curResponseTrackerPlayer++;
                }
            }
        }

        // Adam updates
        else if (curResponseTrackerNPC == 2) {
            AdamSpeaks(1);
        }

        // Mom updates
        else if (curResponseTrackerPlayer == 3) {
            NPCSpeaks(2, true);
        }

        // Adam updates
        else if (curResponseTrackerNPC == 4) {
            AdamSpeaks(2);
        }

        // Tommy's mom updates
        else if (curResponseTrackerPlayer == 5) {
            NPCSpeaks(3, false);
        }
        
        // Adam updates
        else if (curResponseTrackerNPC == 6) {
            AdamSpeaks(3);
        }

        // Anxiety question
        else if (anxietyQuestions == 3) {
            AnxietyQuestion(4);
        }

        // Adam updates
        else if (curResponseTrackerNPC == 7) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                AdamRoomDialogue.chapterScore += tempValue;
                clearAnxietyQuestions();
                playerResponse.text = npc.playerDialogue[7];


                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTrackerPlayer++;
                    curResponseTrackerNPC++;
                }
            }
        }

        // Mom updates
        else if (curResponseTrackerPlayer == 8) {
            NPCSpeaks(4, true);
        }

        // Tommy's mom updates
        else if (curResponseTrackerPlayer == 9) {
            if (Input.GetKeyDown(KeyCode.Return)) {
                npcDialogueText.text = npc.dialogue[5];
                npcName.text = npc.npcName2;
                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTrackerNPC++;
                    curResponseTrackerPlayer++;
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

    // Method for showing NPC dialogue
    void NPCSpeaks(int value, bool adamMom) {
        if (Input.GetKeyDown(KeyCode.Return)) {
            playerResponse.text = "";
            playerName.text = "";
            showHidePanel(playerPanel);
            showHidePanel(npcPanel);
            npcDialogueText.text = npc.dialogue[value];
            if (adamMom) {
            npcName.text = npc.npcName;
            } else {
               npcName.text = npc.npcName2; 
            }

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

    void StartConversation() {
        isTalking = true;
        curResponseTrackerNPC = 0;
        dialogueUI.SetActive(true);
        clearAnxietyQuestions();
        npcDialogueText.text = "";
        npcName.text = "";
        showHidePanel(npcPanel);
        playerName.text = npc.playerName;
        playerResponse.text = npc.playerDialogue[0];
    }

    // Calculating anxiety responses
    public void onClickResponseOne() {
        Debug.Log("Anxiety Response Option 1 was clicked.");
        tempValue = 2;
        buttonWasClicked = true;
    }

    public void onClickResponseTwo() {
        Debug.Log("Anxiety Response Option 2 was clicked.");
        tempValue = 1;
        buttonWasClicked = true;
    }

    public void onClickResponseThree() {
        Debug.Log("Anxiety Response Option 3 was clicked.");
        tempValue = 0;
        buttonWasClicked = true;
    }

    void EndDialogue() {
        isTalking = false;
        dialogueUI.SetActive(false);
<<<<<<< HEAD
        SceneManager.LoadScene("LaterThatNight");
=======
        SceneManager.LoadScene("AdamRoom"); // Change this to nightmare scene with minigame later
>>>>>>> f8d1914b4d75aebfa9aa5c3401a882091b087d54
        Debug.Log("Current Chapter Score: " + AdamRoomDialogue.chapterScore);
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