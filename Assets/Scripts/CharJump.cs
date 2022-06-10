using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharJump : MonoBehaviour
{
    
    float charPosY;    
    void Start()
    {
        DOTween.Init();
        charPosY = transform.localPosition.y;
        
    }    
  
    public void CharDownPos(float value)
    {        
        transform.DOLocalMoveY(charPosY+value, 0.5f, false);
    }
    public void CharUpPos(float height )
    {        
        transform.DOLocalMoveY(charPosY + height +1.5f, 0.4f, false);
        StartCoroutine(CharFall(height));       
    }   
    
    IEnumerator CharFall(float height)
    {
        yield return new WaitForSecondsRealtime(0.4f);
        CharDownPos(height);
    }
    

}
