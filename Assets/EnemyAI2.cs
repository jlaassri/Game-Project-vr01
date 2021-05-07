using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI2 : MonoBehaviour
{
    public Transform player;
    public float maxhealth = 50;
    public float currhealth = 50;
    public float Dmg = 20;

    public float Speed;
    private float Stopdist;
    private float retreatdist;
    private Rigidbody2D rb;
    private Vector2 movement;

    
    public LootTable thisloot;

    //public GameObject Health;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        maxhealth = currhealth;


    }

    void Update()
    {

        if (Vector2.Distance(transform.position, player.position) > Stopdist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, Speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < Stopdist && Vector2.Distance(transform.position, player.position) > retreatdist)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatdist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -Speed * Time.deltaTime);
        }
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

       

        if (currhealth <= 0)
        {
            Debug.Log("Destroy");
            Destroy();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Damage();

            Debug.Log("Damage");
        }

        if(other.gameObject.CompareTag("Player"))
        {
            DamagePlayer();
            Destroy();
        }
    }

    void Damage()
    {
        currhealth = currhealth - PlayerController.Damage();
    }

    void DamagePlayer()
    {
        PlayerHealth.CurrHealth = PlayerHealth.CurrHealth - Dmg;
        //Player.UpdateHealth();
        this.gameObject.SetActive(false);
    }
    private void MakeItems()
    {
        if (thisloot != null)
        {
            GameObject current = thisloot.LootPowerup();
            if (current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);

            }
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
        MakeItems();


        Debug.Log("Death");
    }

}
