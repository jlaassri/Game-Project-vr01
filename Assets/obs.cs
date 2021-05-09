using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obs : MonoBehaviour
{
    private int scale;
    private Vector3 ScaleChange;

    private float degrees;
    private Quaternion RotationChange;
    // Start is called before the first frame update
    void Start()
    {
        scale = Random.Range(400, 600);
        degrees = Random.Range(0, 100);

        ScaleChange = new Vector3(scale, scale, 0);
        

        this.gameObject.transform.localScale += ScaleChange;
        this.gameObject.transform.eulerAngles = Vector3.forward * degrees;



    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(RotationChange);
        
    }
}
