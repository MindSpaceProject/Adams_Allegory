using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AdamRoomDialogue : MonoBehaviour {
    public NPC npc;
    bool isTalking = false;
    bool conversationFinished = false;
    float curResponseTrackerNPC = 0;
    float curResponseTrackerPlayer = 0;
    float anxietyQuestions = 0;

    // UI Game Objects
    public GameObject dialogueUI;
    public GameObject npcCharacter;
    public GameObject playerCharacter;
    public GameObject npcPanel;
    public GameObject playerPanel;
    public GameObject playerPanel1;
    public GameObject playerPanel2;
    public GameObject playerPanel3;
    public GameObject capsule;
    public GameObject capsule2;
    
    // Cameras
    public GameObject cam1;
    public GameObject cam2;
    public static bool cameraChange = false;

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
        if(cameraChange) {
            cam1.SetActive(false);
            cam2.SetActive(true);
            dialogueUI.SetActive(false);
            capsule2.SetActive(true);
            capsule.SetActive(false);
            npcCharacter.SetActive(false);
            playerCharacter.SetActive(false);
            cameraChange = false;
        } else {
            cam1.SetActive(true);
            cam2.SetActive(false);
            dialogueUI.SetActive(false);
            capsule2.SetActive(false);
            capsule.SetActive(true);
            BeginningDialogue();
            
        }  
    }

    void OnMouseOver() {
        // Trigger dialogue
        if (Input.GetKeyDown(KeyCode.E) && isTalking == false) {
            // Adams Mom should walk in here
            StartConversation();
        }

        // Adam updates
        if (curResponseTrackerNPC == 0 && isTalking == true) {
            AdamSpeaks(0);
        }

        // Anxiety question
        else if (anxietyQuestions == 1) {
            AnxietyQuestion(1);
        }

        // Adam updates
        else if (curResponseTrackerNPC == 1) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                chapterScore += tempValue;
                clearAnxietyQuestions();
                playerResponse.text = npc.playerDialogue[4];

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTrackerPlayer++;
                    curResponseTrackerNPC++;
                }
            }
        }

        // Mom updates
        else if (curResponseTrackerPlayer == 2) {
            MomSpeaks(1);
        }

        // Adam updates
        else if (curResponseTrackerNPC == 3) {
            AdamSpeaks(5);
        }

        // Mom updates
        else if (curResponseTrackerPlayer == 4) {
            MomSpeaks(2);
        }

        // Adam updates
        else if (curResponseTrackerNPC == 5) {
            AdamSpeaks(6);
        }

        // Anxiety Question
        else if (anxietyQuestions == 4) {
            AnxietyQuestion(7);
        }

        // Mom updates
        else if (curResponseTrackerPlayer == 6) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                chapterScore += tempValue;
                clearAnxietyQuestions();
                MomSpeaks(3);
            }
        }
        // Anxiety question
        else if (anxietyQuestions == 5) {
            AnxietyQuestion(10);
        }

        // Mom updates
        else if (curResponseTrackerPlayer == 7) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                chapterScore += tempValue;
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
        else if (curResponseTrackerNPC == 8) {
            AdamSpeaks(13);
        }

        // Mom updates to conclude conversation
        else if (curResponseTrackerPlayer == 9) {
            MomSpeaks(5);
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

    void BeginningDialogue() {
        dialogueUI.SetActive(true);
        clearAnxietyQuestions();
        npcDialogueText.text = "";
        npcName.text = "";
        showHidePanel(npcPanel);
        playerName.text = npc.playerName;
        playerResponse.text = npc.playerDialogue[14];
    }

    void StartConversation() {
        isTalking = true;
        curResponseTrackerNPC = 0;
        chapterScore = 0;
        playerResponse.text = "";
        playerName.text = "";
        showHidePanel(playerPanel);
        showHidePanel(npcPanel);
        npcName.text = npc.npcName;
        npcDialogueText.text = npc.dialogue[0];
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
        cameraChange = true;
        SceneManager.LoadScene("Transition");
        Debug.Log("Current Chapter Score: " + chapterScore);
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