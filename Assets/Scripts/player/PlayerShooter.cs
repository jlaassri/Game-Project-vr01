using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    //for any code that isnt my own, check relivent blog post for citation
    [SerializeField] private Transform ProjectileSpawnPosition; // GameObject that determines where the proj spawns
    [SerializeField] private Transform AimOrigin; // Parented to Player. Has AimLook Script
    [SerializeField] private GameObject bulletprefab; //gets bullet prefab 

    [SerializeField] private int NumberOfProjectiles = 3; //number of projectiles spwaned 

    [Range(0, 360)] //degrees 
    [SerializeField] private float SpreadAngle = 20; //ange of projectile spread 

   
    float firedelay = 1f; //fire delay vale 
    public float cooldowntimer = 0; //cooldwon timer 
    public float procchance; //procc chance 
    private int currProb; //current ptob 

    void Update()
    {
        if (cooldowntimer >= 0) //if timer > 0
        {
            cooldowntimer -= Time.deltaTime; //reset timer 
        }
        if (Input.GetButton("Fire") && cooldowntimer <= 0) //if player hit fire input 
        {
            currProb = Random.Range(0, 100); //random number between 0 & 100
            if (currProb <= procchance & PlayerController.spreadup > 0) //if procchance is > & spread item is > 0
            {
                Debug.Log("multifire"); //debug for checking
                cooldowntimer = firedelay; //resest timer 
                SoundManager.PlaySound("playershoot"); //plays shooting sound effect 
                MultiShoot(); //runs multi-shoot function 
            }
            else
            {
                SoundManager.PlaySound("playershoot"); //plays shooting sound effect 
                Debug.Log("Fire");//debug for checking 
                cooldowntimer = firedelay;// reset timer 
                Shoot(); //runs shoot function
            }
        }

        procchance = PlayerController.spreadup * 4; //sets procc chance 

        if(procchance > 100) //if proc > 100
        {
            procchance = 100; // proc = 100
        }
    }
    
    public float FireDelay() //fire delay function
    {
        float firedelay = 0.025f; //base value

        firedelay = firedelay + PlayerController.firerateup - 0.7f; //delay cal
    
        return firedelay; //output
    }
    
    
    void Shoot() //shoot function
    {
        GameObject bullet = Instantiate(bulletprefab, ProjectileSpawnPosition.position, ProjectileSpawnPosition.rotation); //spawns bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); //get rigidbody2d
        rb.AddForce(ProjectileSpawnPosition.up * Force(), ForceMode2D.Impulse); //applys force to object
    }



    public void MultiShoot() //multiple projectiles function
    {
        float angleStep = SpreadAngle / NumberOfProjectiles; //divides spread angle by the number of projectiles
        float aimingAngle = AimOrigin.rotation.eulerAngles.z; //gets aim postions rotation
        float centeringOffset = (SpreadAngle / 2) - (angleStep / 2); //offsets every projectile so the spread is                                                                                                                         //centered on the mouse cursor

        for (int i = 0; i < NumberOfProjectiles; i++) //for loop to spawn each projectile with each 
        {
            float currentBulletAngle = angleStep * i; // set the angle step to each projectile

            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, aimingAngle + currentBulletAngle - centeringOffset)); //roation cal for the multiple projectiles
            GameObject bullet = Instantiate(bulletprefab, ProjectileSpawnPosition.position, rotation);// spawns bullets aty spawn location but with rotation cal

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); //gets bullet rigidbody 
            rb.AddForce(bullet.transform.right * Force(), ForceMode2D.Impulse); //adds force to porjectile 
        }
    }

    public float Force() //force function
    {
        float force = 300f; //base value

        force = force + PlayerController.verlocityup * 10; //verlocity cal

        return force; //output
    }
    
}
