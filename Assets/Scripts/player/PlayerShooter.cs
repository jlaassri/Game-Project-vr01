using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{

    public Transform firepoint;
    public GameObject bulletprefab;
    float firedelay = 1f;
    public static float firerateup = 0;
    public float force = 400f;
    public float cooldowntimer = 0;

    void Update()
    {
        if (cooldowntimer >= 0)
        {
            cooldowntimer -= Time.deltaTime;
        }
        if (Input.GetButton("Fire") && cooldowntimer <= 0)
        {
            Debug.Log("fire");
            cooldowntimer = firedelay;
            Shoot();
        }
        /*
        if (Input.GetButton("Fire") )
        {
            Debug.Log("fire");
            Shoot();
        }*/

    }
    /*
    public float FireDelay()
    {
        float firedelay = 0.025f;

        firedelay = firedelay + firerateup - 0.005f;
    
        return firedelay;
    }
    */
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * force, ForceMode2D.Impulse);
    }
}
