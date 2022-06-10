using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collector : MonoBehaviour
{
    public GameObject characterRig;
    public GameObject trailRenderer;
    public GameObject maleParent;
    public GameObject buttons;
    GameObject trailRendererClone;
    public List<GameObject> cube = new List<GameObject>();   
    public GameObject redCube;
    public GameObject blueCube;
    public GameObject orangeCube;
    public GameObject yellowCube;
    GameObject cubeClone;    
    public Material orange;
    public Material blue;
    public Material yellow;    
    int sortByIndexNumber=0;   
    GameObject stackCubeSortBy;
    int randomValue;
    bool FeverModeActive = false;



    private void Start()
    {      
        DOTween.Init();            
    }
   void Update()
    {
        CubeListMissingRemoveCheck();
        TrailInstantiateFollow();
        CubeZeroCheck();
                 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "orange" || other.gameObject.tag == "blue" || other.gameObject.tag == "yellow")
        {            
            CreateCube(other.gameObject.tag);            
            Destroy(other.gameObject);
            CharPosAdd((float)cube.Count / 2);
        }
        if (other.gameObject.tag == "obstacle1x" || other.gameObject.tag == "obstacle2x" || other.gameObject.tag == "obstacle3x")
        {
            if (FeverModeActive == false)
            {
                Obstacles(other.gameObject.tag);
            }

        }          
       

        if (other.gameObject.tag == "ramp")
        {
            maleParent.GetComponent<Movement>().RampClimp();

        }
        if (other.gameObject.tag == "ordergate")
        {
            SortByColorsLookIndex();
        }
        if (other.gameObject.tag == "randomgate")
        {
            RandomOrder();
        }                
       
        
        if (other.gameObject.tag == "lava")
        {
            if (cube.Count == 0)
            {
                buttons.GetComponent<PlayButton>().PlayerDead();
            }
            if (FeverModeActive == false)
            {
                cube[cube.Count - 1].transform.DOPunchScale(new Vector3(1, 0, 1), 0.5f, 2, 1);
                Invoke("LavaFireCube", 0.5f);
            }
           
        }
        if (other.gameObject.tag == "speedboost")
        {
            maleParent.GetComponent<Movement>().SpeedBoost();
        }
        if (other.gameObject.tag == "jump")
        {
            maleParent.GetComponent<Movement>().JumpBoost();
        }
        if (other.gameObject.tag == "finish")
        {
            buttons.GetComponent<PlayButton>().Finish();
        }
    }
    void CreateCube(string colorTagName)
    {
        if (colorTagName == "orange")
        {
            CreateCubeColor(orangeCube );
        }
        if (colorTagName == "blue")
        {
            CreateCubeColor(blueCube);
        }
        if (colorTagName == "yellow")
        {
            CreateCubeColor(yellowCube);
        }
    }
    void CreateCubeColor(GameObject colorCube)
    {
        cubeClone = Instantiate(colorCube, transform.position, transform.rotation);
        cubeClone.gameObject.transform.parent = transform;
        cubeClone.transform.DOPunchScale(new Vector3(1, 0, 1), 0.5f, 2, 1);
        cube.Add(cubeClone);
        CubeArrangementAdd();
       
    }

    void Obstacles(string obstacleHeight)
    {
        if (cube.Count == 0)
        {            
            buttons.GetComponent<PlayButton>().PlayerDead();
        }
        if(obstacleHeight== "obstacle1x")
        {
            CubesHitObstacles(1);
        }
        if (obstacleHeight == "obstacle2x")
        {
            CubesHitObstacles(2);
        }
        if (obstacleHeight == "obstacle3x")
        {
            CubesHitObstacles(3);
        }

    }
    void CubesHitObstacles(int obstacleSize)
    {
        for (int i = 0; i < obstacleSize ; i++)
        {            
            cube[cube.Count - 1].transform.SetParent(null);
            cube.RemoveAt(cube.Count - 1);          

        }
        Invoke("CubeArrangementMinus", 0.5f);
        

    }
    void SortByColorsLookIndex()
    {       
        for (int p = 0; p < cube.Count; p++)
        {
            if (cube[p].gameObject.tag == "orangeclone")
            {
                stackCubeSortBy = cube[sortByIndexNumber].gameObject;
                cube[sortByIndexNumber] = cube[p];
                cube[p] = stackCubeSortBy;
                sortByIndexNumber++;
            }
        }
        for (int p = 0; p < cube.Count; p++)
        {
            if (cube[p].gameObject.tag == "blueclone")
            {
                stackCubeSortBy = cube[sortByIndexNumber].gameObject;
                cube[sortByIndexNumber] = cube[p];
                cube[p] = stackCubeSortBy;
                sortByIndexNumber++;
            }
        }
        for (int p = 0; p < cube.Count; p++)
        {
            if (cube[p].gameObject.tag == "yellowclone")
            {
                stackCubeSortBy = cube[sortByIndexNumber].gameObject;
                cube[sortByIndexNumber] = cube[p];
                cube[p] = stackCubeSortBy;
                sortByIndexNumber++;
            }
        }
        Invoke("CubeArrangementMinus", 0.5f);
        sortByIndexNumber = 0;
    }


    
    void RandomOrder()
    {
        for (int t = 0; t < cube.Count; t++)
        {
            randomValue = Random.Range(0, cube.Count - 1);
            stackCubeSortBy = cube[t];
            cube[t] = cube[randomValue];
            cube[randomValue] = stackCubeSortBy;
        }
        Invoke("CubeArrangementMinus", 0.5f);

    }
    public void SameColorCheck(int index)
    {
       
        Destroy(cube[cube.Count-index]);
        Destroy(cube[(cube.Count-1)-index]);
        Destroy(cube[(cube.Count-2)-index]);
        Invoke("CubeArrangementMinus", 0.5f);
    }
    public void LavaFireCube()
    {       
        cube[cube.Count - 1].GetComponent<CubeJump>().BurnCube(cube[cube.Count - 1].transform.tag);
        Destroy(cube[cube.Count - 1]);
        cube.RemoveAt(cube.Count - 1);
        
        CubeArrangementMinus();

    }
    public void TrailInstantiateFollow()
    {
        if (cube.Count > 0)
        {
            if (GameObject.FindGameObjectWithTag("trail") == null)
            {
                trailRendererClone = Instantiate(trailRenderer);

            }
            if (cube[cube.Count - 1].transform.tag == "blueclone")
            {
                trailRendererClone.GetComponent<TrailRendererColor>().Color(blue);
            }
            if (cube[cube.Count - 1].transform.tag == "yellowclone")
            {
                trailRendererClone.GetComponent<TrailRendererColor>().Color(yellow);
            }
            if (cube[cube.Count - 1].transform.tag == "orangeclone")
            {
                trailRendererClone.GetComponent<TrailRendererColor>().Color(orange);
            }
            trailRendererClone.GetComponent<TrailRendererColor>().TrailFollow(cube[cube.Count - 1].transform);
        }
    }
    void CubeZeroCheck()
    {
        if (cube.Count == 0)
        {
            characterRig.GetComponent<CharJump>().CharDownPos(0);
            maleParent.GetComponent<Animator>().enabled = true;
        }
        else
        {
            maleParent.GetComponent<Animator>().enabled = false;          
            
            maleParent.GetComponent<Movement>().SurferPosChar();
        }
    }

    void CharPosAdd(float UpValue)
    {        
        characterRig.GetComponent<CharJump>().CharUpPos(UpValue);
    }
    void CharPosMinus(float MinusValue)
    {
        characterRig.GetComponent<CharJump>().CharDownPos(MinusValue);
    }
    void CubeArrangementAdd()
    {
        for (int i = 0; i < cube.Count; i++)
        {            
            cube[i].GetComponent<CubeJump>().CubeUpPos(i, cube.Count - 1);
        }
        CharPosAdd((float)cube.Count / 2);
    }
    void CubeArrangementMinus()
    {
        for (int i = 0; i < cube.Count; i++)
        {
            cube[i].GetComponent<CubeJump>().CubeDownPos(i, cube.Count - 1);
        }
        CharPosMinus((float)cube.Count / 2);
        

    }
    void CubeListMissingRemoveCheck()
    {        
        for (int i = 0; i < cube.Count; i++)
        {           
            if (cube[i] == null)
            {
                cube.RemoveAt(i); 
                CubeArrangementMinus();
                CharPosMinus((float)cube.Count / 2);
            }
            
        }
    }
    public void FeverModeStartControl()
    {
        FeverModeActive = true;
    }
    public void FeverModeStopControl()
    {
        FeverModeActive = false;
    }



}
