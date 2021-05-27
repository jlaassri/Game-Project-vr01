using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obSpawner : MonoBehaviour
{
    //for any code that isnt my own, check relivent blog post for citation
    public float timebtwshots; //timer between spawn
    public float strartimer; //sets timer 
    public static float limmiter = 0; //limmiter for spawner 

    private float Force = 100; //force value 
    public GameObject ob; // gets game object 

    // Update is called once per frame
    void Update()
    {
        if (limmiter > 25) //if limmiter > 25
        {
            limmiter = 10; //sets limmiter to 10
        }
        if (timebtwshots <= 0 & limmiter < 25) //if timer is 0 and limmiter < 25
        {
            Debug.Log("emSpawned"); //debug checking 
            Shoot(); //spawn enemy 
            timebtwshots = strartimer; //reset timer 
        }
        else
        {
            timebtwshots -= Time.deltaTime; //reset timer 
        }
    }

    void Shoot() //spwaner function 
    {
        GameObject bullet = Instantiate(ob, transform.position, transform.rotation);// spawns enemy  
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); //gets enemy rigidbody 
        rb.AddForce(transform.up * Force, ForceMode2D.Impulse); //appys force to rigidbody 
        limmiter++; // increaese limmiter by 1 
    }

}
