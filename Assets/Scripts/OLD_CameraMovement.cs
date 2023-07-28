using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Transform cam;
    Vector3 mouse;

    // Start is called before the first frame update
    void Start()
    {
        cam = transform.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        mouse.x = Input.GetAxis("Mouse X");
        mouse.y = Input.GetAxis("Mouse Y");

        transform.Rotate(0, mouse.x, 0, Space.World);
        cam.Rotate(-mouse.y, 0, 0, Space.Self);
    }
}
