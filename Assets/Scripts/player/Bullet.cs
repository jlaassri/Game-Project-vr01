using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //for any code that isnt my own, check relivent blog post for citation
    private Transform ProjectileSpawnPosition; // GameObject that determines where the proj spawns
    private Transform AimOrigin; // Parented to Player. Has AimLook Script
    [SerializeField] private GameObject bulletprefab; // bullety prefab

    private int NumberOfProjectiles = 3; //num of porjectiles

     private float SpreadAngle = 360; //spread angle 

    public float timer = 1f; //timer 
    public float procchance; //procc chance value
    private int currProb; //current prob
    public void Update()
    {
        timer -= Time.deltaTime; //decreases timer 
        if (timer <= 0) //checks timer 
        {
            Destroy(gameObject); //destroy self
        }

        procchance = PlayerController.chainup * 4; //set proc value

        ProjectileSpawnPosition = this.gameObject.transform;// sets spwan point 
        AimOrigin = this.gameObject.transform; //sets aim origing
    }

    public float Force() //force function
    {
        float force = 300f; //base value

        force = force + PlayerController.verlocityup * 10; //verlocity cal

        return force; //output
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle") || collision.gameObject.CompareTag("enemy")) //on hit with enemy or ob
        {
            if (PlayerController.chainup > 0) //check chain value
            {
                currProb = Random.Range(0, 100); //random number generated
                if (currProb <= procchance) // if currprob < procc
                {
                    Chain(); //run chain function
                }
            }
            Destroy(gameObject); //destroy self
        }
    }

    public void Chain() //Chain projectiles function
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
}
