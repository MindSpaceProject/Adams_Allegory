using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JoshDance : MonoBehaviour
{


    public NPC npc;
    bool conversationFinished = false;
    public static float curResponseTracker = 0;
    float anxietyQuestions = 0;
    public bool adamEntered = false;
    public GameObject trigger3;
    public GameObject Stacy;
    public GameObject StacyLeave;
    public GameObject Tommy;
    public GameObject TommyLeave;


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

    void Start() {
        dialogueUI.SetActive(false);
        trigger3.SetActive(false);
    }
    void Update() {
         if(adamEntered) {
             handleDialogue();

         }
     }

     void OnTriggerEnter(Collider other) { 
        dialogueUI.SetActive(true);
        AdamMovement.canMove = false;
        adamEntered = true;
        npcName.text = "";
        npcDialogueText.text = "";
        playerPanel.SetActive(true);
        npcPanel.SetActive(false);
        playerName.text = npc.playerName;
        playerResponse.text = npc.playerDialogue[0];
     }

    void handleDialogue() {
        // Josh updates
        if (curResponseTracker == 0) {
            Stacy.SetActive(false);
            StacyLeave.SetActive(true);
            Tommy.SetActive(false);
            TommyLeave.SetActive(true);
            JoshSpeaks(0);
        }

        // Adam updates
        else if (curResponseTracker== 1) {
            AdamSpeaks(1);
        }

        // Josh updates
        else if (curResponseTracker == 2) {
            JoshSpeaks(1);
        }

        // Adam updates
        else if (curResponseTracker == 3) {
            AdamSpeaks(2);
        }

        // Josh updates
        else if (curResponseTracker == 4) {
            JoshSpeaks(2);
        }

        // Adam updates
        else if (curResponseTracker == 5) {
            AdamSpeaks(3);
        }

        // Josh updates
        else if (curResponseTracker == 6) {
            JoshSpeaks(3);
        }

        // Anxiety question
        else if (anxietyQuestions == 0) {
            buttonWasClicked = false;
            AnxietyQuestion(4);
        }

        // Josh updates manual
        else if (curResponseTracker == 7) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                MomDance.chapterScore += tempValue;
                clearAnxietyQuestions();

                npcDialogueText.text = npc.dialogue[4];
                npcName.text = npc.npcName;

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTracker++;
                }
            }
            
        }

        // Anxiety question
        else if (anxietyQuestions == 1) {
            AnxietyQuestion(7);
        }

        // Josh updates manual
        else if (curResponseTracker == 8) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                MomDance.chapterScore += tempValue;
                clearAnxietyQuestions();

                npcDialogueText.text = npc.dialogue[5];
                npcName.text = npc.npcName;

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTracker++;
                }
            }
            
        }

        // Adam updates
        else if (curResponseTracker == 9) {
            AdamSpeaks(10);
        }

        // Josh updates
        else if (curResponseTracker == 10) {
            JoshSpeaks(6);
        }

        // Adam updates
        else if (curResponseTracker == 11) {
            AdamSpeaks(11);
        }

        // Josh updates
        else if (curResponseTracker == 12) {
            JoshSpeaks(7);
        }

        // Adam updates
        else if (curResponseTracker == 13) {
            AdamSpeaks(12);
        }

        // Josh updates
        else if (curResponseTracker == 14) {
            JoshSpeaks(8);
        }

        // Adam updates
        else if (curResponseTracker == 15) {
            AdamSpeaks(13);
        }

        // Josh updates
        else if (curResponseTracker == 16) {
            JoshSpeaks(9);
        }

        // Adam updates to conclude conversation
        else if (curResponseTracker == 17) {
            AdamSpeaks(14);
            conversationFinished = true;
        }

        // End dialogue
        else if (curResponseTracker == 18 && Input.GetKeyDown(KeyCode.E) && conversationFinished == true) {
            EndDialogue();
        }
    }

    // Method for showing Adam's dialogue
    void AdamSpeaks(int value) {
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
                curResponseTracker++;
            }
        }
    }
    

    // Method for showing NPC dialogue
    void JoshSpeaks(int value) {
        if (Input.GetKeyDown(KeyCode.Return)) {
            playerResponse.text = "";
            playerName.text = "";
            playerPanel.SetActive(false);
            npcPanel.SetActive(true);
            npcDialogueText.text = npc.dialogue[value];
            npcName.text = npc.npcName;

            if (Input.GetKeyDown(KeyCode.Return)) {
                curResponseTracker++;
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
        AdamMovement.canMove = true;
        Debug.Log("Final Chapter Score: " + MomDance.chapterScore);
        trigger3.SetActive(true);
        Destroy(gameObject);
    }

}
