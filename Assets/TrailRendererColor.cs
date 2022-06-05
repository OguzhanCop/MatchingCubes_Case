using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRendererColor : MonoBehaviour
{
    
   
    public void color(Material color)
    {
        this.GetComponent<TrailRenderer>().material = color;       

    }
    public void trail(GameObject cube)
    {
        transform.position = cube.transform.position;
        transform.parent = cube.transform;
    }
}
