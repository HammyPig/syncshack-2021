using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caught : MonoBehaviour
{
    public CountdownTimer countdown;
    [SerializeField] AudioSource goodAudio;
    [SerializeField] AudioSource badAudio;
    public Truck truck;

    void Start() {
    }

    // assumes that projectiles (trash) has isTrigger enabled
    private void OnTriggerEnter(Collider other) {
        if (truck.truckType == Truck.trashType.TRASH) {
            if (other.gameObject.tag == "Trash") {
                CountdownTimer.addToTime(5f);
                Destroy(other.gameObject);
                goodAudio.Play();
            } else if (other.gameObject.tag == "Recycle") {
                badAudio.Play();
                Destroy(other.gameObject);
            }
        }

        if (truck.truckType == Truck.trashType.RECYCLABLE) {
            if (other.gameObject.tag == "Recycle") {
                CountdownTimer.addToTime(5f);
                Destroy(other.gameObject);
                goodAudio.Play();
            } else if (other.gameObject.tag == "Trash") {
                badAudio.Play();
                Destroy(other.gameObject);
            }
        }
    }
}
