using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    public Text TimeCounter;

    private TimeSpan TimePlaying;
    private bool TimeGoing;

    private float elapsedTime;

    private void Awake()
    {
        instance = this;
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
