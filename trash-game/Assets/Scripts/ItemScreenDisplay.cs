using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemScreenDisplay : MonoBehaviour
{
    string standby = "...";
    string item = "Aluminium Cansssss";
    [SerializeField] TextMeshPro screenText;
    // Start is called before the first frame update
    void Start() {
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
    }
}
