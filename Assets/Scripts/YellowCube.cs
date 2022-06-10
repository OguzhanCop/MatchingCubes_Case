using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCube : MonoBehaviour

{
    GameObject instantiateDiamond;
    
    int touchSameColor;
    int indexList;
    bool oneMore = true;
    GameObject Collector;
   
    void Start()
    {
        instantiateDiamond = GameObject.Find("InstantiateDia");
        Collector = GameObject.FindGameObjectWithTag("collector");
    }
    
    void Update()
    {
        indexList = (int)transform.localPosition.y;
        if (touchSameColor == 2)
        {
            Invoke("waitDestroy", 0.2f);
            

        }
            

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "yellowclone")
            touchSameColor++;

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "yellowclone")
            touchSameColor--;
    }
    void waitDestroy()
    {
        if (oneMore)
        {
            oneMore = false;
            Collector.GetComponent<Collector>().SameColorCheck(indexList);
            instantiateDiamond.GetComponent<Diamond>().InstantiateDiamond(this.transform);


        }

    }

}
