using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform ProjectileSpawnPosition; // GameObject that determines where the proj spawns
    private Transform AimOrigin; // Parented to Player. Has AimLook Script
    [SerializeField] private GameObject bulletprefab;

    private int NumberOfProjectiles = 3;

     private float SpreadAngle = 360;

    public float timer = 1f;
    public float procchance;
    private int currProb;
    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }

        procchance = PlayerController.chainup * 4;

        ProjectileSpawnPosition = this.gameObject.transform;
        AimOrigin = this.gameObject.transform;
    }

    public float Force()
    {
        float force = 300f;

        force = force + PlayerController.verlocityup * 10;

        return force;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle") || collision.gameObject.CompareTag("enemy"))
        {
            if (PlayerController.chainup > 0)
            {
                currProb = Random.Range(0, 100);
                if (currProb <= procchance)
                {
                    Chain();
                }
            }
            Destroy(gameObject);
        }
    }
 
    public void Chain()
    {
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
}
