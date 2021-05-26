using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obSpawner : MonoBehaviour
{
    public float timebtwshots;
    public float strartimer;
    public static float limmiter = 0;

    private float Force = 100;
    

    public GameObject ob;

    // Update is called once per frame
    void Update()
    {
        if (limmiter > 25)
        {
            limmiter = 10;
        }
        if (timebtwshots <= 0 & limmiter < 25)
        {

            Debug.Log("emSpawned");
            Shoot();
            timebtwshots = strartimer;

        }
        else
        {
            timebtwshots -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(ob, transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * Force, ForceMode2D.Impulse);
        limmiter++;
    }

}
