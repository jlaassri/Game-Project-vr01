using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnTimer : MonoBehaviour
{
    public GameObject TimeCounter; // get enemy time counter game object 

    public static float EnPower; //enemy power increase float 

    private float Timer = 60; //timer seconds
    private float Entimer = 0; //enemy power indicator timer
    
    // Update is called once per frame
    void Update()
    {
        if (Timer >= 0)//checks if timer > 0
        { 
            Timer -= Time.deltaTime; //decreases timer if greater then 0
        }

        if(Timer <= 0)// checks if timer < 0
        {
            EnPower++; //increase enemy power 
            Timer = 60; //set timer to 60 
            Entimer = 7; // sets enemy timer to 7
        }

        if (Entimer >= 0) //checks if enemy timer is > 0
        {
            Entimer -= Time.deltaTime; //decreases enemy timer if greater then 0
            TimeCounter.SetActive(true); //sets enemy timer increase indicator to visible
        }

        if ( Entimer <= 0) // checks if enemy enemy timer < 0
        {
            TimeCounter.SetActive(false); //sets enemy timer increase indicator to invisible
        }

    }
}
