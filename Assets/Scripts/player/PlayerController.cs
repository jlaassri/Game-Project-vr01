using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private UI_Inventory uiInventory;
    [SerializeField] private UI_stats Health;
    [SerializeField] private Inven Inven;

    private float maxHealth = 100;
    public float MaxHealth;
    public float CurrHealth = 0;
    public float Healthup;
    public static float Dmgup;
    public float Speedup;

    //public float MaxSpeed = 1.5f;

    public Rigidbody2D rb;
    public Camera cam;

    private Inventory inventory;

    Vector2 movement;
    Vector2 mousePos;

    void Start()
    {
        Health.Init();
        //sets health at scene start
        CurrHealth = MaxHealth;

        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

        inventory.GetItemList();

        
    }

    
    // Update is called once per frame
    void Update()
    {
        Health.CurrentVal = CurrHealth;
        Health.Maxval = MaxHealth;

        if (CurrHealth > MaxHealth)
        {
            CurrHealth = MaxHealth;
        }

        MaxHealth = maxHealth + Inven.healthUP * 6;
       // Debug.Log(MaxHealth);

        movement.x = Input.GetAxisRaw("Horizontal");

        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

       /*
        if (CurrHealth <= 0)
        {
            Debug.Log("you lose");
        }
        //facemouse(); */
    }
    
    
    
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MaxSpeed() * Time.fixedDeltaTime);

        Vector2 look = mousePos - rb.position;

        float angle = Mathf.Atan2(look.y, look.x)* Mathf.Rad2Deg -90f;

        rb.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ItemWorld itemWorld = other.GetComponent<ItemWorld>();
        if (itemWorld)
        {
            
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestorySelf();
            Debug.Log("collected");
        }

        if(other.gameObject.GetComponent<HealthUP>())
        {
            Healthup++;
        }
    }

    

    /*
    public float MaxHealth()
    {
        float maxHealth = 100;
       

        maxHealth = maxHealth + Healthup * 6;
        //Debug.Log($"You have {maxHealth.ToString()}");


        return maxHealth;
    }
    */
    public float MaxSpeed()
    {
        float maxspeed = 100f;
        

        maxspeed = maxspeed + Speedup / 2;
        
        return maxspeed;
    }

public static float Damage()
    {
        float damage = 10;

        damage = damage + Dmgup * 10;

        return damage;
    }


    /* void facemouse()
     {
         Vector3 mousePosition = Input.mousePosition;
         mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

         Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
         transform.up = direction;
     }*/
}
