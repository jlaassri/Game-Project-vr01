using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUP : MonoBehaviour
{

    [SerializeField] private Inven Inven;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController)
        {

            Inven.healthUP+=1;
            Debug.Log("healthup");
        }
    }
}

