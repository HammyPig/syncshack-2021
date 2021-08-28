using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;

    public void setup(int score) {
        gameObject.SetActive(true);
        scoreText.text = score.ToString() + " POINTS";
    }

    public void restartButton() {
        Debug.Log("helppppp!");
        SceneManager.LoadScene("Endless");
    }

    public void menuButton() {
        SceneManager.LoadScene("MainMenu");
    }
}
