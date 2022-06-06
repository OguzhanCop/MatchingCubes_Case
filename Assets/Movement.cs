using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
   
    
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
    public void rampUp()
    {

        transform.DOLocalMoveY(transform.position.y + 1.5f, 1.2f, false);
        Invoke("rampDown", 1.2f);
    }
    public void rampDown()
    {
        transform.DOLocalMoveY(transform.position.y - 1.5f, 1.2f, false);

    }
}
