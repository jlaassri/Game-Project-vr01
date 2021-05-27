using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    //for any code that isnt my own, check relivent blog post for citation
    private GameObject player = null; //gets player game object

    private void Start()
    {
        if (player == null)// checks if gameobject is empty
            player = GameObject.Find("Player"); //sets the player gameobject to the player 
    }
    public void Update()
    {
        Vector2 dir = (Camera.main.ScreenToWorldPoint(player.transform.position) - transform.position).normalized; //sets dir vector2 to the players position 
        transform.right = dir;// transfroms object to target rotation
    }
}
