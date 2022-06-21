using System;
using UnityEngine;
using System.Collections;

public class FlyCamera : MonoBehaviour
{



    public float cameraSensitivity = 90;
    public float climbSpeed = 4;
    public float normalMoveSpeed = 10;
    public float slowMoveFactor = 0.25f;
    public float fastMoveFactor = 3;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Start()
    {
        Screen.lockCursor = true;
        //Cursor.lockState= CursorLockMode.Locked;
    }

    void Update()
    {

        //Duplicate 'Mouse X', name it 'Joy X' from InputManager and change Type -> Joystick Axis
        //Axis -> 4th axis (joystick)
        //Sensitivity = 1
        rotationX += Input.GetAxis("Joy X") * cameraSensitivity * Time.deltaTime;

        //Duplicate 'Mouse Y', name it 'Joy Y' from InputManager and change Type -> Joystick Axis
        //Axis -> 5th axis (joystick)
        //Sensitivity = 1
        //Invert = true (check)
        rotationY += Input.GetAxis("Joy Y") * cameraSensitivity * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, -90, 90);

        transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

        //if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        if (Input.GetKey(KeyCode.Joystick1Button0))
        {
            transform.position += transform.forward * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
            transform.position += transform.right * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            transform.position += transform.forward * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
            transform.position += transform.right * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
        }
        else
        {
            transform.position += transform.forward * normalMoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
            transform.position += transform.right * normalMoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.Joystick1Button5)) { transform.position += transform.up * climbSpeed * Time.deltaTime; }
        if (Input.GetKey(KeyCode.Joystick1Button4)) { transform.position -= transform.up * climbSpeed * Time.deltaTime; }

        if (Input.GetKeyDown(KeyCode.End))
        {
            Screen.lockCursor = (Screen.lockCursor == false) ? true : false;
        }
    }
}