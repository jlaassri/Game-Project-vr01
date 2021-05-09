using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obs : MonoBehaviour
{
    private int scale;
    private Vector3 ScaleChange;

    private float rotation;
    private Quaternion RotationChange;
    // Start is called before the first frame update
    void Start()
    {
        scale = Random.Range(400, 600);
        rotation = Random.Range(0, 100);

        ScaleChange = new Vector3(scale, scale, 0);
        RotationChange = new Quaternion(0,0,rotation);

        this.gameObject.transform.localScale += ScaleChange;
        this.gameObject.transform.localRotation = RotationChange;



    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(RotationChange);
        
    }
}
