using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class MainMenu : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void PlayGame() {
        SceneManager.LoadScene("Anna");
    }
}
