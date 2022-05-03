using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdamDodgeMovement : MonoBehaviour
{
    //camera
    public Transform cam;
    //animations
    Animator animator;
    //character collider
    public CharacterController controller;
    //movement
    Vector3 currentMovement;
    public float turnSmoothTime = 0.1f;
    public int MoveSpeed = 6;
    public float turnSmoothVelocity;

    bool onHand;
    public GameObject ballPlacement;
    public GameObject adamsBall;
    public float ballSpeed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        onHand = true;
    }

    // Update is called once per frame
    void Update()
    {
        handleAnimation();
    }

    //handle walking animation and character movement
    void handleAnimation(){
        float x = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(0f, 0f, x).normalized;

        bool isMovePressedD = Input.GetKey(KeyCode.D);  
        bool isMovePressedA = Input.GetKey(KeyCode.A);

        bool isRightWalking = animator.GetBool("isWalkRight");
        bool isLeftWalking = animator.GetBool("isWalkLeft");

        //handle animation and character movement
        if(direction.magnitude >= 0.1f)
        {
            controller.Move(-direction * MoveSpeed * Time.deltaTime);

            if(isMovePressedA && !isMovePressedD){
                Debug.Log("Moving left");
                animator.SetBool("isWalkRight", false);
                animator.SetBool("isWalkLeft", true);
            }else if(isMovePressedD && !isMovePressedA){
                Debug.Log("Moving right");
                animator.SetBool("isWalkRight", true);
                animator.SetBool("isWalkLeft", false);
            }else if(!isMovePressedA && !isMovePressedD){
                animator.SetBool("isWalkRight", false);
                animator.SetBool("isWalkLeft", false);
            }
         }

         if(Input.GetKeyDown(KeyCode.Space) && onHand){
                Debug.Log("Space was pressed");
                throwBall(ballSpeed);
        }
    }

    //throws the ball
    void throwBall(float speed){
        adamsBall.GetComponent<AdamsBall>().launch(speed);
        onHand = false;
    }

    //getters and setters
    public bool getOnHand(){
        return onHand;
    }
    public void setOnHand(bool onHand){
        this.onHand = onHand;
    }
}
