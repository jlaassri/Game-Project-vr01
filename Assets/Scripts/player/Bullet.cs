using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    public int numberOfProjectiles;

    [SerializeField]
    GameObject projectile;

    Vector2 startPoint;

    float radius, moveSpeed;

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
    }

    public float Force()
    {
        float force = 400f;

        force = force + PlayerController.verlocityup * 10;

        return force;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        if (PlayerController.chainup > 0)
        {
            currProb = Random.Range(0, 100);
            if (currProb <= procchance)
            {
                SpawnProjectiles(numberOfProjectiles);
            }
        }
    }

    public void SpawnProjectiles(int numberOfProjectiles)
    {
        float angleStep = 360f / numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i <= numberOfProjectiles - 1; i++)
        {

            float projectileDirXposition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYposition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector2 projectileVector = new Vector2(projectileDirXposition, projectileDirYposition);
            Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * Force();

            var proj = Instantiate(projectile, startPoint, Quaternion.identity);
            proj.GetComponent<Rigidbody2D>().velocity =
                new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

            angle += angleStep;
        }
    }
}
