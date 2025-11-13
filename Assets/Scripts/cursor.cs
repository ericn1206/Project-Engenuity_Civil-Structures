using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour
{
    



    void OnTriggerEnter2D(Collider2D other){
        if ((other.gameObject.tag == "Anchor")) {
            Debug.Log("HELP ME");
            gameObject.GetComponent<SpriteRenderer>().color = new Color (0, 1, 0, 1); 

        }
    }
     void OnTriggerStay2D(Collider2D other){
        if ((other.gameObject.tag == "Anchor")) {
            gameObject.GetComponent<SpriteRenderer>().color = new Color (0, 1, 0, 1); 

        }
    }
     void OnTriggerExit2D(Collider2D other){
        if ((other.gameObject.tag == "Anchor")) {  
            gameObject.GetComponent<SpriteRenderer>().color = new Color (1, 0, 0, 1); 
            if (!Input.GetMouseButton(0)){
            }
        }
    }
    public Color color1;
   
    // Start is called before the first frame update
    void Start()
    {
        color1 = gameObject.GetComponent<SpriteRenderer>().color;

    }
    public GameObject spawn;

    // Update is called once per frame
    void Update()
    {
       
        
        if(transform.position.y>=3.5||transform.position.x>10|| transform.position.x<-10){
            gameObject.GetComponent<SpriteRenderer>().enabled = false; 
            //spawn.GetComponent<BarCreator>().enabled = false; 

        }
        else{
            gameObject.GetComponent<SpriteRenderer>().enabled = true; 
            //spawn.GetComponent<BarCreator>().enabled = true; 
        }
        
       // Debug.Log(here);
        if (Input.GetMouseButton(1) || (Input.GetKey("space"))){
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0,0, 0.6f);         

            //gameObject.GetComponent<SpriteRenderer>().color = new Color (0, 0, 0); 
        }
        else{
            gameObject.GetComponent<SpriteRenderer>().color = color1;
        }

      
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float x = Mathf.Round(mousePos.x*2)/2;
        float y = Mathf.Round(mousePos.y*2)/2;
        transform.position =new Vector3(x,y,10);

    }
}
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour
{

    bool here = false;
    public bool Runtime = true;
    public Rigidbody2D rbd;
    public Vector2 PointID;
    //public List<Bar> ConnectedBars;
    void OnTriggerEnter2D(Collider2D other){
        if ((other.gameObject.tag == "Line")) {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().color = new Color (0, 1, 0, 1); 

            here =  true;
        }
    }
     void OnTriggerStay2D(Collider2D other){
        if ((other.gameObject.tag == "Line")) {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().color = new Color (0, 1, 0, 1); 

            here =  true;
        }
    }
     void OnTriggerExit2D(Collider2D other){
        if ((other.gameObject.tag == "Line")) {  
            gameObject.GetComponent<SpriteRenderer>().color = new Color (1, 0, 0, 1); 
            if (!Input.GetMouseButton(0)){
                here =  false;
            }
        }
    }
   
    // Start is called before the first frame update
    void Start()
    {
        spawn.SetActive(false);


    }
    public GameObject spawn;

    // Update is called once per frame
    void Update()
    {
        if(Runtime == false){
            if(transform.hasChanged == true){
                transform.hasChanged = false;
                transform.position = Vector3Int.RoundToInt(transform.position);
            }
        }
       // Debug.Log(here);
        if (Input.GetMouseButton(0)){

            gameObject.GetComponent<SpriteRenderer>().color = new Color (0, 0, 0, 1); 
        }

        if(here){
           spawn.SetActive(true);
        }
        if (!here){
            gameObject.GetComponent<SpriteRenderer>().color = new Color (1, 0, 0, 1); 
            spawn.SetActive(false);

        }
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mousePos+ new Vector3(-0.02f,0.02f,10);
        //float x = Mathf.Round(mousePos.x*2)/;
       // float y = Mathf.Round(mousePos.y*2)/2;
        //transform.position =new Vector3(x,y,10)+ new Vector3(-0.02f,0.02f,10);

    }
}

*/