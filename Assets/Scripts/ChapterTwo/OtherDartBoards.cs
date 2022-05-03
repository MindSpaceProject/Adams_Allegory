using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OtherDartBoards : MonoBehaviour
{
    public GameObject Target;
//The target we start on
    public AudioSource audioSource;
//AudioSource
    public GameObject Ballon;  
    public AudioClip clip;
//AudioClip 
    public float volume=0.5f;   
//Volume for Audioclip
    public GameObject mainDartGame;

// Start is called before the first frame update
    void Start()
    {
      audioSource = GetComponent<AudioSource>();
      //Set our current target to be visible
      Target.GetComponent<MeshRenderer>().enabled = true;
      gameObject.GetComponent<BoxCollider>().enabled = true;
    }


// Update is called once per frame
void Update() {
 }

void OnMouseDown(){
//When our main target is clicked set mesh and collider to false and play sound
  Target.GetComponent<MeshRenderer>().enabled = false;
  gameObject.GetComponent<BoxCollider>().enabled = false;
  Ballon.SetActive(false);
  audioSource.Play();
//Wait 3 seconds before running wait method
  Invoke("Wait", 3);
  }

  void Wait(){
//Make all components visible again and increment our game counter
  Target.GetComponent<MeshRenderer>().enabled = true;
  gameObject.GetComponent<BoxCollider>().enabled = true;
  Ballon.SetActive(true);
   DartGame.counter = DartGame.counter + 1;
  // mainDartGame.GetComponent<DartGame>().setCounter(mainDartGame.GetComponent<DartGame>().getCounter()+1);
  if(DartGame.counter >= 15){
      AdamPlaysGame.gameFinished = true;
      SceneManager.LoadScene("AdamRoomTwo");
      
  }
  }
  }