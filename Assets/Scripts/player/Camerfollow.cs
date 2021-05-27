using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerfollow : MonoBehaviour
{
    //for any code that isnt my own, check relivent blog post for citation
    public Transform mytarget; //set ot player 
    // Update is called once per frame
    void Update()
    {
       if(mytarget != null) //if target is not empty
        {
            Vector3 targpos = mytarget.position;  //target position
            targpos.z = transform.position.z; //self rotation change 
            transform.position = targpos; //moves to target position
        }
    }
}
