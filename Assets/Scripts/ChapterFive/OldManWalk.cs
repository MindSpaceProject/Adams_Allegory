using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManWalk : MonoBehaviour
{
   public float speed = 3f;
    private Vector3 dir;
    private Vector3 endPosition = new Vector3(-117, 171, -165);
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

    }
}

