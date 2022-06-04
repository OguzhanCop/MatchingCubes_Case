using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public GameObject caracterRig;
    Rigidbody rb;
    public GameObject redCube;

    private void Start()
    {
        rb = caracterRig.GetComponent<Rigidbody>();
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "red")
        {
            rb.AddForce(transform.up * 500);
            collision.gameObject.transform.parent=this.gameObject.transform;
            Instantiate(redCube);

        }
       
    }
}
