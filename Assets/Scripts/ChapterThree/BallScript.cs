using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject miniGameController;
    public GameObject Me;
    public GameObject MyVisBall;
    public GameObject Wall;
    public GameObject Adam;
    public GameObject HandCheck;
    public BoxCollider MyCollider;
    public AudioSource audioSource;
    //AudioSource 
    public AudioClip clip;
    //AudioClip 
    public float volume=0.5f;
    private Vector3 enableDist = new Vector3(7, 5, 6.5f);
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Me.GetComponent<MeshRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void OnTriggerEnter(Collider other) { 
        Debug.Log("We Triggered");
        if(other.gameObject.name == "AdamDodgeball"){
            Adam.SetActive(false);
            MyVisBall.SetActive(true);
            Me.SetActive(false);
            miniGameController.GetComponent<MiniGameController>().setGotHit(true);
        }
        if(other.gameObject.name == "OpponentsBallCollide"){
            Debug.Log(other);
            Me.GetComponent<Transform>().position = MyVisBall.GetComponent<Transform>().position;
            HandCheck.GetComponent<OpponentScript>().setThrowCond(0);
            MyVisBall.SetActive(true);
            Me.GetComponent<MeshRenderer>().enabled = false;
            Debug.Log("We hit the Wall");
        }
    }   
}
