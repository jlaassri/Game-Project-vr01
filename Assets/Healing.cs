using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    private float Speed = 100; //sets the speed value
    private Rigidbody2D rb; //get rigidbody2d component

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>(); //set rb to this game objects rigidbody2d
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, Speed * Time.deltaTime); //moves the game object to player position
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")) //checks if collision is the player 
        {
            PlayerHealth.CurrHealth = PlayerHealth.CurrHealth + healing(); //heals player on collsion 
            Destroy(); //calls healing function 
        }
    }

    public float healing() //healing function
    {
        float heal; //creates float
        heal = PlayerHealth.max / 10; //makes float = to player health divided by 10 
        return heal; //retuns healing value 
    }

    void Destroy() //destroy function
    {
        Destroy(gameObject); //destorys game object 
        Debug.Log(healing()); //debugs healing value 
    }
}
