using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdamsBall : MonoBehaviour
{

    //rigid body, movement, speed components
    public Rigidbody ballPyhsics;
    public float speed = 2500f;
    Vector3 initVelocity;
    //in game gameobjects
    public GameObject adamsHands;
    public GameObject adamCharacter;
    //minigame controller
    public GameObject minigameObject;

    // Start is called before the first frame update
    void Start()
    {
        initVelocity = ballPyhsics.velocity;
        // ballPyhsics.AddForce(gameObject.transform.right * speed);
        //transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0,0);
        //transform.position = Vector3.MoveTowards
    }

    // Update is called once per frame
    void Update()
    {
        if(adamCharacter.GetComponent<AdamDodgeMovement>().getOnHand()){
            transform.position = adamsHands.transform.position;
        }
    }

    //upon hitting enemy, enemy disappears and upon hitting collider it returns adams balls
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Enemy"){
            Debug.Log("Enemy hit");
            //other.transform.parent.gameObject.SetActive(false);
            minigameObject.GetComponent<MiniGameController>().setHitCounter(minigameObject.GetComponent<MiniGameController>().getHitCounter() + 1);
        }
        if(other.tag == "ItemPickup"){
            Debug.Log("Ball Picked up");
            transform.position = adamsHands.transform.position;
            //ballPyhsics.AddForce(gameObject.transform.right * -speed);
            ballPyhsics.velocity = new Vector3(0,0,0);
            adamCharacter.GetComponent<AdamDodgeMovement>().setOnHand(true);
        }
    }

    //launches the ball from adams position
    public void launch(float speed){
        this.speed = speed;
        ballPyhsics.AddForce(-gameObject.transform.up * this.speed);
    }
}
