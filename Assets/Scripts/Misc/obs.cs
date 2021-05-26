using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obs : MonoBehaviour
{
    public GameObject healer;
    private float currhealth;
    private float maxhealth;
    private float Force = 700f;


    private float timer = 50f;

    private int scale;
    private Vector3 ScaleChange;
    private float degrees;
    
    // Start is called before the first frame update
    void Start()
    {
        maxhealth = 50;
        currhealth = maxhealth;
        scale = Random.Range(400, 600);
        degrees = Random.Range(0, 100);

        ScaleChange = new Vector3(scale, scale, 0);

        this.gameObject.transform.localScale += ScaleChange;
        this.gameObject.transform.eulerAngles = Vector3.forward * degrees;

        //Rigidbody2D.AddForce(transform.position * Force, ForceMode2D.Impulse);
    }

    void Damage()
    {
        currhealth = currhealth - PlayerController.Damage();
    }

    void Destroy()
    {
        SoundManager.PlaySound("Obsdestroyed"); //plays the destroyed sound effect
        Instantiate(healer, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Debug.Log("Death");
    }

    // Update is called once per frame
    void Update()
    {
        if(currhealth <= 0)
        {
            Destroy();
        }

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Damage();
        }
    }
}
