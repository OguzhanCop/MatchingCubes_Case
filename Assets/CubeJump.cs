using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeJump : MonoBehaviour
{
    int countCube;
    int indexCube;
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
}
