using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Truck : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public bool right;
    private Vector3 screenBounds;

    private trashType truckType;

    enum trashType {
        TRASH, // 0
        RECYCLABLE // 1
    }

    // Start is called before the first frame update
    void Start()
    {

        rb = this.GetComponent<Rigidbody>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));


        // give trash type
        System.Random r = new System.Random();
        int genRand = r.Next(0, 2);
        truckType = (trashType)genRand;


        if(genRand == 0) {
            // it is trash
            // m_material.color = Color.red;
            gameObject.GetComponent<Renderer>().material.color = new Color32(140, 14, 14, 255);

        } else {
            // m_material.color = Color.green;
            gameObject.GetComponent<Renderer>().material.color = new Color32(14, 118, 10, 255);
        }
        
        if(right) {
            rb.velocity = new Vector3(1 * speed, 0, 0);
        } else {
            rb.velocity = new Vector3(-1 * speed, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!right && transform.position.x < screenBounds.x * 3) {
            Destroy(this.gameObject);
        } else if(right && transform.position.x > screenBounds.x * -3) {
            Destroy(this.gameObject);
        }
    }
}
