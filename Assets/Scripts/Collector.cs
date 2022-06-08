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
    GameObject blueCubeClone;
    GameObject orangeCubeClone;
    GameObject yellowCubeClone;
    public Material orange;
    public Material blue;
    public Material yellow;    
    float height;
    int k=0;
    int randomValue;
    GameObject stack;
   
    

    private void Start()
    {      
        DOTween.Init();       
       
    }
   void Update()
    {       
        PlayerPrefs.SetFloat("height", height);
        if (cube.Count > 0)
        {
            trailfollow();
        }
        Debug.Log(Random.Range(0, cube.Count));

        
      
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "orange")
        {
            height += 0.5f;
            create(orangeCube,orangeCubeClone);
            characterRig.GetComponent<CharJump>().jump();
            //trailRendererClone.GetComponent<TrailRendererColor>().color(orange);
            Destroy(other.gameObject);           
            
        }
        if (other.gameObject.tag == "blue")
        {
            height += 0.5f;
            create(blueCube,blueCubeClone);
            characterRig.GetComponent<CharJump>().jump();
            //trailRendererClone.GetComponent<TrailRendererColor>().color(blue);
            Destroy(other.gameObject);

        }
        if (other.gameObject.tag == "yellow")
        {
            height += 0.5f;
            create(yellowCube,yellowCubeClone);
            characterRig.GetComponent<CharJump>().jump();
            //trailRendererClone.GetComponent<TrailRendererColor>().color(yellow);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "ramp")
        {
            maleParent.GetComponent<Movement>().rampUp();
        }
        if(other.gameObject.tag== "obstacle1x")
        {
            height -= 0.5f;
            characterRig.GetComponent<CharJump>().match(height);
            cube[cube.Count - 1].transform.SetParent(null);
            cube.RemoveAt(cube.Count - 1);
           
            for (int i = 0; i < cube.Count; i++)
            {
                cube[i].GetComponent<CubeJump>().match(i, cube.Count - 1);
            }
        }
        if (other.gameObject.tag == "obstacle2x")
        {
            height -= 1f;
            characterRig.GetComponent<CharJump>().match(height);
            cube[cube.Count - 1].transform.SetParent(null);
            cube.RemoveAt(cube.Count - 1);
            cube[cube.Count - 1].transform.SetParent(null);
            cube.RemoveAt(cube.Count - 1);
            
            for (int i = 0; i < cube.Count; i++)
            {
                cube[i].GetComponent<CubeJump>().match(i, cube.Count - 1);
            }

        }
        if (other.gameObject.tag == "obstacle3x")
        {
            height -= 1.5f;
            characterRig.GetComponent<CharJump>().match(height);
            cube[cube.Count - 1].transform.SetParent(null);
            cube.RemoveAt(cube.Count - 1);
            cube[cube.Count - 1].transform.SetParent(null);
            cube.RemoveAt(cube.Count - 1);
            cube[cube.Count - 1].transform.SetParent(null);
            cube.RemoveAt(cube.Count - 1);
            
            for (int i = 0; i < cube.Count; i++)
            {
                cube[i].GetComponent<CubeJump>().match(i, cube.Count - 1);
            }

        }
        if (other.gameObject.tag == "ordergate")
        {
            for (int p = 0; p < cube.Count; p++)
            {
                if (cube[p].gameObject.tag == "orangeclone")
                {
                    stack = cube[k].gameObject;
                    cube[k] = cube[p];
                    cube[p] = stack;                                       
                    k++;
                }
            }
            for (int p = 0; p < cube.Count; p++)
            {
                if (cube[p].gameObject.tag == "blueclone")
                {
                    stack = cube[k].gameObject;
                    cube[k] = cube[p];
                    cube[p] = stack;                    
                    k++;
                }
            }
            for (int p = 0; p < cube.Count; p++)
            {
                if (cube[p].gameObject.tag == "yellowclone")
                {
                    stack = cube[k].gameObject;
                    cube[k] = cube[p];
                    cube[p] = stack;
                    k++;
                }
            }
            for (int i = 0; i < cube.Count; i++)
            {
                cube[i].GetComponent<CubeJump>().match(i, cube.Count - 1);
                k = 0;
            }
        }
        if(other.gameObject.tag == "randomgate")
        {
            for (int t = 0; t < cube.Count; t++)
            {
                randomValue = Random.Range(0, cube.Count - 1);
                stack = cube[t];
                cube[t] = cube[randomValue];
                cube[randomValue] = stack;
            }
            for (int i = 0; i < cube.Count; i++)
            {
                cube[i].GetComponent<CubeJump>().match(i, cube.Count - 1);
            }
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
    void create(GameObject color,GameObject cubeClone)
    {
        cubeClone = Instantiate(color, transform.position, transform.rotation);
        cubeClone.gameObject.transform.parent = transform; 
         
        cubeClone.transform.DOPunchScale(new Vector3(1,0,1), 0.5f, 2, 1);
      
        cube.Add(cubeClone);

               
        for (int i = 0; i < cube.Count-1; i++)
        {
            cube[i].GetComponent<CubeJump>().jumpCube(i,cube.Count-1);
            
        }

    }
    public void match(int index)
    {
       
        Destroy(cube[cube.Count-index]);
        Destroy(cube[(cube.Count-1)-index]);
        Destroy(cube[(cube.Count-2)-index]);
        cube.RemoveAt(cube.Count - index);
        cube.RemoveAt(cube.Count  - index);
        cube.RemoveAt(cube.Count - index);
        height -= 1.5f;
        characterRig.GetComponent<CharJump>().match(height);
        for (int i = 0; i < cube.Count ; i++)
        {
            cube[i].GetComponent<CubeJump>().match(i, cube.Count - 1);
        }

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
        

    

}
