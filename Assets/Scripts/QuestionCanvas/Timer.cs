using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class Timer : MonoBehaviour
{
    public event EventHandler OnWaitingTimeOver;
   [SerializeField] float timeToAnswerQuestion = 30f; 
   [SerializeField] float timeToTurnOffQuestion = 5f;
    float timeValue;
    public float fillFraction;
    public bool isAnsweringQuestion = false;
    public bool loadNextQuestion;
    void UpdateTimer()
    {

        if(Pause.Instance.IsPaused())
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue -= Time.unscaledDeltaTime;
        }
        
        
        if (isAnsweringQuestion)
        {
            //neu dang tra loi cau hoi
            if (timeValue > 0)
            {
                fillFraction = timeValue / timeToAnswerQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                timeValue = timeToTurnOffQuestion;
            }
        }
        else
        {
            //neu da tra loi cau hoi
            if (timeValue > 0)
            {
                fillFraction = timeValue / timeToTurnOffQuestion;
                
            }
            else
            {
                OnWaitingTimeOver?.Invoke(this,EventArgs.Empty);

            }
        }
    }

    public void CancelTimer()
    {
        timeValue = 0;
    }

    void Update()
    {
       UpdateTimer();
    }

    public void StartTimeCounter()
    {
        isAnsweringQuestion = true;
        timeValue = timeToAnswerQuestion;
        loadNextQuestion = true;
    }
}
