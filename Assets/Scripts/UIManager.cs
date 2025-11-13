using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public float LevelBudget = 1000;
    public Button RoadButton;
    public Button WoodButton;
    public BarCreator barCreator;
    public GameObject cursor;
    public GameObject spawn;
    public GameObject Destroyer;

    //public GameObject anchors;

    public GameObject createBar;
    //public GameObject eraser;
    public GameObject MockCursor;

    public GameObject budtext;
    public TMP_Text budget; 
    public GameObject budtext1;
    public TMP_Text budget1; 
    public Button start;
    private Vector3 startpos;


    private void Start(){
        startpos = Destroyer.transform.position;

        RoadButton.onClick.Invoke();
        budget = budtext.GetComponent<TMP_Text>();
        budget1 = budtext1.GetComponent<TMP_Text>();

    }
    public void Play(){
        Time.timeScale = 1;
        cursor.SetActive(false);
        createBar.GetComponent<BarCreator>().enabled = false;
        //anchors.SetActive(false);
    

    }
    public void EndGuide(){
        createBar.GetComponent<BarCreator>().enabled = true;
        //anchors.SetActive(false);
        MockCursor.GetComponent<disableSpawn>().enabled = true;

    }
     public void EndGuide1(){
        Time.timeScale = 0;

    }
    
    public void Home(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Start");
    }
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void DestroyAll()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Point");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = cursor.transform.position;
        foreach (GameObject go in gos)
        {
            Destroy(go);
        }

        GameObject[] gos1;
        gos1 = GameObject.FindGameObjectsWithTag("Bar");
        foreach (GameObject go in gos1)
        {
            Destroy(go);
        }

    }
    public void AfterGuide(){
        DestroyAll();
        Destroyer.transform.position = startpos;
        Destroyer.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        Time.timeScale = 0;
        createBar.GetComponent<BarCreator>().enabled = true;
        MockCursor.SetActive(true);

        MockCursor.GetComponent<disableSpawn>().enabled = true;


       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        

    }
   
    /*
    bool on = true;
     public void Erase(){
        if (on){
            eraser.SetActive(true);
            createBar.GetComponent<BarCreator>().enabled = false;
            MockCursor.SetActive(false);


        }
        else{
            eraser.SetActive(false);
            createBar.GetComponent<BarCreator>().enabled = true;
            MockCursor.SetActive(true);


        }
        on = !on;
    }
    */

    public void ChangeBar(int myBarType){
        if(myBarType == 0){
            WoodButton.GetComponent<Outline>().enabled = false;
            RoadButton.GetComponent<Outline>().enabled = true;
            barCreator.BarToInstantiate = barCreator.RoadBar;

        }
        if(myBarType == 1){
            WoodButton.GetComponent<Outline>().enabled = true;
            RoadButton.GetComponent<Outline>().enabled = false;
            barCreator.BarToInstantiate = barCreator.WoodBar;
            
        }
    }
    
    public int count = 0;
    public int Budgeting()
    {
        count = 0;
        GameObject[] gos1;
        gos1 = GameObject.FindGameObjectsWithTag("Bar");
        foreach (GameObject go in gos1)
        {
           count+= 40;
        }

        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Point");
        foreach (GameObject go in gos)
        {
           count+= 5;
        }
        return count; // gameobject
    }
    public void UpdateBudget(){
        Budgeting();
        budget.text = "$"+count.ToString()+ " / $" +LevelBudget.ToString();

    }
    public void Update(){
        if (Budgeting() > LevelBudget){
            budget.color = new Color(0.8f,0.3f,0.3f,0.9f);
            budget1.color = new Color(0.8f,0.3f,0.3f,0.9f);

            start.interactable = false;
        }
        else{
            budget.color = new Color(0,0,0,0.86f);
            budget1.color = new Color(0,0,0,0.86f);

            start.interactable = true;


        }

        if(Input.GetMouseButton(0)|| Input.GetMouseButton(1)){
           UpdateBudget();
        }
    }
    
    
}
