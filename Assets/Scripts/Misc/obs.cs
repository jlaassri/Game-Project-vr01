using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obs : MonoBehaviour
{
    //for any code that isnt my own, check relivent blog post for citation
    public GameObject healer; //gets healer game object 
    private float currhealth; //current health
    private float maxhealth; //max  health 
    private float Force = 700f; //move force 
     

    private float timer = 50f; //timer 

    private int scale; //gameobject scale
    private Vector3 ScaleChange; //vector scale change 
    private float degrees; //roation
    
    // Start is called before the first frame update
    void Start()
    {
        maxhealth = 50; //sets max health 
        currhealth = maxhealth; //makes current = to max on start 
        scale = Random.Range(400, 600); //randomises scale 
        degrees = Random.Range(0, 100); //randomises degrees

        ScaleChange = new Vector3(scale, scale, 0); //changes scale 

        this.gameObject.transform.localScale += ScaleChange; //applys scale change to itself
        this.gameObject.transform.eulerAngles = Vector3.forward * degrees; //applys rotation change to itself

        //Rigidbody2D.AddForce(transform.position * Force, ForceMode2D.Impulse);
    }

    void Damage() //damge function 
    {
        currhealth = currhealth - PlayerController.Damage();  //damage cal
    }

    void Destroy() //destroy function
    {
        SoundManager.PlaySound("Obsdestroyed"); //plays the destroyed sound effect
        Instantiate(healer, transform.position, Quaternion.identity); //spawns healer orb
        Destroy(this.gameObject);// destroys this game object
        Debug.Log("Death");// debug for checking
    }

    // Update is called once per frame
    void Update() 
    {
        if(currhealth <= 0) //if health 0
        {
            Destroy(); //call destroy function 
        }

        timer -= Time.deltaTime; //timer always decreasing
        if (timer <= 0) //if time 0
        {
            Destroy(gameObject); //destroy self 
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet")) //if hit player bullet 
        {
            Damage(); //call damge cal 
        }
    }
}
