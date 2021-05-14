using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnTimer : MonoBehaviour
{
    public GameObject TimeCounter;

    public float EnPower;

    private float Timer = 60;
    private float Entimer = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (Timer >= 0)
        { 
            Timer -= Time.deltaTime;
        }
        if(Timer <= 0)
        {
            EnPower++;
            Timer = 60;
            Entimer = 7;
        }

        if (Entimer >= 0)
        {
            Entimer -= Time.deltaTime;
            TimeCounter.SetActive(true);
        }

        if ( Entimer <= 0)
        {
            TimeCounter.SetActive(false);
        }

    }
}
