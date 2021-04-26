using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_bar : MonoBehaviour
{
    
    private float fillAmount;

    [SerializeField]
    private Image Fill;

    [SerializeField]
    private Text ValueText;
    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            string[] tmp = ValueText.text.Split(':');
            ValueText.text = tmp[0] + ":" + value;
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Handler();
        
    }

    private void Handler()
    {
        if(fillAmount != Fill.fillAmount)
        {
            Fill.fillAmount = fillAmount;
        }
        
    } 

    private float Map(float value, float inmin, float inmax, float outmin, float outmax)
    {
        return (value - inmin) * (outmax - outmin) / (inmax - inmin) + outmin;
    }
}
