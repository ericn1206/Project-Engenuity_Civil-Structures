using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Point : MonoBehaviour
{
     public GameObject FindClosestLine()
    {
        GameObject[] gos1;
        gos1 = GameObject.FindGameObjectsWithTag("Bar");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = gameObject.transform.position;
        foreach (GameObject go in gos1)
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

    public bool Runtime = true;
    public Rigidbody2D rbd;
    public Vector2 PointID;
    public List<Bar> ConnectedBars;

    public List<int> te;
    public int BarsConnected = 0; 

    private void Start(){
       

        if (Runtime == false){
            PointID = transform.position;

            rbd.bodyType = RigidbodyType2D.Static;
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;      //MAYBE IDK   

            float x = Mathf.Round(transform.position.x*2)/2;
            float y = Mathf.Round(transform.position.y*2)/2;
            
            Vector2 pos = new Vector2(x,y);
            //PointID = pos;
            if(GameManager.AllPoints.ContainsKey(PointID)== false) GameManager.AllPoints.Add(PointID,this);
        }
    }
    private bool live=false;
   
    
    
    private void Update(){
        if (Runtime == false){
            if (transform.hasChanged == true){
                transform.hasChanged = false;
                float x = Mathf.Round(transform.position.x*2)/2;
                float y = Mathf.Round(transform.position.y*2)/2;
                transform.position = new Vector3(x,y,transform.position.z);

                //transform.position = Vector3Int.RoundToInt(transform.position);
            }
        }
        
            

     
    }
}
