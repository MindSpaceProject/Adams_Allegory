using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MomInStore : MonoBehaviour {
    public NPC npc;
    bool isTalking = false;
    bool conversationFinished = false;
    float curResponseTrackerNPC = 0;
    float curResponseTrackerPlayer = 0;

    // UI Game Objectsf
    public GameObject dialogueUI;
    public GameObject npcPanel;
    public GameObject playerPanel;
    public GameObject capsule;
    public GameObject capsule1;
    public GameObject npcCharacter;
    public GameObject playerCharacter;
    public GameObject playerCharacter1;
    public GameObject playerCharacter2;
    public GameObject playerPanel1;
    public GameObject playerPanel2;
    public GameObject playerPanel3;
    public GameObject playerPanel4;
    public GameObject playerPanel5;
    public GameObject playableCharacter;    //the adam that the player can play with


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
        cam1.SetActive(false); // Main camera for shopping
        cam2.SetActive(true); // Camera for first walking in cutscene
        cam3.SetActive(false); // Camera for adam done shopping
        cam4.SetActive(false); // store clerk cutscene
        capsule.SetActive(false);
        playerPanel1.SetActive(false);
        playerPanel2.SetActive(false);
        playerPanel3.SetActive(false);
        playerPanel4.SetActive(false);
        playerPanel5.SetActive(false);
        playableCharacter.SetActive(false);
        playerResponse1.text = "";
        playerResponse2.text = "";
        playerResponse3.text = "";
        playerResponse4.text = "";
        playerResponse5.text = "";
        dialogueUI.SetActive(false);
    }

    void OnMouseOver() {
        // Trigger dialogue
        if (Input.GetKeyDown(KeyCode.E) && isTalking == false) {
            StartConversation();
        }

        // Mom updates
        if (curResponseTrackerPlayer == 0 && isTalking == true) {
            MomSpeaks(1);
        }

        // Adam updates to conclude conversation
        else if (curResponseTrackerNPC == 1) {
            AdamSpeaks(0);
            conversationFinished = true;
        } 

        // End conversation 
        else if (conversationFinished == true && Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("ended convo");
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

    // Method for showing Mom's dialogue
    void MomSpeaks(int value) {
        if (Input.GetKeyDown(KeyCode.Return)) {
            npcDialogueText.text = npc.dialogue[value];
            if (Input.GetKeyDown(KeyCode.Return)) {
                curResponseTrackerNPC++;
                curResponseTrackerPlayer++;
            }
        }
    }

    void StartConversation() {
        isTalking = true;
        dialogueUI.SetActive(true);
        curResponseTrackerNPC = 0;
        playerResponse.text = "";
        playerName.text = "";
        showHidePanel(playerPanel);
        npcName.text = npc.npcName;
        npcDialogueText.text = npc.dialogue[0];
    }

    void EndDialogue() {
        capsule.SetActive(false);
        capsule1.SetActive(false);
        isTalking = false;
        dialogueUI.SetActive(false);
        cam1.SetActive(true); //camera for shopping minigame
        cam2.SetActive(false); 
        playableCharacter.SetActive(true);
        npcCharacter.SetActive(false);
        playerCharacter.SetActive(false);
        playerCharacter1.SetActive(false);
        playerCharacter2.SetActive(false);
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