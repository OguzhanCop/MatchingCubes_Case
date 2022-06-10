using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{
    public GameObject collector;
    public GameObject characterRig;
    public float speed=5;
    bool jumpPosCheck=false;
   
    
    void Start()
    {
        DOTween.Init();       

               
    }
    void Update()
    {
        Move();
        
        TouchSlide();
             
        
    }
    void Move()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
   void TouchSlide()
    {
        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);
            Turn(finger.deltaPosition.x);
            ClampX(transform.position);
            
            

        }

    }
    void ClampX(Vector3 pos)
    {
        pos.x = Mathf.Clamp(transform.position.x, -2, 2);
        transform.position = pos;
    }
    void Turn(float fingerdiff)
    {
        if (fingerdiff != 0)
        {
            transform.Translate(Mathf.Lerp(0, fingerdiff / 2, 1f * Time.deltaTime), 0, 0);
        }

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
    public void SpeedBoost()
    {
        speed = 20;
        Invoke("SpeedDown", 1.5f);
    }
    public void SpeedDown()
    {
        speed = 5;
    }
    public void JumpBoost()
    {
        speed = 15f;        
        transform.DOLocalMoveY(transform.position.y + 10f, 1.5f, false);
        JumpPosChar();
        Invoke("JumpDown", 1.5f);
    }
    public void JumpDown()
    {
        transform.DOLocalMoveY(transform.position.y - 10f, 1.5f, false);
        Invoke("DownSpeed", 1.5f);
    }
    public void DownSpeed()
    {
        
        speed = 5;
        jumpPosCheck = false;
    }
    public void FeverModeStart()
    {
        collector.GetComponent<Collector>().FeverModeStartControl();
        speed = 20f;
        Invoke("FeverModeStop", 1.5f);
    }
    void FeverModeStop()
    {
        collector.GetComponent<Collector>().FeverModeStopControl();
        speed = 5;
    }
    public void SurferPosChar()
    {
        if (jumpPosCheck == false)
        {
            characterRig.transform.DORotateQuaternion(Quaternion.Euler(-90, 60, 90), 1F);
        }      

    }
    void JumpPosChar()
    {
        jumpPosCheck = true;
        characterRig.transform.DORotateQuaternion(Quaternion.Euler(0, 0, 90), 1F);
        
    }
}
