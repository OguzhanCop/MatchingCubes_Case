using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OrangeCube : MonoBehaviour
{
    public GameObject instantiateDiamond;
    
    int counter;
    GameObject Collector;
    int index;
    bool des=true;
    void Start()
    {
        DOTween.Init();        
        Collector = GameObject.FindGameObjectWithTag("collector");
        instantiateDiamond = GameObject.Find("InstantiateDia");
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
            instantiateDiamond.GetComponent<Diamond>().InstantiateDiamond(this.transform);


        }

    }


}
