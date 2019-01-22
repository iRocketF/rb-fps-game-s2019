using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayerMovement : MonoBehaviour {

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
            if(Input.GetButton("JumpCntrl"))
            {
                jumpVelocity = jumpSpeed;
            } else {
                jumpVelocity = 0;
            }

        } else
        {
            jumpVelocity -= gravity * Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire2Cntrl"))
        {
            Blink();
        }

        moveDirection = new Vector3(Input.GetAxis("HorizontalCntrl") * speed, jumpVelocity, Input.GetAxis("VerticalCntrl") * speed);
        moveDirection = transform.TransformDirection(moveDirection);
        controller.Move(moveDirection * Time.deltaTime);

	}

    void Blink()
    {

        blinkDirection = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
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
