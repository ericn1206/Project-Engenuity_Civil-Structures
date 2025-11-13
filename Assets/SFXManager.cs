using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SFXManager : MonoBehaviour
{
   // public GameObject backgroundMusic;
    public GameObject Cam;
   
    public AudioClip Death;
    public AudioClip Coin;
    public AudioClip Erase;
    [SerializeField] AudioSource SFXSource;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame

    //ZERO IS ON
    void Update()
    {
        if (PlayerPrefs.GetInt("Audio")==0){
          // backgroundMusic.SetActive(true);
            Cam.GetComponent<AudioSource>().enabled = true; 
           

        }
        else{
          //  backgroundMusic.SetActive(false);
            Cam.GetComponent<AudioSource>().enabled = false; 
         
        }
        
    }
    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }

}
