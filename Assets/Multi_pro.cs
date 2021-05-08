using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multi_pro : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPosition; // GameObject that determines where the proj spawns
    [SerializeField] private Transform AimOrigin; // Parented to Player. Has AimLook Script
    [SerializeField] private GameObject BulletPrefab;

    [SerializeField] private int NumberOfProjectiles = 3;

    [Range(0, 360)]
    [SerializeField] private float SpreadAngle = 20;

   

    public float Force()
    {
        float force = 400f;

        force = force + PlayerController.verlocityup * 10;

        return force;
    }

    public void Shoot()
    {
        Debug.Log("it works 4head");
        float angleStep = SpreadAngle / NumberOfProjectiles;
        float aimingAngle = AimOrigin.rotation.eulerAngles.z;
        float centeringOffset = (SpreadAngle / 2) - (angleStep / 2); //offsets every projectile so the spread is                                                                                                                         //centered on the mouse cursor

        for (int i = 0; i < NumberOfProjectiles; i++)
        {
            float currentBulletAngle = angleStep * i;

            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, aimingAngle + currentBulletAngle - centeringOffset));
            GameObject bullet = Instantiate(BulletPrefab, ProjectileSpawnPosition.position, rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(bullet.transform.right * Force(), ForceMode2D.Impulse);
        }
    }
}

