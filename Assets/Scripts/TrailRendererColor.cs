using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRendererColor : MonoBehaviour
{
    
   
    public void Color(Material color)
    {
        this.GetComponent<TrailRenderer>().material = color;       

    }
    public void TrailFollow(Transform cube)
    {
        transform.position = cube.transform.position;
        transform.parent = cube.transform;
    }
}
