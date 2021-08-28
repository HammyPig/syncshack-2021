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

    private Material m_material;

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

        // material
        m_material = GetComponent<Renderer>().material;

        if(genRand == 0) {
            // it is trash
            m_material.color = Color.red;
        } else {
            m_material.color = Color.green;
        }

        Debug.Log("Trash type:" + truckType);
        
        if(right) {
            Debug.Log("I am moving to the right");
            rb.velocity = new Vector3(1 * speed, 0, 0);
        } else {
            Debug.Log("I am moving to the left");
            rb.velocity = new Vector3(-1 * speed, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!right && transform.position.x < screenBounds.x * 2) {
            Destroy(this.gameObject);
        } else if(right && transform.position.x > screenBounds.x * -2) {
            Destroy(this.gameObject);
        }
    }
}
