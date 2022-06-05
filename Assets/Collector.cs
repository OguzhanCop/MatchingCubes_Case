using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collector : MonoBehaviour
{
    public GameObject characterRig;
    public GameObject trailRenderer;
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
    bool yok = false;

    private void Start()
    {      
        DOTween.Init();       
        
    }
   void Update()
    {
        

        PlayerPrefs.SetFloat("height", height);
        if (cube.Count >= 3)
        {
            for (int k = 0; k < cube.Count - 2; k++)
            {
                if (cube[k].transform.name == cube[k + 1].transform.name && cube[k].transform.name == cube[k + 2].transform.name)
                {

                    StartCoroutine(yoket());

                    if (yok)
                    {
                        Destroy(cube[k + 2]);
                        Destroy(cube[k + 1]);
                        Destroy(cube[k]);
                        cube.RemoveAt(k + 2);
                        cube.RemoveAt(k + 1);
                        cube.RemoveAt(k);
                        height-=1.5f;                        
                        characterRig.GetComponent<CharJump>().match(height);
                        for (int t = k-1; t >=0 ; t--)
                        {
                            cube[t].GetComponent<CubeJump>().match(t, cube.Count-1);
                        }        
                    }                      
                   


                }    
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        yok = false;
        if (other.gameObject.tag == "orange")
        {
            height += 0.5f;
            create(orangeCube,orangeCubeClone);
            characterRig.GetComponent<CharJump>().jump();
            trailRendererClone.GetComponent<TrailRendererColor>().color(orange);
            Destroy(other.gameObject);           
            
        }
        if (other.gameObject.tag == "blue")
        {
            height += 0.5f;
            create(blueCube,blueCubeClone);
            characterRig.GetComponent<CharJump>().jump();
            trailRendererClone.GetComponent<TrailRendererColor>().color(blue);
            Destroy(other.gameObject);

        }
        if (other.gameObject.tag == "yellow")
        {
            height += 0.5f;
            create(yellowCube,yellowCubeClone);
            characterRig.GetComponent<CharJump>().jump();
            trailRendererClone.GetComponent<TrailRendererColor>().color(yellow);
            Destroy(other.gameObject);
        }
    }
    void create(GameObject color,GameObject cubeClone)
    {
        cubeClone = Instantiate(color, transform.position, transform.rotation);
        cubeClone.gameObject.transform.parent = transform;
        if (GameObject.FindGameObjectWithTag("trail") == null)
        {
            trailRendererClone= Instantiate(trailRenderer);
           
        }
        trailRendererClone.GetComponent<TrailRendererColor>().trail(cubeClone);   

        cubeClone.transform.DOPunchScale(new Vector3(1,0,1), 0.5f, 2, 1);
      
        cube.Add(cubeClone);
               
        for (int i = 0; i < cube.Count-1; i++)
        {
            cube[i].GetComponent<CubeJump>().jumpCube(i,cube.Count-1);
        }

    }
  
   IEnumerator yoket()
    {
        yield return new WaitForSeconds(0.8f);
        yok = true;

    }

}
