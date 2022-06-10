using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Diamond : MonoBehaviour
{
    public GameObject malePerent;
    public GameObject diamond;  
    GameObject diamondStack;  
    public GameObject targetDiamond;
    public TextMeshProUGUI scoreText;
    int score;
    int feverModeScore=3;
    
    void Start()
    {
        DOTween.Init();       
        
    }    
    void Update()
    {
        ScoreText();
        FeverMode(score,feverModeScore);
    }
    public void InstantiateDiamond(Transform cube)
    {                
        diamondStack = Instantiate(diamond, cube.transform.position, Quaternion.Euler(-90, 0, 0));       
        diamondStack.transform.DOMove(targetDiamond.transform.position, 1f, false);
        diamondStack.transform.DOScale(2F, 1F);               
        Destroy(diamondStack, 1F);
        score++;
    }
    void ScoreText()
    {
        scoreText.text = "" + score;
    }
    void FeverMode(int diaScore,int feverScore)
    {
        if (diaScore>= feverScore)
        {
            malePerent.GetComponent<Movement>().FeverModeStart();
            feverModeScore += 3;
        }

    }
}
