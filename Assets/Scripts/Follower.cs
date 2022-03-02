using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private int x;
    [SerializeField] private int y;
    [SerializeField] private int z;
    [SerializeField] private float offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.Rotate(x, y, z);
        //transform.Translate(0, 0, 2 * Time.deltaTime * 1);
        transform.position = (transform.position - target.transform.position).normalized * offset + target.transform.position;
    }
}
