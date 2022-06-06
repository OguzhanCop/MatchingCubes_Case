using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeCube : MonoBehaviour
{
    int counter;
    GameObject Collector;
    int index;
    bool des=true;
    void Start()
    {
        Collector = GameObject.FindGameObjectWithTag("collector");
    }

 
    void Update()
    {
        index = (int)transform.position.y;
        if (counter == 2)
            Invoke("wait", 0.2f);
            

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "orangeclone")
            counter++;
            
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "orangeclone")
            counter--;

    }
    void wait()
    {
        if (des)
        {
            des = false;
            Collector.GetComponent<Collector>().match(index);

        }

    }

}
