using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private UI_Inventory uiInventory;
    //private PlayerHealth Health;
    //[SerializeField] private Inven Inven;

    public float highestx = 1431;
    public float lowestx = -1520;
    public float highesty = 1643;
    public float lowesty = -1590;
    public static float Dmgup;
    public static float Speedup;
    public static float spreadup;
    public static float chainup;
    public static float lifeup;
    public static float firerateup;
    public static float verlocityup;
    

    //public float MaxSpeed = 1.5f;

    public Rigidbody2D rb;
    public Camera cam;
   

    private Inventory inventory;

    Vector2 movement;
    Vector2 mousePos;


    void Start()
    {
        //sets health at scene start
        
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

        inventory.GetItemList();

    }

    
    // Update is called once per frame
    void Update()
    {
        if (TimerController.Instance.TimeGoing == false)
        {
            TimerController.Instance.BeginTimer();
        }
        //Debug.Log(Healthup);

        // Debug.Log(MaxHealth);

        //Debug.Log(maxspeed);

        movement.x = Input.GetAxisRaw("Horizontal");

        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);


        if(this.gameObject.transform.position.x >= highestx)
        {
            this.gameObject.transform.position = new Vector3(highestx,gameObject.transform.position.y,gameObject.transform.position.z);
        }

        if (this.gameObject.transform.position.x <= lowestx)
        {
            this.gameObject.transform.position = new Vector3(lowestx, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        if (this.gameObject.transform.position.y >= highesty)
        {
            this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, highesty, gameObject.transform.position.z);
        }

        if (this.gameObject.transform.position.y <= lowesty)
        {
            this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, lowesty, gameObject.transform.position.z);
        }

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

        if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name == "HealthSprite" )
        {
            PlayerHealth.Healthup++;
            Debug.Log("Healthup");
        }

        if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name == "SpeedSprite")
        {
            Speedup++;
            Debug.Log("speedup");
        }

        if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name == "ChainSprite")
        {
            chainup++;
            Debug.Log("speedup");
        }

        if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name == "SpreadSprite")
        {
            spreadup++;
            Debug.Log("speedup");
        }

        if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name == "LifeSprite")
        {
            lifeup++;
            Debug.Log("speedup");
        }

        if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name == "VerlocitySprite")
        {
            verlocityup++;
            Debug.Log("speedup");
        }
    }

    

    
    
    
    public float MaxSpeed()
    {
        float Maxspeed = 100f;
        

        Maxspeed = Maxspeed + Speedup / 2;
        
        return Maxspeed;
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
