// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Eraser : MonoBehaviour
// {
//     public UIManager myUI;

//      public GameObject FindClosestLine()
//     {
//         GameObject[] gos;
//         gos = GameObject.FindGameObjectsWithTag("Point");
//         GameObject closest = null;
//         float distance = Mathf.Infinity;
//         Vector3 position = transform.position;
//         foreach (GameObject go in gos)
//         {
//             Vector3 diff = go.transform.position - position;
//             float curDistance = diff.sqrMagnitude;
//             if (curDistance < distance)
//             {
//                 closest = go;
//                 distance = curDistance;
//             }
//         }

//         GameObject[] gos1;
//         gos1 = GameObject.FindGameObjectsWithTag("Bar");
//         foreach (GameObject go in gos1)
//         {
//             Vector3 diff = go.transform.position - position;
//             float curDistance = diff.sqrMagnitude;
//             if (curDistance < distance)
//             {
//                 closest = go;
//                 distance = curDistance;
//             }
//         }

//         return closest; // gameobject
//     }
//     // Start is called before the first frame update
//     void Start()
//     {
//         gameObject.SetActive(false);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

//         float x = (mousePos.x*2)/2;
//         float y = (mousePos.y*2)/2;
//         transform.position =new Vector3(x,y,10);
//         if(Input.GetMouseButtonDown(0)){
//             if(!(transform.position.y>=3.5||transform.position.x>8|| transform.position.x<-8)){
//                 Destroy(FindClosestLine());
//                 //Destroy(FindClosestLine());
//                 //Destroy(FindClosestLine());
//                 myUI.UpdateBudget();

//             }
//         }
//         Debug.Log(gameObject);
//     }
// }
