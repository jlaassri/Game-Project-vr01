using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private UI_stats Health;

    private float maxHealth = 100;
    //public float MaxHealth;
    public static float CurrHealth;
    public static float Healthup;
    // Start is called before the first frame update
    void Start()
    {
        CurrHealth = MaxHealth();
        Health.Init();



    }

    // Update is called once per frame
    void Update()
    {
        Health.CurrentVal = CurrHealth;
        Health.Maxval = MaxHealth();

        //Debug.Log(MaxHealth());

        if (CurrHealth >= MaxHealth())
        {
            CurrHealth = MaxHealth();
        }

        //MaxHealth = maxHealth + Healthup * 6;

    }
    public float MaxHealth(float increment = 0)
    {
         float maxHealth = 100;
        
    
         maxHealth = maxHealth + Healthup * 6;
         //Debug.Log($"You have {maxHealth.ToString()}");
    
    
         return maxHealth;
     }
}
