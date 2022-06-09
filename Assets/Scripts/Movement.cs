using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{
    public float speed=5;
   
    
    void Start()
    {
        DOTween.Init();
        
        
    }
    void Update()
    {
        transform.Translate(0, 0, speed*Time.deltaTime);

        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);
            turn(finger.deltaPosition.x);
            clampX(transform.position);
            
        }        
        
    }
    void turn(float fingerdiff)
    {
        if (fingerdiff != 0)
        {
            transform.Translate(Mathf.Lerp(0, fingerdiff / 2, 1f * Time.deltaTime), 0, 0);
        }

    }
    void clampX(Vector3 pos)
    {
        pos.x = Mathf.Clamp(transform.position.x, -2, 2);
        transform.position = pos;
    }
    public void RampClimp()
    {

        transform.DOLocalMoveY(transform.position.y + 1.5f, 1.2f, false);
        Invoke("RampLanding", 1.2f);
    }
    public void RampLanding()
    {
        transform.DOLocalMoveY(transform.position.y - 1.5f, 1.2f, false);

    }
    public void speedBoost()
    {
        speed = 20;
        Invoke("speedDown", 1.5f);
    }
    public void speedDown()
    {
        speed = 5;
    }
    public void jump()
    {
        speed = 15f;
        transform.DOLocalMoveY(transform.position.y + 10f, 1.5f, false);
        Invoke("Down", 1.5f);
    }
    public void Down()
    {
        transform.DOLocalMoveY(transform.position.y - 10f, 1.5f, false);
        Invoke("DownSpeed", 1.5f);
    }
    public void DownSpeed()
    {
        speed = 5;
    }

}
