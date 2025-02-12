using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 180f;
    public TextMeshProUGUI timerText;
    private bool _isTimerRunning = false;
    public AudioClip loseSound;

    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        StartGameTimer();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_isTimerRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                // display the timer amount
                DisplayTime(timeRemaining);
            }
            else 
            {
                timeRemaining = 0;
                _isTimerRunning = false;
            }
        }

        if(timeRemaining <=0)
        {
            playerAudio.PlayOneShot(loseSound, 1.0f);
            //WaitForSeconds(1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }     

    public void StartGameTimer()
    {
        _isTimerRunning = true;
    }

    public void EndGameTimer()
    {
        _isTimerRunning = false;
    }

    public float GetTimeRemaining()
    {
        return timeRemaining;
    }

    private void DisplayTime(float timetoDisplay)
    {
        timetoDisplay += 1;
        
        float minutes = Mathf.FloorToInt(timetoDisplay / 60);
        float seconds = Mathf.FloorToInt(timetoDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
