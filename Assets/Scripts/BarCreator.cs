using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BarCreator : MonoBehaviour
{
    SFXManager audioManager;
    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SFXManager>();
        GameManager.AllPoints.Clear();; 
    }            

    public GameObject RoadBar;
    public GameObject WoodBar;

    bool BarCreationStarted = false;
    public Bar currentBar;
    public GameObject BarToInstantiate;
    public Transform barParent;
    public Point CurrentStartPoint;
    public Point CurrentEndPoint;

    public GameObject PointToInstantiate;
    public GameObject cursor;
    public GameObject Buttons;
    public GameObject notButtons;

    public Transform PointParent;

    public UIManager myUI;
  
    public GameObject FindClosestLine()
    {
        GameObject[] gos;
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = cursor.transform.position;
      

        GameObject[] gos1;
        gos1 = GameObject.FindGameObjectsWithTag("Bar");
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

    
    void StartBarCreation(Vector2 StartPosition){

        currentBar = Instantiate(BarToInstantiate, barParent).GetComponent<Bar>();
        currentBar.StartPosition = StartPosition; 
       
        if(GameManager.AllPoints.ContainsKey(StartPosition)){
            CurrentStartPoint = GameManager.AllPoints[StartPosition];

        }
        else{
            CurrentStartPoint = Instantiate(PointToInstantiate,StartPosition,Quaternion.identity, PointParent).GetComponent<Point>();
            GameManager.AllPoints.Add(StartPosition, CurrentStartPoint);
        
            //currentBar.GetComponent<SpriteRenderer>().color = new Color(currentBar.GetComponent<SpriteRenderer>().color.r, currentBar.GetComponent<SpriteRenderer>().color.g, currentBar.GetComponent<SpriteRenderer>().color.b, 1f);         

        }

        CurrentEndPoint = Instantiate(PointToInstantiate,StartPosition,Quaternion.identity, PointParent).GetComponent<Point>();
        CurrentStartPoint.GetComponent<SpriteRenderer>().color = new Color(CurrentEndPoint.GetComponent<SpriteRenderer>().color.r, CurrentEndPoint.GetComponent<SpriteRenderer>().color.g, CurrentEndPoint.GetComponent<SpriteRenderer>().color.b, 1f);         
        //CurrentEndPoint.GetComponent<SpriteRenderer>().color = new Color(CurrentEndPoint.GetComponent<SpriteRenderer>().color.r, CurrentEndPoint.GetComponent<SpriteRenderer>().color.g, CurrentEndPoint.GetComponent<SpriteRenderer>().color.b, 1f);         

            cursor.SetActive(false);

    }
    void FinishBarCreation(){
        CurrentStartPoint.tag = "Point";

        if(GameManager.AllPoints.ContainsKey(CurrentEndPoint.transform.position)){
            Destroy(CurrentEndPoint.gameObject);
            CurrentEndPoint = GameManager.AllPoints[CurrentEndPoint.transform.position];
        }
        else{
            GameManager.AllPoints.Add(CurrentEndPoint.transform.position,CurrentEndPoint);
        }
        CurrentStartPoint.ConnectedBars.Add(currentBar);
        CurrentEndPoint.ConnectedBars.Add(currentBar);

        currentBar.StartJoint.connectedBody = CurrentStartPoint.rbd;
        currentBar.StartJoint.anchor = currentBar.transform.InverseTransformPoint(currentBar.StartPosition);
        currentBar.EndJoint.connectedBody = CurrentEndPoint.rbd;
        currentBar.EndJoint.anchor = currentBar.transform.InverseTransformPoint(CurrentEndPoint.transform.position);
        currentBar.GetComponent<SpriteRenderer>().color = new Color(currentBar.GetComponent<SpriteRenderer>().color.r, currentBar.GetComponent<SpriteRenderer>().color.g, currentBar.GetComponent<SpriteRenderer>().color.b, 1f);         
        StartBarCreation(CurrentEndPoint.transform.position);
        cursor.SetActive(false);
        CurrentStartPoint.GetComponent<SpriteRenderer>().color = new Color(CurrentEndPoint.GetComponent<SpriteRenderer>().color.r, CurrentEndPoint.GetComponent<SpriteRenderer>().color.g, CurrentEndPoint.GetComponent<SpriteRenderer>().color.b, 1f);         
        //CurrentEndPoint.GetComponent<SpriteRenderer>().color = new Color(CurrentEndPoint.GetComponent<SpriteRenderer>().color.r, CurrentEndPoint.GetComponent<SpriteRenderer>().color.g, CurrentEndPoint.GetComponent<SpriteRenderer>().color.b, 1f);         
        CurrentStartPoint.tag = "Point";

        myUI.UpdateBudget();

    }
    void DeleteCurrentBar(){

        Destroy(currentBar.gameObject);
        if (CurrentStartPoint.ConnectedBars.Count == 0 && CurrentStartPoint.Runtime == true){
            Destroy(CurrentStartPoint.gameObject);
        }
        if (CurrentEndPoint.ConnectedBars.Count == 0 && CurrentEndPoint.Runtime == true){
            Destroy(CurrentEndPoint.gameObject);
        }
        myUI.UpdateBudget();

    }

       private void Update(){
        if (FindClosestLine() == null){
            GameManager.AllPoints.Clear();; 
        }
        float x = Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).x*2)/2;
        float y = Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).y*2)/2;
        if(BarCreationStarted == false){
            
            if (Input.GetMouseButtonDown(0)){
                
                cursor.GetComponent<SpriteRenderer>().enabled = false;
                cursor.SetActive(false);
                BarCreationStarted = true;

          
                //StartBarCreation(Vector2Int.RoundToInt(Camera.main.ScreenToWorldPoint(eventData.position)));
                StartBarCreation(new Vector2(x,y));
                Debug.Log("START!");
                Buttons.SetActive(false);
                notButtons.SetActive(true);

                myUI.UpdateBudget();

            }
             //Debug.Log("1!!");


            if (Input.GetMouseButton(1)||Input.GetKey("space"))
            {
               // GameManager.AllPoints.Remove(cursor.transform.position); 

                myUI.UpdateBudget();

                //Debug.Log("Hello!!");
                if(BarCreationStarted == false){

                    GameObject[] gos1;
                    gos1 = GameObject.FindGameObjectsWithTag("Point");
                    foreach (GameObject go in gos1)
                    {
                        bool dies = true;
                        Debug.Log(go.GetComponent<Point>().ConnectedBars.Count);
                        foreach (Bar b in go.GetComponent<Point>().ConnectedBars){
                            if (b!=null){
                                dies = false;
                            }
                        }
                        if(dies){
                            Destroy(go);
                            GameManager.AllPoints.Remove(go.transform.position); 

                        }
                       
                    
                        
                    }
                    if(FindClosestLine() != null){
                        

                        if(Mathf.Abs(FindClosestLine().transform.position.x - x) < 0.4 && Mathf.Abs(FindClosestLine().transform.position.y - y) < 0.4)
                            {
                                if (FindClosestLine().tag == "Point"){
                                    GameManager.AllPoints.Remove(FindClosestLine().transform.position); 
                                    GameManager.AllPoints.Remove(new Vector3(x,y,0)); 
                                }


                                //GameManager.AllPoints.Remove(FindClosestLine().transform.position);   
                                audioManager.PlaySFX(audioManager.Erase);

                                Destroy(FindClosestLine());
                                myUI.UpdateBudget();

                                Debug.Log("BIG");   
                                Debug.Log(FindClosestLine().transform.position);   
                                Debug.Log(Input.mousePosition);   
                                Debug.Log(x);   
                                Debug.Log(y);   


                            }
                    }
                }
            }
            
        }
        else if (BarCreationStarted){

            if(Input.GetMouseButtonDown(0)){
                currentBar.tag = "Bar";
                FinishBarCreation();
                Buttons.SetActive(false);
                notButtons.SetActive(true);

                Debug.Log("FINISH!");
                myUI.UpdateBudget();


            }
            else if (Input.GetMouseButtonUp(1) ||Input.GetKeyUp("space")){
                BarCreationStarted = false;
                Buttons.SetActive(true);
                notButtons.SetActive(false);

                DeleteCurrentBar();

                Debug.Log("DELETE!");
                myUI.UpdateBudget();
                cursor.GetComponent<SpriteRenderer>().enabled = true;
                cursor.SetActive(true);







            }
            
        
       
        //currentBar.StartPosition = StartPosition; 
        /*

        if (CurrentStartPoint == null && CurrentEndPoint != null && currentBar ==null){
             Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentBar = Instantiate(BarToInstantiate, barParent).GetComponent<Bar>();

            float x = Mathf.Round(mousePos.x*2)/2;
            float y = Mathf.Round(mousePos.y*2)/2;
            StartBarCreation(new Vector2(x,y));

            
        }
        */
        /*
        if (CurrentStartPoint != null && CurrentEndPoint == null && currentBar ==null){
             Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentBar = Instantiate(BarToInstantiate, barParent).GetComponent<Bar>();

        
            FinishBarCreation();

            
        }
        */
        if (BarCreationStarted){


            //CurrentEndPoint.transform.position = (Vector2)((Vector2Int.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition))));
            Vector2 EndPosition = new Vector2(x,y);
            Vector2 Dir = EndPosition - currentBar.StartPosition;
            Vector2 ClampedPosition = currentBar.StartPosition + Vector2.ClampMagnitude(Dir, currentBar.maxLength);
             float x1= Mathf.Round(ClampedPosition.x*2)/2;
             float y1= Mathf.Round(ClampedPosition.y*2)/2;
           CurrentEndPoint.transform.position = new Vector2(x1,y1);

           CurrentEndPoint.PointID = CurrentEndPoint.transform.position;
           
           currentBar.UpdateCreatingBar(CurrentEndPoint.transform.position);
            myUI.UpdateBudget();

        }
    }
}
}
