using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AdamInStore : MonoBehaviour {
    public NPC npc;
    bool isTalking = false;
    bool conversationFinished = false;
    bool talkToClerk = false;
    bool ignoreClerk = false;    
    float curResponseTrackerNPC = 0;
    float anxietyQuestions = 0;
    float userChoice = 0;

    // UI Game Objects
    public GameObject dialogueUI;
    public GameObject npcPanel;
    public GameObject playerPanel1;
    public GameObject playerPanel2;
    public GameObject playerPanel3;
    public GameObject playerPanel4;
    public GameObject playerPanel5;
    public GameObject capsule1;


    // UI Text References
    public Text playerName;
    public Text npcName;
    public Text npcDialogueText;
    public Text playerResponse;
    public Text playerResponse1;
    public Text playerResponse2;
    public Text playerResponse3;
    public Text playerResponse4;
    public Text playerResponse5;

    // Cameras
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;

    // Anxiety Question Buttons
    public Button btn;
    public Button btn2;
    public Button btn3;
    public Button btn4;
    public Button btn5;
    public int tempValue = 0; // Keep track of temp chapter score value
    bool buttonWasClicked = false;

    // Start is called before the first frame update
    void Start() {
        cam1.SetActive(false); // Main camera for shopping
        cam2.SetActive(true); // Camera for first walking in cutscene
        cam3.SetActive(false); // Camera for adam done shopping
        cam4.SetActive(false); // store clerk cutscene
        
        dialogueUI.SetActive(false);
    }

    void OnMouseOver() {
        // Trigger dialogue
        if (Input.GetKeyDown(KeyCode.E) && isTalking == false) {
            StartConversation();
        }

        // Adam looks for Parents (Remove Adam's name)
        if (curResponseTrackerNPC == 0 && isTalking == true) {
            if (Input.GetKeyDown(KeyCode.Return)) {
            // Set text to next dialogue response

            playerResponse.text = npc.playerDialogue[1];
            playerName.text = "";

            // Wait until user has finished reading and presses Enter
            if (Input.GetKeyDown(KeyCode.Return)) {
                curResponseTrackerNPC++;
                anxietyQuestions++;
            }
        }
        }

        else if (curResponseTrackerNPC == 1) {
            UpdateAdam(2);
        }

        else if (curResponseTrackerNPC == 2) {
            UpdateAdam(3);
        }

        // Anxiety question
        else if (anxietyQuestions == 3) {
            AnxietyQuestion(4);
        }

        // Adam updates
        else if (curResponseTrackerNPC == 3) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                AdamRoomDialogue.chapterScore += tempValue;
                clearAnxietyQuestions();
                playerResponse.text = npc.playerDialogue[7];

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTrackerNPC++;
                }
            }
        }

        // Adam updates
        else if (curResponseTrackerNPC == 4) {
            UpdateAdam(8);
        }

        // Adam updates
        else if (curResponseTrackerNPC == 5) {
            UpdateAdam(9);
        }

        // Anxiety question
        else if (anxietyQuestions == 6) {
            AnxietyQuestion(10);
        }

        // Adam updates
        else if (curResponseTrackerNPC == 6) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                AdamRoomDialogue.chapterScore += tempValue;
                clearAnxietyQuestions();
                playerResponse.text = npc.playerDialogue[13];

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTrackerNPC++;
                }
            }
        }

        else if (userChoice == 0 && isTalking == true) {
            addTwoButtons(14);
        }

        // After user has made choice
        else if (userChoice == 1) {
            
            // If user doesn't want to speak to Store clerk
            if (Input.GetKeyDown(KeyCode.Return) && ignoreClerk == true) {
                userChoice++;
                removeTwoButtons();
                UpdateAdam(16);
                conversationFinished = true;
            }

            // If use wants to speak to store clerk
            else if (Input.GetKeyDown(KeyCode.Return) && talkToClerk == true) {
                // Show camera between clerk and Adam
                userChoice++;
                removeTwoButtons();
                dialogueUI.SetActive(false);
                cam3.SetActive(false);
                cam4.SetActive(true);
            }
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

    // Method for adding two buttons
    void addTwoButtons(int value) {
        if (Input.GetKeyDown(KeyCode.Return)) {
            showHidePanel(playerPanel4);
            showHidePanel(playerPanel5);
            playerResponse4.text = npc.playerDialogue[value];
            playerResponse5.text = npc.playerDialogue[value + 1];
            btn4.interactable = true;
            btn5.interactable = true;
            if (Input.GetKeyDown(KeyCode.Return)) {
                userChoice++;
            }
        }
    }

    // Method for clearing two buttons
    void removeTwoButtons() {
        btn4.interactable = false;
        btn5.interactable = false;
        playerResponse4.text = "";
        playerResponse5.text = "";
        showHidePanel(playerPanel4);
        showHidePanel(playerPanel5);
    }
    void StartConversation() {
        dialogueUI.SetActive(true);
        npcName.text = "";
        npcDialogueText.text = "";
        npcPanel.SetActive(false);
        clearAnxietyQuestions();
        removeTwoButtons();
        isTalking = true;
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
    public void onClickSpeakToClerk() {
        Debug.Log("User chose to speak to store clerk.");
        talkToClerk = true;
        ignoreClerk = false;
    }

    public void onClickIgnoreClerk() {
        Debug.Log("User chose to ignore store clerk.");
        ignoreClerk = true;
        talkToClerk = false;
    }

    void EndDialogue() {
        isTalking = false;
        dialogueUI.SetActive(false);
        SceneManager.LoadScene("GroceryStore");
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