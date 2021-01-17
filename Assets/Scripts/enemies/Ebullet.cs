using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ebullet : MonoBehaviour
{
    public float speed;

    [SerializeField] public PlayerController Player;

    public int Dmg;
    private Transform player;
    private Vector2 target;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);


        Dmg = 10;
    }

  
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        

    }

    public void Damage()
    {
        Dmg = 10;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyEbullet();

            Damage();

            Debug.Log("hit");
        }
    }

    
    void DestroyEbullet()
    {
        Destroy(gameObject);


    }


}
