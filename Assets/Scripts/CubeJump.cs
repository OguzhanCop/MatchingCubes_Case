using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeJump : MonoBehaviour
{
    int countCube;
    int indexCube;
    public GameObject blueLava;
    public GameObject orangeLava;
    public GameObject yellowLava;
    void Start()
    {
        DOTween.Init();
    }
    public void match(int index,int count )
    {
        transform.DOLocalMoveY(count - index, 0.4f, false);
      
    }
    
    public void jumpCube(int index,int count)
    {
        transform.DOLocalMoveY(count - index+0.5f, 0.2f, false);
        countCube = count;
        indexCube = index;
        Invoke("fallCube", 0.4f);        


    }
    public void fallCube()
    {
        match(indexCube, countCube);       
    }
    public void burn(string colortag)
    {
        
        if (colortag == "blueclone")
            Instantiate(blueLava, new Vector3(transform.position.x, 0.5f, transform.position.z), transform.rotation);
        if (colortag == "orangeclone")
            Instantiate(orangeLava, new Vector3(transform.position.x, 0.5f, transform.position.z), transform.rotation);
        if (colortag == "yellowclone")
            Instantiate(yellowLava, new Vector3(transform.position.x, 0.5f, transform.position.z), transform.rotation);
        
    }
    
}
