using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caught : MonoBehaviour
{
    public AudioSource[] audioSource;

    void Start() {
        audioSource = GetComponents<AudioSource>();
    }

    // assumes that projectiles (trash) has isTrigger enabled
    private void OnTriggerEnter(Collider other){
        Debug.Log("Caught trash");
        // check if trash matches truck

        //matches
        
        audioSource[1].Play();
        // destroy the trash
        // Destroy(other.gameObject);
    }
}
