using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveHouse : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(clip,volume);

    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying){
            SceneManager.LoadScene("Neighborhood");
        }
    }
}
