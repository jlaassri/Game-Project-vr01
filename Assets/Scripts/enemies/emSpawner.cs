using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emSpawner : MonoBehaviour
{

    private float timebtwspawn; // time between spawns
    public float strartimer; // set timer 
    public static float limmiter = 0; //spawn limmiter

    public LootTable thisloot; //lootable

    // Update is called once per frame
    void Update()
    {
        if (limmiter > 25) //limmiter check 
        {
            limmiter = 25; //if limmiter is > 25, set to 25
        }
        if (timebtwspawn <= 0 & limmiter < 25)// checks if time between shoots & limmiter is within range 
        {
            Debug.Log("emSpawned"); //debug for checking
            MakeItems(); //runs enemy spawner loot tables
            timebtwspawn = strartimer; //reset timer
        }
        else
        {
            timebtwspawn -= Time.deltaTime; //time passing call
        }
    }

    private void MakeItems()// spawner function
    {
        if (thisloot != null) //checks if loot  table is empty
        {
            GameObject current = thisloot.LootPowerup(); //gets result from the loot table
            if (current != null) //checks if loot table has any retruns
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity); //spawns returned enemies
                limmiter++; //increases limmiter value by 1
            }
        }
    }

}
