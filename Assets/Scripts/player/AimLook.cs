using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLook : MonoBehaviour
{
    //for any code that isnt my own, check relivent blog post for citation
    private void Update()
    {
        Vector2 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized; //get mouse pos 
        transform.right = dir; //rotate to mouse pos 
    }
}
