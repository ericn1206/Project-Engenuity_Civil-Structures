using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointStick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if ((other.gameObject.tag == "Anchor")) {
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;        
        }
        if ((other.gameObject.tag == "Cursor")) {
            //gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, gameObject.GetComponent<SpriteRenderer>().color.g, gameObject.GetComponent<SpriteRenderer>().color.b, 1f);         
        }

    }    
}
