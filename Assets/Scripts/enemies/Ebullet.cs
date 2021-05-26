using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ebullet : MonoBehaviour
{
    public float speed; //speed float
    public PlayerHealth Player; //player health script

    public EnTimer en; //enemy timer script 
    
    public float Dmg = 10; //enemy damage float 
    private Transform player; //players transfrom 
    private Vector2 target; //empty vector2 used for player position
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //sets player to gameobjects players transfrom 
        target = new Vector2(player.position.x, player.position.y); // sets target to players position using vector 2 
    }

    void Update()
    {
        if(EnTimer.EnPower > 0) //if enpower increases
        {
            Dmg = Dmg * EnTimer.EnPower; //increase the dmg value 
        }
    }

    void Damage()
    {
        SoundManager.PlaySound("hitplayer"); //plays the hit sound effect
        PlayerHealth.CurrHealth = PlayerHealth.CurrHealth - Dmg; //reduces the players health based on dmg value
        this.gameObject.SetActive(false); //set game object to false 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //checks for player tag (player gameobject)
        {
            Damage();//calls dmg function
            DestroyEbullet();//calls destroy function

            Debug.Log("hit");//hit debug.log for testing
        }
    }

    void DestroyEbullet()
    {
        Destroy(gameObject);//destroys game object
    }
}
