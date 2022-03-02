// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class AdamMovement : MonoBehaviour
// {
//     Animator animator;
//     int isWalkingHash;
//     int isRunningHash;
//     int isLeftWalkingHash;
//     int isLeftRunningHash;
//     int isBackWalkingHash;
//     int isRightWalkingHash;
//     public AudioSource audioSource;
//     public AudioClip clip;
//     public float volume=0.5f;
   
//     // Start is called before the first frame update
//     void Start()
//     {
//         audioSource = GetComponent<AudioSource>();
//         animator = GetComponent<Animator>();
//         isWalkingHash = Animator.StringToHash("isWalking");
//         isBackWalkingHash = Animator.StringToHash("isBackWalking");
//         isRunningHash = Animator.StringToHash("isRunning");
//         isLeftWalkingHash = Animator.StringToHash("isLeftWalking");
//         isRightWalkingHash = Animator.StringToHash("isRightWalking");
//     }

//     // Update is called once per frame
//     void Update()
//     {

//         transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 3,0,Input.GetAxis("Vertical") * Time.deltaTime * 3);

//         bool isRunning = animator.GetBool(isRunningHash);
//         bool isWalking = animator.GetBool(isWalkingHash);
//         bool isBackWalking = animator.GetBool(isBackWalkingHash);
        

//         bool isRightWalking = animator.GetBool(isRightWalkingHash);
//         bool isLeftWalking = animator.GetBool(isLeftWalkingHash);

//         bool forwardPressed = Input.GetKey(KeyCode.W);
//         bool reversePressed = Input.GetKey(KeyCode.S);
//         bool runPressed = Input.GetKey(KeyCode.LeftShift);
//         bool leftPressed = Input.GetKey(KeyCode.A);
//         bool rightPressed = Input.GetKey(KeyCode.D);
//         if(forwardPressed || reversePressed || runPressed || leftPressed || rightPressed ){
//             if(!audioSource.isPlaying)
//             {
//                 audioSource.PlayOneShot(clip,volume);
//             }
//         }
//         if(!isWalking && forwardPressed) { animator.SetBool(isWalkingHash, true); }
//         if(isWalking && !forwardPressed) { animator.SetBool(isWalkingHash, false); }
//         if(!isBackWalking && reversePressed) { animator.SetBool(isBackWalkingHash, true); }
//         if(isBackWalking && !reversePressed) { animator.SetBool(isBackWalkingHash, false); }
//         if(isRunning && (!forwardPressed || !runPressed)) { animator.SetBool(isRunningHash, false); }
//         if(!isRunning && (forwardPressed && runPressed)) { animator.SetBool(isRunningHash, true); }

//         if(!isLeftWalking && leftPressed){ animator.SetBool(isLeftWalkingHash, true); }
//         if(isLeftWalking && !leftPressed) { animator.SetBool(isLeftWalkingHash, false); }

//         if(!isRightWalking && rightPressed){ animator.SetBool(isRightWalkingHash, true); }
//         if(isRightWalking && !rightPressed) { animator.SetBool(isRightWalkingHash, false); }
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdamMovement : MonoBehaviour
{
    public Transform cam;
    Animator animator;

    public CharacterController controller;

    Vector3 currentMovement;

    public float turnSmoothTime = 0.1f;

    [SerializeField]float MoveSpeed = 3f;
    public float turnSmoothVelocity;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        handleAnimation();
    }

    void OnCollisionEnter(Collision other) {
        
    }

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
        bool isWalking = animator.GetBool("isWalking");
        bool isRunning = animator.GetBool("isRunning");

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * MoveSpeed * Time.deltaTime);
            if(isMovePressedW || isMovePressedD || isMovePressedS || isMovePressedA)
             {
                 animator.SetBool("isWalking", true);
             }
             else if(!isMovePressedW || !isMovePressedD || !isMovePressedA || !isMovePressedS && isWalking){
                 animator.SetBool("isWalking", false);
             }
             if(!isRunning && ((isMovePressedW || isMovePressedD || isMovePressedA || isMovePressedS) && runPressed))
             {
                 animator.SetBool("isRunning", true);
                 MoveSpeed = MoveSpeed * 2;
             }
             if(isRunning && (!runPressed))
             {
                 animator.SetBool("isRunning", false);
                 MoveSpeed = MoveSpeed / 2;
             }
         }
     }
 }