using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUP : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController)
        {

            playerController.Speedup++;
        }
    }
}


