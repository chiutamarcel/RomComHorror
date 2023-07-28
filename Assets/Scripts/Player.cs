using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    const float GRAV_ACCEL = 9.8f;
    const float MAX_VELOCITY = 500.0f;
    float fall_speed = 0.0f;
    float speed = 5.0f;
    float hor = 0.0f, vert = 0.0f;
    Vector3 movDir;
    CharacterController charCtrl;
    // Start is called before the first frame update
    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input
        movDir = Vector3.zero;
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        // Add movement
        movDir += transform.right * hor;
        movDir += transform.forward * vert;

        // Add gravity
        if (charCtrl.isGrounded == false)
        {
            fall_speed += GRAV_ACCEL * Time.deltaTime;
        }
        else
            fall_speed = 0.0f;

        // Jumping
        if (Input.GetAxisRaw("Jump") == 1 && charCtrl.isGrounded)
        {
            fall_speed = -2.0f;
        }


        // Apply movement
        charCtrl.Move(( movDir - fall_speed * transform.up) * speed * Time.deltaTime);
    }
}
