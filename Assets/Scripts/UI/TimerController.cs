﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : Singleton<TimerController>
{
    

    public Text TimeCounter;

    private TimeSpan TimePlaying;
    public bool TimeGoing;

    private float elapsedTime;

    private void Awake()
    {
        
    }

    // Update is called once per frame
    private void Start()
    {
        TimeCounter.text = "00:00.00";
        TimeGoing = false;
    }

    public void BeginTimer()
    {

        TimeGoing = true;
        Debug.Log(TimeGoing);
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }
    
    public void EndTimer()
    {
        TimeGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (TimeGoing)
        {

            
            elapsedTime += Time.deltaTime;
            TimePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingstr = TimePlaying.ToString("mm':'ss'.'ff");
            TimeCounter.text = timePlayingstr;

            yield return null;
        }
    }
}
