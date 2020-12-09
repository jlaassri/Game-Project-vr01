using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerfollow : MonoBehaviour
{


    public Transform mytarget;
    // Update is called once per frame
    void Update()
    {
       if(mytarget != null)
        {
            Vector3 targpos = mytarget.position;
            targpos.z = transform.position.z;
            transform.position = targpos;
        }
    }
}
