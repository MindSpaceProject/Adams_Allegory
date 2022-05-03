using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class TommyGaming : MonoBehaviour
{
    public NPC npc;
    float curResponseTracker = 0;
    public Text playerName;
    public Text npcName;
    public GameObject npcPanel;
    public GameObject playerPanel;
    public Text npcDialogueText;
    public Text playerResponse;

    // Start is called before the first frame update
    void Start()
    {
        playerPanel.SetActive(false);
        npcPanel.SetActive(true);
        playerName.text = "";
        playerResponse.text = "";
        npcName.text = npc.npcName;
        npcDialogueText.text = npc.dialogue[0];
    }

    // Update is called once per frame
    void Update()
    {
        handleDialogue();
    }

    void handleDialogue() {
        
        if (curResponseTracker== 0) {
            AdamSpeaks2(0);
        }

        // Tommy updates
        else if (curResponseTracker == 1) {
            TommySpeaks(1);
        }

        else if (curResponseTracker== 2) {
            AdamSpeaks2(1);
        }

        // Tommy updates
        else if (curResponseTracker == 3) {
            TommySpeaks(2);
        }

        else if (curResponseTracker== 4) {
            
            AdamSpeaks2(2);
        }

        else if (curResponseTracker== 5) {
            AdamSpeaks(3);
        }

        else if (curResponseTracker== 6) {
            AdamSpeaks(4);
        }

        else if (curResponseTracker== 7) {
            AdamSpeaks(5);
        }

        else if (curResponseTracker== 8) {
            AdamSpeaks(6);
        }

        else if (curResponseTracker== 9) {
            AdamSpeaks(7);
        }

        else if (curResponseTracker== 10) {
            AdamSpeaks(8);
        }

        else if (curResponseTracker== 11) {
            AdamSpeaks(9);
        }

        else if (curResponseTracker== 12 && Input.GetKeyDown(KeyCode.E)) {
            EndDialogue();
        }
    }

    // Method for showing Adam's dialogue
    void AdamSpeaks2(int value) {
        if (Input.GetKeyDown(KeyCode.Return)) {
            // Hide NPC Panel and text, show Adam's panel and text
             npcDialogueText.text = "";
            npcName.text = "";
            playerPanel.SetActive(true);
            npcPanel.SetActive(false);

            // Set text to next dialogue response
            playerResponse.text = npc.playerDialogue[value];
            playerName.text = "Adam";

            // Wait until user has finished reading and presses Enter
            if (Input.GetKeyDown(KeyCode.Return)) {
                curResponseTracker++;
            }
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
            playerName.text = "Adam (Talking to Player)";

            // Wait until user has finished reading and presses Enter
            if (Input.GetKeyDown(KeyCode.Return)) {
                curResponseTracker++;
            }
        }
    }

    // Method for showing NPC dialogue
    void TommySpeaks(int value) {
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

    void EndDialogue() {
        ChapterTransition.chapter = 7;
        SceneManager.LoadScene("ChapterTransition");
    }
}
