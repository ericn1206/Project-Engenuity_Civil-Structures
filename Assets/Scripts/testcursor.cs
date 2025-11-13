using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcursor : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
     if ((other.gameObject.tag == "Anchor")) Debug.Log("HELP ME");

        
    }
    void OnTriggerStay2D(Collider2D other){
     if ((other.gameObject.tag == "Anchor")) Debug.Log("HELP ME");

        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
