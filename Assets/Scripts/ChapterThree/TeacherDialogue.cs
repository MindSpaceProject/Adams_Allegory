using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeacherDialogue : MonoBehaviour
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
    public GameObject capsule;
    public GameObject capsule2;
    public GameObject adam;
    public GameObject adam2;
    
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
    public int tempValue = 0; // Keep track of temp chapter score value
    bool buttonWasClicked = false;

    // Start is called before the first frame update
    void Start() {
        cam1.SetActive(true);
        cam2.SetActive(false);
        adam2.SetActive(false);
        dialogueUI.SetActive(false);
        capsule.SetActive(true);
            
    }

    void OnMouseOver() {
        // Trigger dialogue
        if (Input.GetKeyDown(KeyCode.E) && isTalking == false) {
            StartConversation();
        }

        // Teacher updates
        if (curResponseTrackerPlayer == 0 && isTalking == true) {
            TeacherSpeaks(0);
        }

        // Adam updates
        else if (curResponseTrackerPlayer == 1) {
            AdamSpeaks(1);
        }

        // Teacher updates
        else if (curResponseTrackerPlayer == 2) {
            TeacherSpeaks(1);
        }

        // Teacher updates again
        else if (curResponseTrackerPlayer == 3) {
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

        // adam dialogue
        else if (curResponseTrackerPlayer == 4) {
            AdamSpeaks(2);
        }

        // anxiety question
        else if (anxietyQuestions == 2) {
            AnxietyQuestion(3);
        }

        // Teacher updates
        else if (curResponseTrackerPlayer == 5) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                WalkSchoolTommy.chapterScore += tempValue;
                clearAnxietyQuestions();
                TeacherSpeaks(3);
            }
            
        }

        // anxiety question with no calculation
        else if (anxietyQuestions == 3) {
            AnxietyQuestion(6);
        }


        // update teacher no calculation!!!
        else if (curResponseTrackerPlayer == 6) {
        if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                clearAnxietyQuestions();

                npcDialogueText.text = npc.dialogue[4];
                npcName.text = npc.npcName;

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTrackerNPC++;
                    curResponseTrackerPlayer++;
                }
            }
        }

        // adam updates
        else if (curResponseTrackerPlayer == 7) {
            AdamSpeaks(9);
        }

        // Teacher updates
        else if (curResponseTrackerPlayer == 8) {
            TeacherSpeaks(5);
        }

        // adam updates
        else if (curResponseTrackerPlayer == 9) {
            AdamSpeaks(10);
        }

        // anxiety question
        else if (anxietyQuestions == 6) {
            AnxietyQuestion(11);
        }

        // Teacher updates
        else if (curResponseTrackerPlayer == 10) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                WalkSchoolTommy.chapterScore += tempValue;
                clearAnxietyQuestions();
                TeacherSpeaks(6);
            }
        }

        // adam updates
        else if (curResponseTrackerPlayer == 11) {
            AdamSpeaks(14);
        }

        // Teacher updates
        else if (curResponseTrackerPlayer == 12) {
            TeacherSpeaks(7);
        }

        // adam updates
        else if (curResponseTrackerPlayer == 13) {
            AdamSpeaks(15);
        }

        // Teacher updates
        else if (curResponseTrackerPlayer == 14) {
            TeacherSpeaks(8);
        }

        // anxiety question
        else if (anxietyQuestions == 9) {
            AnxietyQuestion(16);
        }

        // Teacher updates
        else if (curResponseTrackerPlayer == 15) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                WalkSchoolTommy.chapterScore += tempValue;
                clearAnxietyQuestions();

                npcDialogueText.text = npc.dialogue[9];
                npcName.text = npc.npcName;

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTrackerNPC++;
                    curResponseTrackerPlayer++;
                }
            }
        }

        // adam updates
        else if (curResponseTrackerPlayer == 16) {
            AdamSpeaks(19);
        }

        // Teacher updates
        else if (curResponseTrackerPlayer == 17) {
            TeacherSpeaks(10);
        }

        // Teacher updates to conclude dialogue
        else if (curResponseTrackerPlayer == 18) {
            if (Input.GetKeyDown(KeyCode.Return)) {
            // Set text to next dialogue response
            npcDialogueText.text = npc.dialogue[11];
            npcName.text = npc.npcName;

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

    // Method for showing Teacher's dialogue
    void TeacherSpeaks(int value) {
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
        npcName.text = "";
        npcDialogueText.text = "";
        curResponseTrackerNPC = 0;
        curResponseTrackerPlayer = 0;
        showHidePanel(npcPanel);
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

    void EndDialogue() {
        dialogueUI.SetActive(false);
        cam1.SetActive(false);
        cam2.SetActive(true);
        dialogueUI.SetActive(false);
        capsule.SetActive(false);
        capsule2.SetActive(true);
        adam2.SetActive(true);
        adam.SetActive(false);
        Debug.Log("Current Chapter Score: " + WalkSchoolTommy.chapterScore);
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
