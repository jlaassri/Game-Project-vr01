using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //for any code that isnt my own, check relivent blog post for citation
    [SerializeField] private UI_Inventory uiInventory; //gets UI inven script 

    public float highestx = 1431;// highest boundries x
    public float lowestx = -1520; //lowest boundreies x
    public float highesty = 1643; //highest boundries y
    public float lowesty = -1590; //lowest boundries y
    public static float Dmgup; //dmg item value 
    public static float Speedup; //speed item value 
    public static float spreadup; //spread item value 
    public static float chainup; //chain item value 
    public static float lifeup; //lifeup item value 
    public static float firerateup; //firearte item value 
    public static float verlocityup; //velocity item value
    public static float lifetapup; //lifetap item vlaue 
    
    public Rigidbody2D rb; //get rigidbody2d
    public Camera cam; //gets camera 
   

    private Inventory inventory; //gets inventory script 

    Vector2 movement; //movment control 
    Vector2 mousePos; //mouse position 

    void Start()
    {
        inventory = new Inventory(); //creates new invetory 
        uiInventory.SetInventory(inventory); //sets Ui to inventory 

        inventory.GetItemList(); //gets inventory item list 
    }
    
    // Update is called once per frame
    void Update()
    {
        if (TimerController.Instance.TimeGoing == false) //if timer isnt running 
        {
            TimerController.Instance.BeginTimer(); //starts timer 
        }
        

        movement.x = Input.GetAxisRaw("Horizontal"); //movement using input map

        movement.y = Input.GetAxisRaw("Vertical");//movement using input map

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); // roation mouse pos 


        if(this.gameObject.transform.position.x >= highestx) //checks if posx is > highestx
        {
            this.gameObject.transform.position = new Vector3(highestx,gameObject.transform.position.y,gameObject.transform.position.z); //stops movement if true
        }

        if (this.gameObject.transform.position.x <= lowestx) //checks if posx is < lowestx
        {
            this.gameObject.transform.position = new Vector3(lowestx, gameObject.transform.position.y, gameObject.transform.position.z);//stops movement if true
        }

        if (this.gameObject.transform.position.y >= highesty) //checks if posy is > highesty
        {
            this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, highesty, gameObject.transform.position.z);//stops movement if true
        }

        if (this.gameObject.transform.position.y <= lowesty)//checks if posy is < lowesty
        {
            this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, lowesty, gameObject.transform.position.z);//stops movement if true
        }
    }
    
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MaxSpeed() * Time.fixedDeltaTime); // controls movment by speed function through rigidbody

        Vector2 look = mousePos - rb.position;  //gets mouse position 

        float angle = Mathf.Atan2(look.y, look.x)* Mathf.Rad2Deg; //contvert to z value 

        rb.rotation = angle; //sets gameobject oration to mouse pos
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ItemWorld itemWorld = other.GetComponent<ItemWorld>(); //gets item world compoenent 
        if (itemWorld)  //if object has itme world 
        {
            SoundManager.PlaySound("pickup"); //plays pick up sound 
            inventory.AddItem(itemWorld.GetItem()); //adds itme to UI inven
            itemWorld.DestorySelf(); //destorys self 
            Debug.Log("collected");// debug for checking 
        }

        // checks item for sprite name, if matches adds 1 to inventory
        if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name == "HealthSprite" )
        {
            PlayerHealth.Healthup++;
            Debug.Log("Healthup");
        }

        if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name == "DmgSprite")
        {
            Dmgup++;
            Debug.Log("Dmgup");
        }

        if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name == "SpeedSprite")
        {
            Speedup++;
            Debug.Log("speedup");
        }

        if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name == "ChainSprite")
        {
            chainup++;
            Debug.Log("chainup");
        }

        if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name == "SpreadSprite")
        {
            spreadup++;
            Debug.Log("spreadup");
        }

        if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name == "LifeSprite")
        {
            lifeup++;
            Debug.Log("lifeup");
        }

        if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name == "VerlocitySprite")
        {
            verlocityup++;
            Debug.Log("verlocityup");
        }

        if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name == "LifeTapSprite")
        {
            lifetapup++;
            Debug.Log("lifetapup");
        }
    }

    

    public float MaxSpeed() //speed function
    {
        float Maxspeed = 100f; //base value 
        

        Maxspeed = Maxspeed + Speedup / 2; //speed cal 
        
        return Maxspeed; //output
    }

public static float Damage() //damge function
    {
        float damage = 10; //base value

        damage = damage + Dmgup * 10;// dmg cal 

        return damage; //output
    }

}
