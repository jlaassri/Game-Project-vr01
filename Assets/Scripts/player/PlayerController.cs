using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrHealth;

    public int Dmg = 10;

    public float MaxSpeed = 1.5f;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    void Start()
    {
        //sets health at scene start
        CurrHealth = MaxHealth;



    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //facemouse();
    }
    
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MaxSpeed * Time.fixedDeltaTime);

        Vector2 look = mousePos - rb.position;

        float angle = Mathf.Atan2(look.y, look.x)* Mathf.Rad2Deg -90f;

        rb.rotation = angle;
    }

   /* void facemouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
    }*/
}
