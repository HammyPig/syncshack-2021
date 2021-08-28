using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float timeLeft = 0f;
    float startingTime = 30f;

    [SerializeField] Text countdownText;

    // Start is called before the first frame update
    void Start() {
        timeLeft = startingTime;
    }

    // Update is called once per frame
    void Update() {   
        if (timeLeft > 0) {
            timeLeft -= 1 * Time.deltaTime;
            countdownText.text = timeLeft.ToString("0");

            if (timeLeft <= 0) {
                timeLeft = 0;
                // run event
            }
        }
    }
}
