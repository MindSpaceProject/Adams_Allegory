using UnityEngine;
using UnityEngine.UI;

public class TriggerOne : MonoBehaviour
{
    public NPC npc;
    float curResponseTracker = 0;
    public AudioSource audioSource;
    public AudioSource HeartBeat;
    public GameObject teddy;

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
    public Button btn;
    public Button btn2;
    public Button btn3;
    public bool adamEntered = false;

    void Start(){
        dialogueUI.SetActive(false);
        teddy.SetActive(false);

    }
     void Update() {
         if(adamEntered) {
             handleDialogue();

         }

     }
    void OnTriggerEnter(Collider other) {  
        AdamMovement.canMove = false;
        dialogueUI.SetActive(true);
        npcName.text = "";
        npcDialogueText.text = "";
        npcPanel.SetActive(false);
        clearAnxietyQuestions();
        playerName.text = npc.playerName;
        playerResponse.text = npc.playerDialogue[0];
        adamEntered = true;
        HeartBeat.volume = 0.5f;
        audioSource.volume = 0.1f;
    }

    void handleDialogue() {
         // Adam updates
        if (curResponseTracker == 0) {
            // Normally you would just call updateAdam here, but I have to get rid of Adam's name for this one  
            if (Input.GetKeyDown(KeyCode.Return)) {
            // Set text to next dialogue response
            playerResponse.text = npc.playerDialogue[1];
            playerName.text = "";

            // Wait until user has finished reading and presses Enter
            if (Input.GetKeyDown(KeyCode.Return)) {
                curResponseTracker++;
            }
        }
        }

        else if (curResponseTracker == 1) {
            updateAdam(2);
            
        }

        // Once dialogue is finished
       else if (Input.GetKeyDown(KeyCode.E) && curResponseTracker == 2) {
         AdamMovement.canMove = true;
         dialogueUI.SetActive(false);
         Destroy(gameObject);
    }
    }

    // Use this method to update Adam
    void updateAdam(int value) {
        if (Input.GetKeyDown(KeyCode.Return)) {
            // Set text to next dialogue response
            playerResponse.text = npc.playerDialogue[value];
            playerName.text = npc.playerName;

            // Wait until user has finished reading and presses Enter
            if (Input.GetKeyDown(KeyCode.Return)) {
                curResponseTracker++;
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
}
