using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ebullet : MonoBehaviour
{
    public float speed;

    [SerializeField] public PlayerController Player;

    public int Dmg = 10;
    private Transform player;
    private Vector2 target;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);


        
    }

  
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        

    }

    void Damage()
    {
        Player.CurrHealth = Player.CurrHealth - Dmg;
        //Player.UpdateHealth();
        this.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Damage();
            DestroyEbullet();

            Debug.Log("hit");
        }
    }

    
    void DestroyEbullet()
    {

        Destroy(gameObject);


    }


}
