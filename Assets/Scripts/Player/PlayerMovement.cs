using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 8.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float maxBlinkLength = 4.0f;
    public Vector3 blinkDirection;
    public int playerNumber;

    private float jumpVelocity = 0.0f;
    private Vector3 moveDirection = Vector3.zero;
    private RaycastHit hit;

    private string jumpString = "Jump_Gamepad", blinkString = "Fire2_Gamepad", horString = "Horizontal_Gamepad", verString = "Vertical_Gamepad";

    private void Start()
    {
        jumpString += playerNumber;
        blinkString += playerNumber;
        horString += playerNumber;
        verString += playerNumber;
 
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        if (controller.collisionFlags == CollisionFlags.Below || controller.isGrounded)
        {
            if (Input.GetButton(jumpString))
            {
                jumpVelocity = jumpSpeed;
            }
            else
            {
                jumpVelocity = 0;
            }

        }
        else
        {
            jumpVelocity -= gravity * Time.deltaTime;
        }

        if (Input.GetButtonDown(blinkString))
        {
            Blink();
        }

        moveDirection = new Vector3(Input.GetAxis(horString) * speed, jumpVelocity, Input.GetAxis(verString) * speed);
        moveDirection = transform.TransformDirection(moveDirection);
        controller.Move(moveDirection * Time.deltaTime);

    }

    void Blink()
    {

        blinkDirection = transform.forward * Input.GetAxis(verString) + transform.right * Input.GetAxis(horString);
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

