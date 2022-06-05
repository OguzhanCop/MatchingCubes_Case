using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharJump : MonoBehaviour
{
    float charPosY;
    float height;
    void Start()
    {
        DOTween.Init();
        charPosY = transform.localPosition.y;
    }    
    void Update()
    {
        height = PlayerPrefs.GetFloat("height");
        Debug.Log(height);
    }
    public void match(float value)
    {
        
        transform.DOLocalMoveY(charPosY+value, 0.2f, false);
    }
    public void jump( )
    {
        transform.DOLocalMoveY(charPosY + height +1.5f, 0.4f, false);
        Invoke("fall", 0.4f);

    }
   
    public void fall()
    {
        transform.DOLocalMoveY(charPosY + height, 0.2f, false);
    }
}
