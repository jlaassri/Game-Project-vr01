using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UI_stats 
{
    //for any code that isnt my own, check relivent blog post for citation
    [SerializeField] 
    private UI_bar bar; //UI bar component 
    [SerializeField]
    private float maxVal; //max value
    [SerializeField]
    private float currentVal; //current health 

    public float CurrentVal
    {
        get
        {
            return currentVal; //get current vale form health script 
        }

        set
        {
            // stops bar from going below 1 and ablove max val
            this.currentVal = Mathf.Clamp(value,0,Maxval);
            bar.Value = currentVal; //bar fill = current value
        }
    }

    public float Maxval 
    {
        get
        {
            return maxVal; //gets max value from helaht script 
        }

        set
        {
            bar.MaxValue = value; //bar max = 1
            this.maxVal = value; //max = 1
        }
    }

    public void Init()
    {
        this.maxVal = Maxval; //sets max value to player max value 
        this.CurrentVal = currentVal; //sets current calue to player current value 
    }
}
