using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StoreClerk : MonoBehaviour {
    public NPC npc;
    bool isTalking = false;
    bool conversationFinished = false;
    float curResponseTrackerNPC = 0;
    float curResponseTrackerPlayer = 0;

    // UI Game Objects
    public GameObject dialogueUI;
    public GameObject npcPanel;
    public GameObject playerPanel;
    public GameObject playerPanel1;
    public GameObject playerPanel2;
    public GameObject playerPanel3;
    public GameObject playerPanel4;
    public GameObject playerPanel5;

    // Cameras
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;

    // UI Text References
    public Text npcName;
    public Text playerName;
    public Text npcDialogueText;
    public Text playerResponse;
    public Text playerResponse1;
    public Text playerResponse2;
    public Text playerResponse3;
    public Text playerResponse4;
    public Text playerResponse5;


    // Start is called before the first frame update
    void Start() {
        dialogueUI.SetActive(false);
    }

    void OnMouseOver() {
        // Trigger dialogue
        if (Input.GetKeyDown(KeyCode.E) && isTalking == false) {
            StartConversation();
        }

        // Store clerk updates
        if (curResponseTrackerPlayer == 0 && isTalking == true) {
            StoreClerkSpeaks(0);
        }

        // Adam updates
        else if (curResponseTrackerNPC == 1) {
            AdamSpeaks(1);
        }

        // Store clerk updates
        else if (curResponseTrackerPlayer == 2) {
            StoreClerkSpeaks(1);
        }

        // Adam updates to conclude conversation
        else if (curResponseTrackerNPC == 3) {
            AdamSpeaks(2);
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
            }
        }
    }

    // Method for showing Store Clerks's dialogue
    void StoreClerkSpeaks(int value) {
        if (Input.GetKeyDown(KeyCode.Return)) {
            playerResponse.text = "";
            playerName.text = "";
            showHidePanel(playerPanel);
            npcPanel.SetActive(true);
            showHidePanel(npcPanel);
            npcDialogueText.text = npc.dialogue[value];
            npcName.text = npc.npcName;

            if (Input.GetKeyDown(KeyCode.Return)) {
                curResponseTrackerNPC++;
                curResponseTrackerPlayer++;
            }
        }
    }

    void StartConversation() {
        dialogueUI.SetActive(true);
        curResponseTrackerNPC = 0;
        curResponseTrackerPlayer = 0;
        npcDialogueText.text = "";
        npcName.text = "";
        isTalking = true;
        playerName.text = npc.playerName;
        playerResponse.text = npc.playerDialogue[0];
    }

    void EndDialogue() {
        isTalking = false;
        dialogueUI.SetActive(false);
        SceneManager.LoadScene("GroceryStore");
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