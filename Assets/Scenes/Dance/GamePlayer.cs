using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayer : MonoBehaviour
{
    
    public AudioSource music;
    public AudioSource bgm;
    public bool startPlaying;
    public ArrowScroll theAS;
    public static GamePlayer instance;
    public Animator animator;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfect = 150;
    // Multiplier TEXT
    public int currentMulti;
    public int multiTracker;
    public int[] multiLimit;
    // Score TEXT
    float currentTime = 0f;
    float startingTime = 70f;
    public GameObject minigame;
    public GameObject camera2;
    void Start()
    {
        instance = this;
        currentMulti = 1;
        animator = GetComponent<Animator>();
        currentTime = startingTime;
    }

    void Update()
    {
        if(!startPlaying)
        {
                startPlaying = true;
                theAS.hasStarted = true;
                music.Play();
                bgm.Stop();
        }

        if(currentTime>0f) {
        currentTime -= 1 * Time.deltaTime;
        }

        if(currentTime<=0f) {
           TommyDance.gameFinished = true;
           camera2.SetActive(true);
           TommyDance.curResponseTracker = 17;
           minigame.SetActive(false);
           Destroy(gameObject);
        }
    }

    public void NoteHit()
    {
        if(currentMulti - 1 < multiLimit.Length)
        {
            multiTracker++;
            if(multiLimit[currentMulti - 1] <= multiTracker)
            {
                multiTracker = 0;
                currentMulti++;
            }
        }
        currentScore += scorePerNote * currentMulti;
        danceAnimation();
    }
    public void NormalHit()
    {
        currentScore += scorePerNote * currentMulti;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMulti;
        NoteHit();
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfect * currentMulti;
        NoteHit();
    }

    public void NoteMiss()
    {
        currentScore -= 100;
        NoteHit();
    }
    
    public void NoteMissed()
    {
        currentScore -= scorePerNote;
        currentMulti = 1;
        multiTracker = 0;
        if(currentScore < 0)
        {
            currentScore = 0;
        }
        bool isDancing = animator.GetBool("isDancing");
        if(isDancing)
        {
            animator.SetBool("isDancing", false);
        }
    }

    void danceAnimation()
    {
        bool isDancing = animator.GetBool("isDancing");
        if(!isDancing)
        {
            Debug.Log("Dancing");
            animator.SetBool("isDancing", true);
        }
    }
}