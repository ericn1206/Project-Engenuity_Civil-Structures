using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableSpawn : MonoBehaviour
{
    
    public GameObject spawn;
    public GameObject FindClosestLine()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Anchor");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest; // gameobject
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y>=3.5||transform.position.x>10|| transform.position.x<-10){
            spawn.GetComponent<BarCreator>().enabled = false; 

        }
        else{
            spawn.GetComponent<BarCreator>().enabled = true; 
        }
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float x = Mathf.Round(mousePos.x*2)/2;
        float y = Mathf.Round(mousePos.y*2)/2;
        transform.position =new Vector3(x,y,10);

      //  Debug.Log(FindClosestLine().transform.position.x);
        //Debug.Log(FindClosestLine().transform.position.y);
        //if(Input.GetMouseButtonDown(0))
        
            // if (FindClosestLine().transform.position.x - transform.position.x <0.1 && FindClosestLine().transform.position.y - transform.position.y <0.1){
            //     spawn.GetComponent<BarCreator>().enabled = true; 
            //     Debug.Log("YESSS");

            // }
            // else{
            //     spawn.GetComponent<BarCreator>().enabled = false; 
            //     Debug.Log("NOO");


            // }
        

    }
    
}
