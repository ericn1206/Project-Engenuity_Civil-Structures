using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
   // public GameObject backgroundMusic;
    public GameObject Cam;
    public GameObject TurnOn;
    public GameObject TurnOff;

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
            TurnOff.SetActive(true);
            TurnOn.SetActive(false);

        }
        else{
          //  backgroundMusic.SetActive(false);
            Cam.GetComponent<AudioSource>().enabled = false; 
            TurnOff.SetActive(false);
            TurnOn.SetActive(true);
        }
        
    }
    public void AudioOn(){
        PlayerPrefs.SetInt("Audio",0);
        PlayerPrefs.Save();
    }
    //initially, audio off will be pressed first, then it will toggle. 
    public void AudioOff(){
        PlayerPrefs.SetInt("Audio",1);
        PlayerPrefs.Save();
    }
    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }

}
