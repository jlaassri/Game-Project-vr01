using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emSpawner : MonoBehaviour
{

    private float timebtwshots;
    public float strartimer;
    public static float limmiter = 0;

    public LootTable thisloot;

    // Update is called once per frame
    void Update()
    {
        if (limmiter > 25)
        {
            limmiter = 25;
        }
        if (timebtwshots <= 0 & limmiter < 25)
        {
            
            Debug.Log("emSpawned");
            MakeItems();
            timebtwshots = strartimer;
            
        }
        else
        {
            timebtwshots -= Time.deltaTime;
        }
    }

    private void MakeItems()
    {
        if (thisloot != null)
        {
            GameObject current = thisloot.LootPowerup();
            if (current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
                limmiter++;
            }
        }
    }

}
