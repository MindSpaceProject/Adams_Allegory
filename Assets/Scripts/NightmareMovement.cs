using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NightmareMovement : MonoBehaviour
{
    public Rigidbody rb;
    Animator animator;
    int MoveSpeed = 8;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume=0.5f;

    public GameObject dialogue;

    public GameObject tutorialScreen;
    public GameObject trashcan1;
    public GameObject trashcan2;
    public GameObject trashcan3;
    public GameObject trashcan4;
    public GameObject trashcan5;
    public GameObject trashcan6;
    public GameObject trashcan7;
    public GameObject trashcan8;
    public GameObject bgDialogue;
    // Start is called before the first frame update
    void Start() {
        
        bgDialogue.SetActive(false);
        trashcan1.SetActive(false);
        trashcan2.SetActive(false);
        trashcan3.SetActive(false);
        trashcan4.SetActive(false);
        trashcan5.SetActive(false);
        trashcan6.SetActive(false);
        trashcan7.SetActive(false);
        trashcan8.SetActive(false);
        tutorialScreen.SetActive(true);
    }

    void Update() {
        handleAnimation();
    }

    // private void FixedUpdate() {
    //     rb.AddForce(18000 * Time.deltaTime, 0, 0);
    //     // if(Input.GetKey(KeyCode.D)){
    //     //     rb.AddForce
    //     // }
    // }

    public void onClickStartGame(){
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.Play();
        tutorialScreen.SetActive(false);
        trashcan1.SetActive(true);
        trashcan2.SetActive(true);
        trashcan3.SetActive(true);
        trashcan4.SetActive(true);
        trashcan5.SetActive(true);
        trashcan6.SetActive(true);
        trashcan7.SetActive(true);
        trashcan8.SetActive(true);
        bgDialogue.SetActive(true);
    }

    void handleAnimation() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(x, 0f, z).normalized;

        bool isMovePressedW = Input.GetKey(KeyCode.W);
        bool isMovePressedD = Input.GetKey(KeyCode.D);
        bool isMovePressedS = Input.GetKey(KeyCode.S);
        bool isMovePressedA = Input.GetKey(KeyCode.A);

        if(direction.magnitude >= 0.1f) {
            transform.Translate(Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime);
            if((isMovePressedW || isMovePressedD || isMovePressedA || isMovePressedS)){
                MoveSpeed = 6;
            }
        }
    }
}