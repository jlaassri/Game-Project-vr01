using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private GameObject player = null;

    private void Start()
    {
        if (player == null)
            player = GameObject.Find("Player");
    }
    public void Update()
    {
        //Vector2 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        Vector2 dir = (Camera.main.ScreenToWorldPoint(player.transform.position) - transform.position).normalized;
        transform.right = dir;
    }
}
