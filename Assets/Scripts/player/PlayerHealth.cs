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
    public static float max;
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

        max = MaxHealth();
        //Debug.Log(MaxHealth());

        if (CurrHealth >= MaxHealth())
        {
            CurrHealth = MaxHealth();
        }

        //MaxHealth = maxHealth + Healthup * 6;

        if (CurrHealth <= 0 & PlayerController.lifeup <= 0)
        {
            Debug.Log("you lose");
        }

        if(CurrHealth <= 0 & PlayerController.lifeup >= 0)
        {
            PlayerController.lifeup--;
            CurrHealth = MaxHealth() / 2;
        }
    }
    public float MaxHealth(float increment = 0)
    {
         float maxHealth = 100;
        
    
         maxHealth = maxHealth + Healthup * 6;
         //Debug.Log($"You have {maxHealth.ToString()}");
    
    
         return maxHealth;
     }

    public void lifetap()
    {
        CurrHealth = CurrHealth + PlayerController.lifetapup * 6;
    }
}
