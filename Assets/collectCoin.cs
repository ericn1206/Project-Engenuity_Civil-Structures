using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectCoin : MonoBehaviour
{
    SFXManager audioManager;
    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SFXManager>();
    }
    private bool die = false;
    public GameObject winMessage; 
    private int count = 1;
    public GameObject FindClosestLine()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Coin");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = gameObject.transform.position;
        count = 0;

        foreach (GameObject go in gos)
        {
            count++;
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
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
               
        //Debug.Log(gameObject.transform.position.y);

        if(GameObject.FindGameObjectsWithTag("Coin").Length == 0){
            winMessage.SetActive(true);

        }
        if(gameObject.transform.position.y<-6.5f &&gameObject.transform.position.y>-6.8f && gameObject.transform.position.x<11){
            die = true;
            Debug.Log("DIEE");
        }
        if(die){
            audioManager.PlaySFX(audioManager.Death);
            die = false;

        }
        if(gameObject.transform.position.y<-20){
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);

        }
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if ((other.gameObject.tag == "Coin")) {
            audioManager.PlaySFX(audioManager.Coin);
            Destroy(FindClosestLine());
        }
    }    
}
