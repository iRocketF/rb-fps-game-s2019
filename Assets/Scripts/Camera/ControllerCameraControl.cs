﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCameraControl : MonoBehaviour {

	public enum RotationAxis
    {
        JoystickX = 1,
        JoystickY = 2
    }

    public RotationAxis axes = RotationAxis.JoystickX;

    public float minimumVert = -90.0f;
    public float maximumVert = 90.0f;
    public float sensHorizontal = 10.0f;
    public float sensVertical = 10.0f;

    public float _rotationX = 0;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update () {
        if(axes == RotationAxis.JoystickX)
        {
            transform.Rotate (0, Input.GetAxis("Joystick X") * sensHorizontal, 0);
        } else if(axes == RotationAxis.JoystickY)
        {
            _rotationX -= Input.GetAxis("Joystick Y") * sensVertical;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert); // pitää vertikaalisen kulman min ja max rajojen sisällä

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }

        {
              
        }

        Debug.DrawRay(transform.position, transform.forward * 10, Color.black);

		 
	}
}