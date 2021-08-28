using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemScreenDisplay : MonoBehaviour
{
    public AudioSource tickSource;
    string standby = "...";
    string item = "Shampoo Bottle";
    [SerializeField] TextMeshPro screenText;
    
    // Start is called before the first frame update
    void Start() {
        //SpeechSynthesizer _SS = new SpeechSynthesizer();
        //_SS.Speak("Hello");
        tickSource = GetComponent<AudioSource>();
        StartCoroutine(setScreenText(item));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator setScreenText(string item) {
        screenText.text = standby;
        yield return new WaitForSeconds(1);
        screenText.text = item;
        tickSource.Play();
    }
}
