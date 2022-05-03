using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartGame : MonoBehaviour
{
    public GameObject Target;

    public GameObject Ballon;
    //The target we start on
    public AudioSource audioSource;
    //AudioSource 
    public AudioClip clip;
    //AudioClip 
    public float volume=0.5f;
    //Volume of clip played
    public GameObject Target2;
    //Game object for other target
    public GameObject Target3;
    //Game object for other target
    public GameObject Target4;
    //Game object for other target
    public GameObject Target5;
    //Game object for other target
    public static int counter = 0;
    //public variable that keeps score   
    public static int pubrand =0;      
    // public variable that gives random number


    // Start is called before the first frame update
    void Start()
    {
      audioSource = GetComponent<AudioSource>();
      //Set one target to be seen and the rest to false
      Target.GetComponent<MeshRenderer>().enabled = true;
      Target2.GetComponent<MeshRenderer>().enabled = false;
      Target3.GetComponent<MeshRenderer>().enabled = false;
      Target4.GetComponent<MeshRenderer>().enabled = false;
      Target5.GetComponent<MeshRenderer>().enabled = false;
      //pubrand doesn't like to be dealt with directly so create int that get random number from 1-4 and assigne to pubrand
      int  rand = Random.Range(1,4);
      pubrand = rand;
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
  //Get random number so we get a new one on each click
  pubrand = Random.Range(1,6);
  RandPick();
  //Wait 3 seconds before running wait method
  Invoke("Wait", 3);
  }
  void Wait(){
  //Make all components visible again and increment our game counter
  Ballon.SetActive(true);
  Target.GetComponent<MeshRenderer>().enabled = true;
  gameObject.GetComponent<BoxCollider>().enabled = true;
  counter++;
  }

void RandPick(){
  //if the random number generated is 1-4 pick target that corresponds to that and bring it to life
    if(pubrand == 1){
    Target2.GetComponent<MeshRenderer>().enabled = true;
    //gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    if(pubrand == 2){
    Target3.GetComponent<MeshRenderer>().enabled = true;
    //Target2.GetComponent<BoxCollider>().enabled = true;
    }
    if(pubrand == 3){
    Target4.GetComponent<MeshRenderer>().enabled = true;
    //Target2.GetComponent<BoxCollider>().enabled = true;
    }
    if(pubrand == 4){
    Target5.GetComponent<MeshRenderer>().enabled = true;
    //Target2.GetComponent<BoxCollider>().enabled = true;
    }
    if(pubrand == 5){
    Target4.GetComponent<MeshRenderer>().enabled = true;
    //Target2.GetComponent<BoxCollider>().enabled = true;
    }
    if(pubrand == 6){
    Target5.GetComponent<MeshRenderer>().enabled = true;
    //Target2.GetComponent<BoxCollider>().enabled = true;
    }
}

public int getCounter(){
  return counter;
}
public void setCounter(int count){
  counter = count;
}
}



