using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour {

    public float speed = 8.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float maxBlinkLength = 4.0f;
    public Vector3 blinkDirection;

    private float jumpVelocity = 0.0f;
    private Vector3 moveDirection = Vector3.zero;
    private RaycastHit hit;


    // Update is called once per frame
    void Update () {
        CharacterController controller = GetComponent<CharacterController>();

        if (controller.collisionFlags == CollisionFlags.Below || controller.isGrounded)
        {
            if(Input.GetButton("Jump_Gamepad2"))
            {
                jumpVelocity = jumpSpeed;
            } else {
                jumpVelocity = 0;
            }

        } else
        {
            jumpVelocity -= gravity * Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire2_Gamepad2"))
        {
            Blink();
        }

        moveDirection = new Vector3(Input.GetAxis("Horizontal_Gamepad2") * speed, jumpVelocity, Input.GetAxis("Vertical_Gamepad2") * speed);
        moveDirection = transform.TransformDirection(moveDirection);
        controller.Move(moveDirection * Time.deltaTime);

	}

    void Blink()
    {

        blinkDirection = transform.forward * Input.GetAxis("Vertical_Gamepad2") + transform.right * Input.GetAxis("Horizontal_Gamepad2");
        blinkDirection.y = 0;
        blinkDirection.Normalize();
        float blinkLength = maxBlinkLength;

        if (Physics.Raycast(transform.position, blinkDirection, out hit, blinkLength))
        {
            blinkLength = hit.distance;
        }

        transform.position = transform.position + (blinkDirection * blinkLength);
    }
}
