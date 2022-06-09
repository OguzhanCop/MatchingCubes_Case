using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collector : MonoBehaviour
{
    public GameObject characterRig;
    public GameObject trailRenderer;
    public GameObject maleParent;
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
    float height;
    int sortByIndexNumber=0;   
    GameObject stackCubeSortBy;
    int randomValue;



    private void Start()
    {      
        DOTween.Init();            
    }
   void Update()
    {
        CubeListMissingRemoveCheck();

        if (cube.Count > 0)
        {
            trailfollow();
        }
        if(cube.Count==0)
            characterRig.GetComponent<CharJump>().match(0);
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "orange" || other.gameObject.tag == "blue" || other.gameObject.tag == "yellow")
        {            
            CreateCube(other.gameObject.tag);            
            Destroy(other.gameObject);
            CharPos((float)cube.Count / 2);
        }
        if(other.gameObject.tag== "obstacle1x" || other.gameObject.tag == "obstacle2x" || other.gameObject.tag == "obstacle3x")
        {
            Obstacles(other.gameObject.tag);

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
            
            cube[cube.Count - 1].transform.DOPunchScale(new Vector3(1, 0, 1), 0.5f, 2, 1);
            Invoke("destroylava", 0.5f);
        }
        if (other.gameObject.tag == "speedboost")
        {
            maleParent.GetComponent<Movement>().speedBoost();
        }
        if (other.gameObject.tag == "jump")
        {
            maleParent.GetComponent<Movement>().jump();
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
        CubeArrangement();
       
    }

    void Obstacles(string obstacleHeight)
    {
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
        //Invoke("CubeArrangement", 0.5f);
        //CharPos((float)cube.Count / 2);

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
        //for (int i = 0; i < cube.Count; i++)
        //{
        //    cube[i].GetComponent<CubeJump>().match(i, cube.Count - 1);
        //    k = 0;
        //}
        CubeArrangement();
        sortByIndexNumber = 0;
    }


    void SortByColors()
    {

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
        CubeArrangement();

    }













    public void SameColorCheck(int index)
    {
       
        Destroy(cube[cube.Count-index]);
        Destroy(cube[(cube.Count-1)-index]);
        Destroy(cube[(cube.Count-2)-index]);             
        
    }
    public void trailfollow()
    {
        if (GameObject.FindGameObjectWithTag("trail") == null)
        {
            trailRendererClone = Instantiate(trailRenderer);

        }
        if (cube[cube.Count - 1].transform.tag == "blueclone")
        {
            trailRendererClone.GetComponent<TrailRendererColor>().color(blue);
        }
        if (cube[cube.Count - 1].transform.tag == "yellowclone")
        {
            trailRendererClone.GetComponent<TrailRendererColor>().color(yellow);
        }
        if (cube[cube.Count - 1].transform.tag == "orangeclone")
        {
            trailRendererClone.GetComponent<TrailRendererColor>().color(orange);
        }
        trailRendererClone.GetComponent<TrailRendererColor>().trail(cube[cube.Count-1].transform);

    }
    public void destroylava()
    {
        cube[cube.Count - 1].GetComponent<CubeJump>().burn(cube[cube.Count - 1].transform.tag);
        Destroy(cube[cube.Count - 1]);
        cube.RemoveAt(cube.Count - 1);
        height -= 0.5f;
        characterRig.GetComponent<CharJump>().match(height);
        for (int o = 0; o < cube.Count; o++)
        {
            cube[o].GetComponent<CubeJump>().match(o, cube.Count - 1);
        }


    }
    public void Height()
    {
        height = 0;
    }
        
    void CharPos(float UpValue)
    {        
        characterRig.GetComponent<CharJump>().CharUpPos(UpValue);
    }
    void CubeArrangement()
    {
        for (int i = 0; i < cube.Count; i++)
        {            
            cube[i].GetComponent<CubeJump>().jumpCube(i, cube.Count - 1);
        }

    }
    void CubeListMissingRemoveCheck()
    {        
        for (int i = 0; i < cube.Count; i++)
        {           
            if (cube[i] == null)
            {
                cube.RemoveAt(i); 
                CubeArrangement();
                CharPos((float)cube.Count / 2);
            }
            
        }
    }




}
