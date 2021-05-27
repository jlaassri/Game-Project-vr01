using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    //for any code that isnt my own, check relivent blog post for citation
    public Item item; //gets item class

    void Start()
    {
        Debug.Log("awake"); //check on awake 
        ItemWorld.SpawnItemWorld(transform.position, item); //call spanw item function 
        Destroy(gameObject); //destroys after spwans clone 
    }
}
