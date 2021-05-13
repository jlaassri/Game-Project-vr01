using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI3 : MonoBehaviour
{
    private GameObject player = null;
    private Explsion explsion;
    private PlayerHealth Health;


    public int numberOfProjectiles;
    public float maxhealth = 50;
    public float currhealth = 50;
    public float Speed;
    public float Stopdist;
    public float retreatdist;
    private Rigidbody2D rb;
    private Vector2 movement;

    private float timebtwshots;
    public float strartimer;
    public GameObject Bullet;
    public LootTable thisloot;

    [SerializeField] private Transform ProjectileSpawnPosition; // GameObject that determines where the proj spawns
    [SerializeField] private Transform AimOrigin; // Parented to Player. Has AimLook Script
    

    [SerializeField] private int NumberOfProjectiles = 3;

    [Range(0, 360)]
    [SerializeField] private float SpreadAngle = 20;

    //public GameObject Health;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        maxhealth = currhealth;

        if (player == null)
            player = GameObject.Find("Player");
    }

    void Update()
    {

        if (Vector2.Distance(transform.position, player.transform.position) > Stopdist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.transform.position) < Stopdist && Vector2.Distance(transform.position, player.transform.position) > retreatdist)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.transform.position) < retreatdist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -Speed * Time.deltaTime);
        }
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (timebtwshots <= 0)
        {
            //Instantiate(bullet, transform.position, Quaternion.identity);
            MultiShoot();
            timebtwshots = strartimer;
        }
        else
        {
            timebtwshots -= Time.deltaTime;
        }

        if (currhealth <= 0)
        {
            Debug.Log("Destroy");
            Destroy();
        }

        //numberOfProjectiles = explsion.numberOfProjectiles;
    }
    public void MultiShoot()
    {
        Debug.Log("it works 4head");
        float angleStep = SpreadAngle / NumberOfProjectiles;
        float aimingAngle = AimOrigin.rotation.eulerAngles.z;
        float centeringOffset = (SpreadAngle / 2) - (angleStep / 2); //offsets every projectile so the spread is                                                                                                                         //centered on the mouse cursor

        for (int i = 0; i < NumberOfProjectiles; i++)
        {
            float currentBulletAngle = angleStep * i;

            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, aimingAngle + currentBulletAngle - centeringOffset));
            GameObject bullet = Instantiate(Bullet, ProjectileSpawnPosition.position, rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(bullet.transform.right * Force(), ForceMode2D.Impulse);
        }
    }
    void shoot()
    {
        GameObject bullet = Instantiate(Bullet, ProjectileSpawnPosition.position, ProjectileSpawnPosition.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(ProjectileSpawnPosition.up * Force(), ForceMode2D.Impulse);
    }
    public float Force()
    {
        float force = 400f;

        return force;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Damage();
            if (PlayerController.lifetapup >= 1)
            {
                Health.lifetap();
            }
            Debug.Log("Damage");
        }
    }

    void Damage()
    {
        currhealth = currhealth - PlayerController.Damage();
    }

    private void MakeItems()
    {
        if (thisloot != null)
        {
            GameObject current = thisloot.LootPowerup();
            if (current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);

            }
        }
    }

    void Destroy()
    {

        Destroy(gameObject);
        MakeItems();


        Debug.Log("Death");
    }

}
