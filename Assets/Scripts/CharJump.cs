using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharJump : MonoBehaviour
{
    public GameObject button;
    float charPosY;
    float height;
    void Start()
    {
        DOTween.Init();
        charPosY = transform.localPosition.y;
        
    }    
    void Update()
    {
        
        //height = PlayerPrefs.GetFloat("height");
        PlayerDead();

    }
    public void match(float value)
    {        
        transform.DOLocalMoveY(charPosY+value, 0.2f, false);
    }
    public void CharUpPos(float height )
    {        
        transform.DOLocalMoveY(charPosY + height +1.5f, 0.4f, false);
        StartCoroutine(Fall(height));
        //Invoke("fall", 0.4f);
    }   
    
    IEnumerator Fall(float height)
    {
        yield return new WaitForSecondsRealtime(0.4f);
        match(height);
    }
    public void PlayerDead()
    {
        if (height < 0)
        {
            Time.timeScale = 0;
            button.GetComponent<PlayButton>().restartgame();


        }
          
    }

}
