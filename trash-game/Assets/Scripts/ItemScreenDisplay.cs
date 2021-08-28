using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemScreenDisplay : MonoBehaviour
{
    string standby = "...";
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
        yield return new WaitForSeconds(0.3f);
        screenText.text = "..";
        yield return new WaitForSeconds(0.3f);
        screenText.text = "...";
        yield return new WaitForSeconds(0.4f);
        screenText.text = item;
        tickSource.Play();
    }
}
