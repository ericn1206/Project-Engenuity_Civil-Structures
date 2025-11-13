using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
using TMPro;
public class playapreftesting : MonoBehaviour
{
    public GameObject budtext;
    public TMP_Text budget; 
    // Start is called before the first frame update
    void Start()
    {
        budget = budtext.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        budget.text = PlayerPrefs.GetInt("Audio").ToString();
    }
}
