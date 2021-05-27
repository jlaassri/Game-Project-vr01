using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //for any code that isnt my own, check relivent blog post for citation
    [SerializeField] private UI_stats Health; //sets UI stats script

    public static float CurrHealth; //players current health 
    public static float Healthup; //health increase from item 
    public static float max; // set to maxhealth for healing script
    // Start is called before the first frame update
    void Start()
    {
        CurrHealth = MaxHealth(); //sets current health to max health 
        Health.Init(); //sets the UI stats script
    }

    // Update is called once per frame
    void Update()
    {
        Health.CurrentVal = CurrHealth; //set the current health to the current val for the UI stats for the UI bar script
        Health.Maxval = MaxHealth(); //does the same thing but for the max val for the UI Bar/ Ui stats script

        max = MaxHealth(); // healing script variable

        if (CurrHealth >= MaxHealth()) //checks the players current health higher then max health values 
        {
            CurrHealth = MaxHealth(); //if current higher then max, health set to max value 
        }

        if (CurrHealth <= 0 & PlayerController.lifeup <= 0) //checks if players health is less then or equal to 0 and lifeup is also less then or equal to 0 
        {
            gameover();//runs game over function
            Debug.Log("you lose"); //debug for checking if running
        }

        if(CurrHealth <= 0 & PlayerController.lifeup > 0) //if play lifeup is not 0
        {
            PlayerController.lifeup--; //reduces lifeup value by 1
            CurrHealth = MaxHealth() / 2; //give player health = to half of players max health
        }
    }

    private void gameover()//game over function
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //changes scene when player dies 
    }
    public float MaxHealth(float increment = 0) //max health function
    {
         float maxHealth = 100; //set float to 100
        
         maxHealth = maxHealth + Healthup * 6; // max health equation
 
         return maxHealth; //returns maxhealth value from equation
     }

    public void lifetap() //lifetap function
    {
        CurrHealth = CurrHealth + PlayerController.lifetapup * 6; //give player health based on equation 
    }
}
