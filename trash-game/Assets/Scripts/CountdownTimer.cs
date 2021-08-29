using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    bool alarm = true;
    private static float timeLeft = 0f;
    public float startingTime = 30f;

    [SerializeField] Text countdownText;
    [SerializeField] AudioSource warningSound;
    [SerializeField] AudioSource finishSound;
    public GameOverScreen gameOverScreen;
    public GameObject cannon;

    // Start is called before the first frame update
    void Start() {
        timeLeft = startingTime;
    }

    // Update is called once per frame
    void Update() {   
        if (timeLeft > 0) {
            timeLeft -= 1 * Time.deltaTime;
            countdownText.text = timeLeft.ToString("0");

            if (timeLeft < 0.5) {
                warningSound.pitch = 1.3f;
            }

            if (timeLeft <= 5.5) {
                if (alarm) {
                    alarm = false;
                    StartCoroutine(soundAlarm());
                }
            }

            if (timeLeft <= 0) {
                timeLeft = 0;
                cannon.SetActive(false);
                gameOver();
            }
        }
    }

    public static void addToTime(float time) {
        timeLeft += time;
    }

    IEnumerator soundAlarm() {
        warningSound.Play();
        yield return new WaitForSeconds(1);
        alarm = true;
    }

    public void gameOver() {
        gameOverScreen.setup(10);
    }
}
