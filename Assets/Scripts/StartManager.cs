using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
public class StartManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void PrevLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
    public void LoadTruss(){
        SceneManager.LoadScene("Truss");
       // Time.timeScale = 0;

    }
    public void LoadArch(){
        SceneManager.LoadScene("Arch");
       // Time.timeScale = 0;

    }
    public void LoadLevel1(){
        SceneManager.LoadScene("Level1");
      //  Time.timeScale = 0;

    }
    public void LoadLevel2(){
        SceneManager.LoadScene("Level2");
       // Time.timeScale = 0;
    }public void LoadLevel3(){
        SceneManager.LoadScene("Level3");
       // Time.timeScale = 0;
    }
    public void LoadLevel4(){
        SceneManager.LoadScene("Level4");
       // Time.timeScale = 0;
    }
    public void LoadLevel5(){
        SceneManager.LoadScene("Level5");
      //  Time.timeScale = 0;
    }
}
