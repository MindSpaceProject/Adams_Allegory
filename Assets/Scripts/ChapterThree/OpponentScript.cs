using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentScript : MonoBehaviour
{
    public static bool onHand = true;
    public GameObject MyBall;
    public GameObject MyVisBall;
    public GameObject Me;
    public GameObject Wall;
    //public BoxCollider adamsBall;
    public BoxCollider MyBallColl;
    public BoxCollider MyCollider;
    public AudioSource audioSource;
    //AudioSource 
    public AudioClip clip;
    //AudioClip 
    public float volume=0.5f;
    //Volume of clip played
    private Vector3 endPosition = new Vector3(-50, 1, 1);
    private Vector3 enableDist = new Vector3(5, 5, -1);
    public float speed = 0.1f;
    public int send = 0;
    public int throwcond =0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
      //Set one target to be seen and the rest to false
        Me.SetActive(true);
        MyBall.GetComponent<Transform>().position = MyVisBall.GetComponent<Transform>().position;
        MyBall.GetComponent<MeshRenderer>().enabled = true;
        //Debug.Log("This Shit Broke");
    }

    // Update is called once per frame
    void Update()
    {
        //MyBall.GetComponent<Transform>().position = Vector3.MoveTowards(MyBall.GetComponent<Transform>().position, endPosition, speed * Time.deltaTime);


        if(MyBall.GetComponent<Transform>().position == MyVisBall.GetComponent<Transform>().position && throwcond == 0 ){
            Debug.Log("We are preparing to throw ball");
            Invoke("Rand", 0);
        }

        if(throwcond == 1){
            MyBall.GetComponent<Transform>().Translate(-0.4f,0,0);
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("We are in the trigger");
        if(other.gameObject.name == "AdamsBall"){
            Me.SetActive(false);
            MyBall.SetActive(false);
            MyVisBall.SetActive(false);
            MyBall.GetComponent<BoxCollider>().enabled = false;
        }
        if(other == MyBall){
            MyBall.GetComponent<Transform>().position = MyVisBall.GetComponent<Transform>().position;
            Debug.Log("We collided with our own ball");
        }
    }

    void Rand(){
        send = Random.Range(1,3);
        Invoke("throwBall",send);
        Debug.Log("We got to Rand");
    }

    void throwBall(){
        MyBall.GetComponent<MeshRenderer>().enabled = true;
        Debug.Log("We are in throw");
        onHand = false;
        throwcond = 1;
        
    }

    public bool getonHand(){
        return onHand;
    }

    public void setOnHand(bool OnHander){
        onHand = OnHander;
    }

    public int getThrowCond(){
        return throwcond;
    }

    public void setThrowCond(int change){
        throwcond = change;
    }
}
