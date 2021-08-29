using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody trashBall;
    public Rigidbody recycleBall;
    public GameObject cursor;
    public Transform firePoint;
    public LayerMask layer;
    public Transform stand;
    [SerializeField] AudioSource explosionAudio;

    public ItemScreenDisplay itemScreen;

    private Camera cam;

    private int index = 0;

    System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start() {
        cam = Camera.main;
        explosionAudio = GetComponent<AudioSource>();
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
                Rigidbody obj;
                if (CSVReader.trashList.trashList[index].trashType == 0) {
                    obj = Instantiate(trashBall, firePoint.position, Quaternion.identity);
                } else {
                    obj = Instantiate(recycleBall, firePoint.position, Quaternion.identity);
                }
                obj.velocity = vo;
                index = random.Next(0, CSVReader.trashList.trashList.Length);
                itemScreen.updateScreen(CSVReader.trashList.trashList[index].name);
                explosionAudio.Play();
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
