using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_bar : MonoBehaviour
{
    //for any code that isnt my own, check relivent blog post for citation
    private float fillAmount; //fill float 

    [SerializeField]
    private Image Fill; //fill game object 

    [SerializeField] 
    private Text ValueText; //value text game object 
    public float MaxValue { get; set; } //get max helath vlaue 

    public float Value //print text function
    {
        set
        {
            string[] tmp = ValueText.text.Split(':'); //split text 
            ValueText.text = tmp[0] + ":" + value; //prints value 
            fillAmount = Map(value, 0, MaxValue, 0, 1); //fills bar 
        }
    }

    // Update is called once per frame
    void Update()
    {
        Handler(); //runs handler function
        
    }

    private void Handler() //handler function
    {
        if(fillAmount != Fill.fillAmount) //if fill is not the fill amount 
        {
            Fill.fillAmount = fillAmount; // fill = fillamount 
        }
        
    } 

    private float Map(float value, float inmin, float inmax, float outmin, float outmax) //maps health value
    {
        return (value - inmin) * (outmax - outmin) / (inmax - inmin) + outmin; //outputs current health value to decimal out of max 
    }
}
