using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public float FireDelay = 0.025f;
    float cooldowntimer = 0;

    void Update()
    {
        cooldowntimer -= Time.deltaTime;

        if (Input.GetButton("Fire") && cooldowntimer <= 0)
        {
            Debug.Log("fire");
            cooldowntimer = FireDelay;
        }

    }
}
