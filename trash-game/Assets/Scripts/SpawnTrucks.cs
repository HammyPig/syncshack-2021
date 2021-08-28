using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrucks : MonoBehaviour
{
        public GameObject truckPrefab;
        public float respawnTime = 1.0f;
        private Vector3 screenBounds;

        private float timer;

        public Transform myTransform;

        public float zOffset = 5;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        Debug.Log("Setting screen bounds");
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        myTransform = GetComponent<Transform>();
        StartCoroutine(truckWave());
    }

    private void spawnTruck() {
        GameObject leftTruck = Instantiate(truckPrefab) as GameObject;
        leftTruck.transform.position = new Vector3(screenBounds.x * -3, myTransform.position.y, myTransform.position.z);
        leftTruck.transform.rotation = Quaternion.Euler(0, 270, 0);

        GameObject rightTruck = Instantiate(truckPrefab) as GameObject;
        rightTruck.GetComponent<Truck>().right = true;
        Transform rightTrans = rightTruck.GetComponent<Transform>();

        rightTruck.transform.position = new Vector3(screenBounds.x * 3, myTransform.position.y, myTransform.position.z + zOffset);

        // adjust speeds
        leftTruck.GetComponent<Truck>().speed += timer;
        rightTruck.GetComponent<Truck>().speed += timer;
        timer += 0.5f;
        // respawnTime /= 0.5f;
    }

    IEnumerator truckWave() {
        while(true) {
            yield return new WaitForSeconds(respawnTime);
            spawnTruck();
        }
    }

}
