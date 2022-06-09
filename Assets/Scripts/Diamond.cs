using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Diamond : MonoBehaviour
{
    public GameObject diamond;  
    GameObject diamond1;  
   public GameObject targetDiamond;
    public TextMeshProUGUI scoretext;
    int score;

    
    void Start()
    {
        DOTween.Init();
        
        


    }

    
    void Update()
    {
        scoretext.text = "" + score;


    }


    public void InstantiateDiamond(Transform cube)
    {
                
        diamond1 = Instantiate(diamond, cube.transform.position, Quaternion.Euler(-90, 0, 0));
       
        diamond1.transform.DOMove(targetDiamond.transform.position, 1f, false);
        diamond1.transform.DOScale(2F, 1F);       
        
        Destroy(diamond1, 1F);
        score++;

    }
 


}
