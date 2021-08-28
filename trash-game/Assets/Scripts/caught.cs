using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caught : MonoBehaviour
{
    public AudioSource[] audioSource;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Caught trash");
        // check if trash matches truck

        //matches
        audioSource = GetComponents<AudioSource>();
        audioSource[1].Play();
        // destroy the trash
        Destroy(other);
    }
}
