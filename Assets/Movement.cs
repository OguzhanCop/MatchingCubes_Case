using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    Rigidbody rb;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        
    }


    void Update()
    {
        transform.Translate(0, 0, 20f*Time.deltaTime);

        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);
            turn(finger.deltaPosition.x);
            clampX(transform.position);
            
        }


        void turn(float fingerdiff)
        {
            if (fingerdiff !=0)
            {               
                transform.Translate(Mathf.Lerp(0, fingerdiff/2, 1f * Time.deltaTime), 0,0) ;
            }          

        }
        void clampX(Vector3 pos)
        {
            pos.x = Mathf.Clamp(transform.position.x, -2, 2);
            transform.position=pos;
        }
    }
}
