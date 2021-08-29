using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemScreenDisplay : MonoBehaviour
{
    string item = "Shampoo Bottle";

    [SerializeField] TextMeshPro screenText;
    [SerializeField] AudioSource tickSource;
    
    // Start is called before the first frame update
    void Start() {
        tickSource = GetComponent<AudioSource>();
        StartCoroutine(setScreenText(item));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator setScreenText(string item) {
        screenText.text = ".";
        yield return new WaitForSeconds(0.33f);
        screenText.text = "..";
        yield return new WaitForSeconds(0.33f);
        screenText.text = "...";
        yield return new WaitForSeconds(0.34f);
        screenText.text = item;
        tickSource.Play();
    }

    public void updateScreen(string item) {
        StartCoroutine(setScreenText(item));
    }
}
