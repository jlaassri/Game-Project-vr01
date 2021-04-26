using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UI_stats 
{
    [SerializeField]
    private UI_bar bar;
    [SerializeField]
    private float maxVal;
    [SerializeField]
    private float currentVal;

    public float CurrentVal
    {
        get
        {
            return currentVal;
        }

        set
        {
            
            this.currentVal = value;
            bar.Value = currentVal;
        }
    }

    public float Maxval
    {
        get
        {
            return maxVal;
        }

        set
        {
            bar.MaxValue = value;
            this.maxVal = value;
        }
    }

    public void Init()
    {
        this.maxVal = Maxval;
        this.CurrentVal = currentVal;
    }
}
