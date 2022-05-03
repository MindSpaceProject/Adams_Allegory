using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TommyDance : MonoBehaviour
{
    public NPC npc;
    bool conversationFinished = false;
    public static float curResponseTracker = 0;
    float anxietyQuestions = 0;
    public bool adamEntered = false;
    public GameObject dancingGame;
    public GameObject cutscene;
    public GameObject Stacy;
    // UI Game Objects
    public GameObject dialogueUI;
    public GameObject tutorialUI;
    public GameObject npcPanel;
    public GameObject playerPanel;
    public GameObject playerPanel1;
    public GameObject playerPanel2;
    public GameObject playerPanel3;
    public GameObject joshTrigger;

    // UI Text References
    public Text npcName;
    public Text playerName;
    public Text npcDialogueText;
    public Text playerResponse;
    public Text playerResponse1;
    public Text playerResponse2;
    public Text playerResponse3;
    public static bool gameFinished = false;

    // Anxiety Question Buttons
    public Button btn;
    public Button btn2;
    public Button btn3;
    public int tempValue = 0; // Keep track of temp chapter score value
    bool buttonWasClicked = false;

    // Start is called before the first frame update
    void Start() {
        joshTrigger.SetActive(false);
        dialogueUI.SetActive(false);
        tutorialUI.SetActive(false);
        dancingGame.SetActive(false);
    }
    void Update() {
         if(adamEntered) {
             handleDialogue();

         }
     }

     void OnTriggerEnter(Collider other) { 
        dialogueUI.SetActive(true);
        AdamMovement.canMove = false;
        clearAnxietyQuestions();
        adamEntered = true;
        playerName.text = "";
        playerResponse.text = "";
        playerPanel.SetActive(false);
        npcName.text = npc.npcName;
        npcDialogueText.text = npc.dialogue[0];
     }

     void handleDialogue() {

        // Adam Updates
        if (curResponseTracker == 0) {
            AdamSpeaks(0);
        }

        // Tommy updates
        else if (curResponseTracker == 1) {
            NPCSpeaks(1, true);
        }

        // Adam updates
        else if (curResponseTracker == 2) {
            AdamSpeaks(1);
        }

        // Tommy updates
        else if (curResponseTracker == 3) {
            NPCSpeaks(2, true);
        }

        // Tommy updates again
        else if (curResponseTracker == 4) {
            if (Input.GetKeyDown(KeyCode.Return)) {
                npcDialogueText.text = npc.dialogue[3];
                npcName.text = npc.npcName;

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTracker++;
                }
            }
        }

        // Anxiety question
        else if (anxietyQuestions == 0) {
            AnxietyQuestion(2);
        }

        // Tommy updates again
        else if (curResponseTracker == 5) {
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

        // Adam updates
        else if (curResponseTracker == 6) {
            AdamSpeaks(5);
        }

        // Stacy walks over
        // Stacy updates
        else if (curResponseTracker == 7) {
            Stacy.SetActive(true);
            NPCSpeaks(5, false);
        }

        // Adam updates
        else if (curResponseTracker == 8) {
            AdamSpeaks(6);
        }

        // Stacy updates
        else if (curResponseTracker == 9) {
            NPCSpeaks(6, false);
        }

        // Adam updates
        else if (curResponseTracker == 10) {
            AdamSpeaks(7);
        }

        // Stacy updates
        else if (curResponseTracker == 11) {
            NPCSpeaks(7, false);
        }

        // Adam updates
        else if (curResponseTracker == 12) {
            AdamSpeaks(8);
        }

        // Tommy updates
        else if (curResponseTracker == 13) {
            NPCSpeaks(8, true);
        }

        // Tommy updates again
        else if (curResponseTracker == 14) {
            if (Input.GetKeyDown(KeyCode.Return)) {
                npcDialogueText.text = npc.dialogue[9];
                npcName.text = npc.npcName;

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTracker++;
                }
            }
        }

        // Anxiety question
        else if (anxietyQuestions == 1) {
            AnxietyQuestion(9);
        }

        // Tommy updates
        else if (curResponseTracker == 15) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                MomDance.chapterScore += tempValue;
                clearAnxietyQuestions();

                npcDialogueText.text = npc.dialogue[10];
                npcName.text = npc.npcName;

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTracker++;
                }
            } 
        }

        // Dancing minigame happens
        else if(curResponseTracker == 16) {
            if (Input.GetKeyDown(KeyCode.Return)) {
                tutorialUI.SetActive(true);
                dialogueUI.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Return)) {
                    gameFinished = true;
                }
            }
        }

        // Tommy updates after game
        else if (curResponseTracker == 17 && gameFinished == true) {
            if (Input.GetKeyDown(KeyCode.Return)) {
                 dialogueUI.SetActive(true);
                npcDialogueText.text = npc.dialogue[11];
                npcName.text = npc.npcName;

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTracker++;
                }
            }
        }

        // Tommy updates again
        else if (curResponseTracker == 18) {
        if (Input.GetKeyDown(KeyCode.Return)) {
                npcDialogueText.text = npc.dialogue[12];
                npcName.text = npc.npcName;

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTracker++;
                }
            }
        }

        // Adam updates
        else if (curResponseTracker == 19) {
            AdamSpeaks(12);
        }

        // Stacy updates to conclude conversation
        else if (curResponseTracker == 20) {
            NPCSpeaks(13, false);
            conversationFinished = true;
        }


        // End dialogue
        else if (curResponseTracker == 21 && Input.GetKeyDown(KeyCode.E) && conversationFinished == true) {
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
    void NPCSpeaks(int value, bool tommy) {
        if (Input.GetKeyDown(KeyCode.Return)) {
            playerResponse.text = "";
            playerName.text = "";
            playerPanel.SetActive(false);
            npcPanel.SetActive(true);
            npcDialogueText.text = npc.dialogue[value];
            if (tommy) {
            npcName.text = npc.npcName;
            } else {
               npcName.text = npc.npcName2; 
            }

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

    public void onClickStartGame(){
        cutscene.SetActive(false);
        dancingGame.SetActive(true);
        tutorialUI.SetActive(false);
        joshTrigger.SetActive(true);
}

    void EndDialogue() {
        dialogueUI.SetActive(false);
        AdamMovement.canMove = true;
        Debug.Log("Current Chapter Score: " + MomDance.chapterScore);
        Destroy(gameObject);
    }

}