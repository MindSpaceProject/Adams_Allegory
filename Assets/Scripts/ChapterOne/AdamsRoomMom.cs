using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdamsRoomMom : MonoBehaviour
{
    public float speed = 3f;
    private Vector3 dir;
<<<<<<< HEAD
    private Vector3 endPosition = new Vector3(-86, 158.5f, 9);
=======
    private Vector3 endPosition = new Vector3(-86, 158, 9);
>>>>>>> f8d1914b4d75aebfa9aa5c3401a882091b087d54
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        dir = Vector3.forward;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    if(transform.position != endPosition) {
        animator.SetBool("isWalking", true);
        transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
    }
    if(transform.position == endPosition){
        animator.SetBool("isWalking", false);
    }

<<<<<<< HEAD
=======


>>>>>>> f8d1914b4d75aebfa9aa5c3401a882091b087d54
    }
}
