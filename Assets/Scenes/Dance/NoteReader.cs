using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteReader : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public KeyCode letterToPress;

    public GameObject okEffect, goodEffect, perfectEffect, missEffect;

    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
                gameObject.SetActive(false);
                if(Mathf.Abs(transform.position.y) > 0.7f)
                {    
                                    
                     Debug.Log("OKHit");
                    GamePlayer.instance.NormalHit();
                    Instantiate(okEffect, transform.position, okEffect.transform.rotation);
                    
                }
                else if(Mathf.Abs(transform.position.y) > 0.5f)
                {
                    

                    Debug.Log("PerfectHit");
                    GamePlayer.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);      
                } 
                 else if(Mathf.Abs(transform.position.y) >=  6f){
                 Debug.Log("Miss");
                 GamePlayer.instance.NoteMiss();
                 Instantiate(missEffect, transform.position, missEffect.transform.rotation);
           
            }   else {
                Debug.Log("GoodHit");
                    GamePlayer.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
            }          
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Active") canBePressed = true;
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Active")
        {
            canBePressed = false;
            if(other.tag == "Active" && gameObject.activeSelf)
            {
                GamePlayer.instance.NoteMissed();
                Instantiate(missEffect, transform.position, missEffect.transform.rotation);
            }
            
        }
    }
}