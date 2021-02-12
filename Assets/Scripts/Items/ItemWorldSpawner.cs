using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    public Item item;

    void Start()
    {
        Debug.Log("awake");
        ItemWorld.SpawnItemWorld(transform.position, item);
        Destroy(gameObject);
    }
}
