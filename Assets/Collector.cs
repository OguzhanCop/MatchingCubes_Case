using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collector : MonoBehaviour
{
    public GameObject characterRig;
    Rigidbody rb;
    public GameObject redCube;
    float height = 0;
    float charPosY;
    
    Animator anim;

    private void Start()
    {
        // rb = characterRig.GetComponent<Rigidbody>();
        anim = characterRig.GetComponent<Animator>();
        DOTween.Init();
        charPosY = characterRig.transform.localPosition.y;
        
    }
    private void Update()
    {
        Debug.Log(characterRig.transform.localPosition.y);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "red")
        {
            height += 0.5f;
            Invoke("create", 1f);
            jump();            
            Destroy(other.gameObject);
            
        }

    }
    void create()
    {
        GameObject redCubeclone = Instantiate(redCube, transform.position, transform.rotation);
        redCubeclone.gameObject.transform.parent = transform;
    }
    void jump()
    {
        characterRig.transform.DOLocalMoveY(charPosY+height*3, 0.3f, false);
        Invoke("fall", 0.3f);    

    }
    void fall()
    {
        characterRig.transform.DOLocalMoveY(charPosY + height, 0.3f, false);
    }
}
