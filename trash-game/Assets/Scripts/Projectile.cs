using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody trashBall;
    public GameObject cursor;
    public Transform firePoint;
    public LayerMask layer;
    public Transform stand;

    private Camera cam;

    // Start is called before the first frame update
    void Start() {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        launchTrashBall();
    }

    void launchTrashBall() {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(camRay, out hit, 100f, layer)) {
            cursor.SetActive(true);
            cursor.transform.position = hit.point + Vector3.up * 0.1f;

            Vector3 vo = calculateVelocity(hit.point, firePoint.position, 1f);

            transform.rotation = Quaternion.LookRotation(vo);
            stand.rotation = Quaternion.Euler(0.0f, transform.rotation.eulerAngles.y, 0.0f);

            if (Input.GetMouseButtonDown(0)) {
                Rigidbody obj = Instantiate(trashBall, firePoint.position, Quaternion.identity);
                obj.velocity = vo;
            }
        } else {
            cursor.SetActive(false);
        }
    }
    Vector3 calculateVelocity(Vector3 target, Vector3 origin, float time) {
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;

        float sy = distance.y;
        float sxz = distanceXZ.magnitude;

        float vxz = sxz / time;
        float vy = sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized;
        result *= vxz;
        result.y = vy;

        return result;
    }
}
