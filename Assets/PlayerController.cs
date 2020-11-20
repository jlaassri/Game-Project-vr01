using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrHealth;

    public int Dmg = 10;

    public int MovementSpeed = 5;


    void Start()
    {
        CurrHealth = MaxHealth;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CompareTag("enProj"))
        {
            CurrHealth -= enDmg;
        }  
        

    }
}
