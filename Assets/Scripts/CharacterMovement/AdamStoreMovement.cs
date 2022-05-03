using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdamStoreMovement : MonoBehaviour
{
    public Transform cam;
    public CharacterController controller;
    Animator animator;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    [SerializeField]int MoveSpeed = 3;
    [SerializeField] private GameObject items;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume=0.5f;
    // Countdown timer components
    float currentTime = 0f;
    float startingTime = 60f;

    [SerializeField] Text countdownText;

    // UI Game Objects
    public GameObject adamNPC;          //adam lost cut scene
    public GameObject capsule;          //adam lost cut scene
    public GameObject capsule1;         //beginning cut scene
    public GameObject capsule2;         //capsule for store clerk
    public GameObject npcCharacter;     //adams parents
    public GameObject playerCharacter;  //adam lost
    public GameObject playerCharacter1; //adam talking to clerk
    public GameObject playerPanel1;
    public GameObject playerPanel2;
    public GameObject playerPanel3;
    public GameObject playerPanel4;
    public GameObject playerPanel5;
    public GameObject playableCharacter;//the adam that will be played


    // Cameras
    public GameObject cam1;
    public GameObject cam2;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.Play();
        animator = GetComponent<Animator>();
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        handleAnimation();

        if(currentTime>0)
        {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString ("0");
        }

        if(currentTime>=10.5f) {
            countdownText.color = Color.black;
            }
        if(currentTime<10.5f) {
            countdownText.color = Color.red; 
            } 
        if(currentTime<=0f) {
            checkItems();
        }
}

    //character animations and movement
    void handleAnimation()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(x, 0f, z).normalized;

        bool isMovePressedW = Input.GetKey(KeyCode.W);
        bool isMovePressedD = Input.GetKey(KeyCode.D);
        bool isMovePressedS = Input.GetKey(KeyCode.S);
        bool isMovePressedA = Input.GetKey(KeyCode.A);
        bool runPressed = Input.GetKey(KeyCode.LeftShift); 
        bool isRunning = animator.GetBool("isRunning");

        //character movement and timing
        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * MoveSpeed * Time.deltaTime);
            if(isMovePressedW || isMovePressedD || isMovePressedS || isMovePressedA)
             {
                 animator.SetBool("isRunning", true);
                  
             }
             else if(!isMovePressedW || !isMovePressedD || !isMovePressedA || !isMovePressedS && isRunning){
                 animator.SetBool("isRunning", false);
             }
         }
     }
    
    // Once minigame timer runs out
    void checkItems(){
            Debug.Log("Finished mini-game");
            cam1.SetActive(false);
            cam2.SetActive(true);
            capsule.SetActive(true);
            adamNPC.SetActive(true);
            npcCharacter.SetActive(false);
            playerCharacter.SetActive(false);
            playerCharacter1.SetActive(true);
            playableCharacter.SetActive(false);
            countdownText.text = "";
            playerPanel1.SetActive(true);
            playerPanel2.SetActive(true);
            playerPanel3.SetActive(true);
            playerPanel4.SetActive(true);
            playerPanel5.SetActive(true);
    }
 }