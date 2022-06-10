using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OrangeCube : MonoBehaviour
{
    GameObject instantiateDiamond;
    
    int touchSameColor;    
    int indexList;
    bool oneMore=true;
    GameObject Collector;
    void Start()
    {
        DOTween.Init();        
        Collector = GameObject.FindGameObjectWithTag("collector");
        instantiateDiamond = GameObject.Find("InstantiateDia");
    }

 
    void Update()
    {
        indexList = (int)transform.localPosition.y;
        if (touchSameColor == 2)
            Invoke("waitDestroy", 0.2f);           

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "orangeclone")
            touchSameColor++;
            
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "orangeclone")
            touchSameColor--;

    }
    void waitDestroy()
    {
        if (oneMore)
        {
            oneMore= false;
            Collector.GetComponent<Collector>().SameColorCheck(indexList);
            instantiateDiamond.GetComponent<Diamond>().InstantiateDiamond(this.transform);


        }

    }


}
