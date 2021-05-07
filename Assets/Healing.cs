using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    // Start is called before the first frame update
    

    private PlayerHealth playerHealth;
    public Transform player;

    private float Speed = 100;
    private float Stopdist;
    private float retreatdist;
    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    private void Update()
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerHealth.CurrHealth = PlayerHealth.CurrHealth + healing();
            Destroy();
        }
    }

    public float healing()
    {
        float heal;
        heal = PlayerHealth.max / 10;
        return heal;
    }

    void Destroy()
    {
        Destroy(gameObject);
        


        Debug.Log(healing());
    }
}
