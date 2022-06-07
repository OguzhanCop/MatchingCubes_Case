using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCube : MonoBehaviour
{
    [SerializeField] int counter;
    int index;
    GameObject Collector;
    bool des = true;
    void Start()
    {
        Collector = GameObject.FindGameObjectWithTag("collector");
    }

    // Update is called once per frame
    void Update()
    {
        index = (int)transform.position.y;
        if (counter == 2)

            Invoke("wait", 0.2f);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "yellowclone")
            counter++;

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "yellowclone")
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