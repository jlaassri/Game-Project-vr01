using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPosition; // GameObject that determines where the proj spawns
    [SerializeField] private Transform AimOrigin; // Parented to Player. Has AimLook Script
    [SerializeField] private GameObject bulletprefab;

    [SerializeField] private int NumberOfProjectiles = 3;

    [Range(0, 360)]
    [SerializeField] private float SpreadAngle = 20;

    //public Transform firepoint;
    private Multi_pro multipro;
    float firedelay = 1f;
    public float cooldowntimer = 0;
    public float procchance;
    private int currProb;

    void Update()
    {

        if (cooldowntimer >= 0)
        {
            cooldowntimer -= Time.deltaTime;
        }
        if (Input.GetButton("Fire") && cooldowntimer <= 0)
        {
            currProb = Random.Range(0, 100);
            if (currProb <= procchance)
            {
                Debug.Log("multifire");
                cooldowntimer = firedelay;

                MultiShoot();
            }
            else
            {
                Debug.Log("Fire");
                cooldowntimer = firedelay;
                Shoot();
            }
        }

        procchance = PlayerController.spreadup * 4;

        if(procchance > 100)
        {
            procchance = 100;
        }


        //Debug.Log(procchance);
    }

    
    public float FireDelay()
    {
        float firedelay = 0.025f;

        firedelay = firedelay + PlayerController.firerateup - 0.005f;
    
        return firedelay;
    }
    
    
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletprefab, ProjectileSpawnPosition.position, ProjectileSpawnPosition.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(ProjectileSpawnPosition.up * Force(), ForceMode2D.Impulse);
    }



    private void MultiShoot()
    {
        //Debug.Log("it works 4head");
        float angleStep = SpreadAngle / NumberOfProjectiles;
        float aimingAngle = AimOrigin.rotation.eulerAngles.z;
        float centeringOffset = (SpreadAngle / 2) - (angleStep / 2); //offsets every projectile so the spread is                                                                                                                         //centered on the mouse cursor

        for (int i = 0; i < NumberOfProjectiles; i++)
        {
            float currentBulletAngle = angleStep * i;

            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, aimingAngle + currentBulletAngle - centeringOffset));
            GameObject bullet = Instantiate(bulletprefab, ProjectileSpawnPosition.position, rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(bullet.transform.right * Force(), ForceMode2D.Impulse);
        }
    }

    public float Force()
    {
        float force = 400f;

        force = force + PlayerController.verlocityup * 10;

        return force;
    }
    
}
