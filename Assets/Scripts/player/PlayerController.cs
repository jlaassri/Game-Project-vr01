using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrHealth;

    public int Dmg = 10;

    public float MaxSpeed = 1.5f;


    void Start()
    {
        //sets health at scene start
        CurrHealth = MaxHealth;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        //moves ship 
        Vector3 pos = transform.position;

        transform.position = pos;

        pos.y += Input.GetAxis("Vertical") * MaxSpeed * Time.deltaTime;

        pos.x += Input.GetAxis("Horizontal") * MaxSpeed * Time.deltaTime;

        
        


    }
}
