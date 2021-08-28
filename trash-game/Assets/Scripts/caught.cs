using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caught : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Caught trash");
        // check if trash matches truck
        // destroy the trash
        Destroy(other);
    }
}
