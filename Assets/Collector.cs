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
            cube[cube.Count - 1].transform.SetParent(null);
            cube.RemoveAt(cube.Count - 1);
            height -= 0.5f;
            characterRig.GetComponent<CharJump>().match(height);
            for (int i = 0; i < cube.Count; i++)
            {
                cube[i].GetComponent<CubeJump>().match(i, cube.Count - 1);
            }
        }
        if (other.gameObject.tag == "obstacle2x")
        {
            cube[cube.Count - 1].transform.SetParent(null);
            cube.RemoveAt(cube.Count - 1);
            cube[cube.Count - 1].transform.SetParent(null);
            cube.RemoveAt(cube.Count - 1);
            height -= 1f;
            characterRig.GetComponent<CharJump>().match(height);
            for (int i = 0; i < cube.Count; i++)
            {
                cube[i].GetComponent<CubeJump>().match(i, cube.Count - 1);
            }

        }
        if (other.gameObject.tag == "obstacle3x")
        {
            cube[cube.Count - 1].transform.SetParent(null);
            cube.RemoveAt(cube.Count - 1);
            cube[cube.Count - 1].transform.SetParent(null);
            cube.RemoveAt(cube.Count - 1);
            cube[cube.Count - 1].transform.SetParent(null);
            cube.RemoveAt(cube.Count - 1);
            height -= 1.5f;
            characterRig.GetComponent<CharJump>().match(height);
            for (int i = 0; i < cube.Count; i++)
            {
                cube[i].GetComponent<CubeJump>().match(i, cube.Count - 1);
            }

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
        Debug.Log(index);
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

    

}
