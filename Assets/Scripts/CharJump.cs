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
        Debug.Log(height);
        height = PlayerPrefs.GetFloat("height");
        PlayerDead();

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
