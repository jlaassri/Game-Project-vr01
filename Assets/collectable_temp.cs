using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable_temp : MonoBehaviour
{
    private Transform player;
    private Vector2 Player;
    private Vector2 coll;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Player = new Vector2(player.position.x, player.position.y);
        coll = gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (coll.x == Player.x & coll.y == Player.y)
        {
            DestroyColl();
        }
        
    }

    void TriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyColl();

        }

    }

    void DestroyColl()
    {
        Destroy(gameObject);
    }


}
