using UnityEngine;
using UnityEngine.UI;

public class TriggerThree : MonoBehaviour
{
    public NPC npc;
    float curResponseTracker = 0;
    float anxietyQuestions = 0;
    public GameObject teddy;
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource4;
    public GameObject bgm;
    public AudioSource HeartBeat;
    public GameObject knocking;

    // UI Game Objects
    public GameObject dialogueUI;
    public GameObject playerPanel1;
    public GameObject playerPanel2;
    public GameObject playerPanel3;
    public Transform door;
    

    // UI Text References
    public Text playerName;
    public Text playerResponse;
    public Text playerResponse1;
    public Text playerResponse2;
    public Text playerResponse3;
    public Button btn;
    public Button btn2;
    public Button btn3;
    public bool adamEntered = false;

    // Anxiety scoring
    public int tempValue = 0; // Keep track of temp chapter score value
    bool buttonWasClicked = false;

    void Start(){
        dialogueUI.SetActive(false);
        bgm.SetActive(false);
        knocking.SetActive(false);
    }
     void Update() {
         if(adamEntered) {
             handleDialogue();

         }
     }
    void OnTriggerEnter(Collider other) {  

        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.z =-90;
        AdamMovement.canMove = false;
        dialogueUI.SetActive(true);
        adamEntered = true;
        door.rotation = Quaternion.Euler(rotationVector);
        playerName.text = npc.playerName;
        playerResponse.text = "Found the shed.";
        audioSource.volume = 0;
        knocking.SetActive(true);
        audioSource2.volume = 0.4f;
    }

    void handleDialogue() {

        if (curResponseTracker == 0) {
                updateAdam(0);
    }
        
        else if (anxietyQuestions == 0) {
            buttonWasClicked = false;
            AnxietyQuestion(1);
        }

        // after every anxiety question, perform calculations and update manually
        else if (curResponseTracker == 1) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                TriggerTwo.chapterScore += tempValue;
                clearAnxietyQuestions();
                playerResponse.text = npc.playerDialogue[4];

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTracker++;
                }
            }
        }

        // Anxiety Question
        else if (anxietyQuestions == 1) {
            AnxietyQuestion(5);
        }

        else if (curResponseTracker == 2) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                TriggerTwo.chapterScore += tempValue;
                clearAnxietyQuestions();
                playerResponse.text = npc.playerDialogue[8];

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTracker++;
                }
            }
        }
        // Update manual with no name
        else if (curResponseTracker == 3) {
            if (Input.GetKeyDown(KeyCode.Return)) {
            // Set text to next dialogue response
            playerResponse.text = npc.playerDialogue[9];
            playerName.text = "";

            // Wait until user has finished reading and presses Enter
            if (Input.GetKeyDown(KeyCode.Return)) {
                curResponseTracker++;
            }
        }
        }

        else if (curResponseTracker == 4) {
            updateAdam(10); 
        }

        // Anxiety Question
        else if (anxietyQuestions == 2) {
            AnxietyQuestion(11);
            audioSource2.volume = 1;
        }

        else if (curResponseTracker == 5) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                TriggerTwo.chapterScore += tempValue;
                clearAnxietyQuestions();
                playerResponse.text = npc.playerDialogue[14];

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTracker++;
                }
            }
        }

        else if (curResponseTracker == 6) {
            updateAdam(15); 
        }

        // Anxiety Question
        else if (anxietyQuestions == 3) {
            AnxietyQuestion(16);
        }

        else if (curResponseTracker == 7) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                TriggerTwo.chapterScore += tempValue;
                clearAnxietyQuestions();
                playerResponse.text = npc.playerDialogue[19];

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTracker++;
                }
            }
        }

        // Anxiety Question
        else if (anxietyQuestions == 4) {
            AnxietyQuestion(20);
        }

        else if (curResponseTracker == 8) {
            if (Input.GetKeyDown(KeyCode.Return) && buttonWasClicked == true) {
                buttonWasClicked = false;
                TriggerTwo.chapterScore += tempValue;
                clearAnxietyQuestions();
                playerResponse.text = npc.playerDialogue[23];

                if (Input.GetKeyDown(KeyCode.Return)) {
                    curResponseTracker++;
                }
            }
        }

        else if (curResponseTracker == 9) {
            updateAdam(24); 
        }

        // Once dialogue is finished
       else if (Input.GetKeyDown(KeyCode.E) && curResponseTracker == 10) {
            // Teddy walks in here
            dialogueUI.SetActive(false);
            teddy.SetActive(true);
            AdamMovement.canMove = true;
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = 0;
            door.rotation = Quaternion.Euler(rotationVector);
            audioSource.volume = 0;
            audioSource2.volume = 0;
            audioSource3.volume = 0;
            HeartBeat.volume = 0;
            bgm.SetActive(true);
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

    // Calculating anxiety responses
    public void onClickResponseOne() {
        tempValue = 2;
        buttonWasClicked = true;
    }

    public void onClickResponseTwo() {
        tempValue = 1;
        buttonWasClicked = true;
    }

    public void onClickResponseThree() {
        tempValue = 0;
        buttonWasClicked = true;
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
}
