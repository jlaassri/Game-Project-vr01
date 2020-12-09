using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{

    public Transform firepoint;
    public GameObject bulletprefab;

    public float force = 10f;
    public float FireDelay = 0.025f;
    float cooldowntimer = 0;

    void Update()
    {
        cooldowntimer -= Time.deltaTime;

        /*if (Input.GetButton("Fire") && cooldowntimer <= 0)
        {
            Debug.Log("fire");
            cooldowntimer = FireDelay;
            Shoot();
        }*/

        if (Input.GetButton("Fire") )
        {
            Debug.Log("fire");
            Shoot();
        }

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * force, ForceMode2D.Impulse);
    }
}
