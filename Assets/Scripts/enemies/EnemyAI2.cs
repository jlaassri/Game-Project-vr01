using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI2 : MonoBehaviour
{
    private GameObject player = null; // gets player game object 
    private PlayerHealth Health; //gets player health script
    public float maxhealth;// max health value
    private float currhealth; //current health value 
    public float Dmg = 20; //damage value  
    private float Stopdist; //stopping distance 
    private float retreatdist; //retreat distance 
    private Rigidbody2D rb; //get rigidbody2d component

    public LootTable thisloot; //get loot table class 
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>(); // sets rigidbody2d  to this gameobject

        currhealth = MaxHealth(); //sets the current health to max health 

        if (player == null) //checks if player is empty 
            player = GameObject.Find("Player"); //sets player to player gameobject 
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) > Stopdist) //checks if ditance from player is > then stopping distance value
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Speed() * Time.deltaTime); //moves enmy towards player 
        }

        if (currhealth <= 0) //checks if enemy health is < or = 0
        {
            Debug.Log("Destroy"); //debug check if working 
            Destroy(); //calls destroy function
        }
    }

    public float MaxHealth() // max health function
    {
        maxhealth = maxhealth + EnTimer.EnPower * 10; //max health + enemy power 
        return maxhealth;// returns health value
    }

    public float Speed() //speed function 
    {
        float speed = 80; // set speed value
        speed = speed + EnTimer.EnPower * 10; //speed equation 
        return speed; //returns speed value
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet")) //checks for bullet tag 
        {
            Damage(); //runs damge function 
            if (PlayerController.lifetapup >= 1) //checks if player has 1 lifetap item
            {
                Health.lifetap(); //runs lifetap function 
            }
            Debug.Log("Damage"); //debug check for dame working 
        }

        if(other.gameObject.CompareTag("Player")) //checks for tag player 
        {
            DamagePlayer(); //runs damage player script 
            Destroy(); //runs destroy game object script 
        }
    }

    void Damage() //damge function
    {
        currhealth = currhealth - PlayerController.Damage(); //damage equation
    }

    void DamagePlayer() //damage player function 
    {
        PlayerHealth.CurrHealth = PlayerHealth.CurrHealth - Dmg; //deals dmg to player health 
        this.gameObject.SetActive(false); //sets game object to invisible
    }
    private void MakeItems() //create items function 
    {
        if (thisloot != null) //checks for loot table 
        {
            GameObject current = thisloot.LootPowerup(); //gets loot table result 
            if (current != null) //checks if loot table outputs any items 
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity); // generates ally items that got pulled from the loot table 
            }
        }
    }

    void Destroy()//destroy function 
    {
        SoundManager.PlaySound("enemydeath"); //plays enemy death sound effect
        Destroy(gameObject); // destroys game object
        MakeItems();// runs item spaawner function
        Debug.Log("Death"); //debug if enemy dies
    }
}
