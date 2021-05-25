using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI3 : MonoBehaviour
{
    private GameObject player = null; //gets player gameobject
    private PlayerHealth Health; //gets player health script 
    public float maxhealth; //max health value
    private float currhealth; //current health value
    public float Stopdist; // stoping distance 
    public float retreatdist; //retreat distance
    private Rigidbody2D rb; //gets rigidbody2d 

    private float timebtwshots; //time between shoots
    public float starttimer; // start time
    public GameObject Bullet; //bullet prefab
    public LootTable thisloot; //loot table

    [SerializeField] private Transform ProjectileSpawnPosition; // GameObject that determines where the proj spawns
    [SerializeField] private Transform AimOrigin; // Parented to Player. Has AimLook Script
    

    [SerializeField] private int NumberOfProjectiles; //number of projectiles 

    [Range(0, 360)] //range between 0 - 360, radius of a circle
    [SerializeField] private float SpreadAngle = 20; //projectile spread 


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
        else if (Vector2.Distance(transform.position, player.transform.position) < Stopdist && Vector2.Distance(transform.position, player.transform.position) > retreatdist) //checks if enemy is with stopping distance but not retreat distance 
        {
            transform.position = this.transform.position; //stops movement 
        }
        else if (Vector2.Distance(transform.position, player.transform.position) < retreatdist)// checks if player is with retreat distance 
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -Speed() * Time.deltaTime); //retreats from player 
        }
        Vector3 direction = player.transform.position - transform.position; //set vector3 to the player position
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // converts player position into rotation angle
        rb.rotation = angle; // sets the rigidbody to this roation angle

        if (timebtwshots <= 0) //checks if the time between shoots is < 0
        {
            MultiShoot(); // runs shooting function if the timer is < 0
            timebtwshots = starttimer; // resets timer 
        }
        else //if not
        {
            timebtwshots -= Time.deltaTime; //timer is reduced by seconds
        }

        if (currhealth <= 0) //checks if current health value is < 0
        {
            Debug.Log("Destroy");// debug for checking if working
            Destroy(); // calls destroy function
        }
    }

    public float Speed() //speed function
    {
        float speed = 50; //base speed value
        speed = speed + EnTimer.EnPower * 10; // adds enemy power to speed * 10 
        return speed; //returns speed value
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
            GameObject bullet = Instantiate(Bullet, ProjectileSpawnPosition.position, rotation);// spawns bullets aty spawn location but with rotation cal

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); //gets bullet rigidbody 
            rb.AddForce(bullet.transform.right * Force(), ForceMode2D.Impulse); //adds force to porjectile 
        }
    }

    public float Force() //force function
    {
        float force = 400f; //sets base speed
        force = force + EnTimer.EnPower * 10; //adds enemy power to base power * 10
        return force; //returns total value
    }

    public float MaxHealth() // max health function
    {
        maxhealth = maxhealth + EnTimer.EnPower * 10; //max health + enemy power 
        return maxhealth;// returns health value
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
    }

    void Damage() //damage  function
    {
        currhealth = currhealth - PlayerController.Damage(); //damage equation
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
        Destroy(gameObject); // destroys game object
        MakeItems();// runs item spaawner function
        Debug.Log("Death"); //debug if enemy dies
    }
}
