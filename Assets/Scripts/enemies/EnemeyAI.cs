using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyAI : MonoBehaviour
{
    public Transform player;
    public float Speed;
    public float Stopdist;
    public float retreatdist;
    private Rigidbody2D rb;
    private Vector2 movement;

    private float timebtwshots;
    public float strartimer;
    public GameObject bullet;
    

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        
    }

    void Update()
    {

        if(Vector2.Distance(transform.position, player.position) > Stopdist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, Speed * Time.deltaTime);
        }else if(Vector2.Distance(transform.position, player.position) < Stopdist && Vector2.Distance(transform.position, player.position) > retreatdist)
        {
            transform.position = this.transform.position;
        }else if(Vector2.Distance(transform.position, player.position) < retreatdist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -Speed * Time.deltaTime);
        }
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (timebtwshots <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            timebtwshots = strartimer;
        }else
        {
            timebtwshots -= Time.deltaTime;
        }
    }

}
