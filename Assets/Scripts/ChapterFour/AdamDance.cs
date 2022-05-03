using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdamDance : MonoBehaviour
{

    public NPC npc;
    bool conversationFinished = false; 
    float curResponseTrackerNPC = 0;
    public bool adamEntered = false;

    // UI Game Objects
    public GameObject dialogueUI;

    // UI Text References
    public Text playerName;
    public Text playerResponse;
    
 
    void Start() {
        dialogueUI.SetActive(false);
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
        playerName.text = npc.playerName;
        playerResponse.text = npc.playerDialogue[0];
     }

    void handleDialogue() {
        // Trigger dialogue
        // Adam updates
        if (curResponseTrackerNPC == 0) {
            UpdateAdam(1);
        }

        // Adam updates manually with no name
        else if (curResponseTrackerNPC == 1) {
            if (Input.GetKeyDown(KeyCode.Return)) {
            // Set text to next dialogue response
            playerResponse.text = npc.playerDialogue[2];
            playerName.text = "";

            // Wait until user has finished reading and presses Enter
            if (Input.GetKeyDown(KeyCode.Return)) {
                curResponseTrackerNPC++;
            }
        }
        }

        // Adam updates
       else if (curResponseTrackerNPC == 2) {
            UpdateAdam(3);
        }

        // Adam updates
       else if (curResponseTrackerNPC == 3) {
            UpdateAdam(4);
        }

        // Ending chapter dialogue
        else if (curResponseTrackerNPC == 4) {
            UpdateAdam(5);
            conversationFinished = true;
        }

        // End dialogue
        else if (curResponseTrackerNPC == 5 && Input.GetKeyDown(KeyCode.E)  && conversationFinished == true) {
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
            }
        }
    }

    void EndDialogue() {
        dialogueUI.SetActive(false);
        Debug.Log("Final Chapter Score: " + MomDance.chapterScore);
        ChapterTransition.chapter = 5;
        SceneManager.LoadScene("ChapterTransition");
    }
    }
