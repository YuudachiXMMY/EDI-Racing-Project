using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerControll : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 35f;
    public float runSpeed = 50f;

    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;
    public CharacterController characterController;

    private bool fixedCamera = false;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Fixed Camera Hotkeys
        switchCameraPosition();

        if (!fixedCamera && !hotKeys.gamePause)
        {
            // Player Control
            playerFreeMoveControl();
        }
    }

    private void playerFreeMoveControl()
    {
        // Moving
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        Vector3 up = transform.TransformDirection(Vector3.up);

        // Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float curSpeedZ = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Jump") : 0;
        //float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY) + (up * curSpeedZ);

        // Rotation and Camera
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX -= Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

    private void switchCameraPosition()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            fixedCamera = false;
        } else if (Input.GetKeyDown(KeyCode.Alpha2) ||
                Input.GetKeyDown(KeyCode.Alpha3) ||
                Input.GetKeyDown(KeyCode.Alpha4) ||
                Input.GetKeyDown(KeyCode.Alpha5) ||
                Input.GetKeyDown(KeyCode.Alpha6) ||
                Input.GetKeyDown(KeyCode.Alpha7) ||
                Input.GetKeyDown(KeyCode.Alpha8) ||
                Input.GetKeyDown(KeyCode.Alpha9) ||
                Input.GetKeyDown(KeyCode.Alpha0))
        {
            fixedCamera = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerCamera.transform.localRotation = Quaternion.Euler(35, 0, 0);
            transform.rotation = Quaternion.Euler(0, -160, 0);
            transform.position = new Vector3(-25f, 18f, -12f);
            //playerCamera.transform.localRotation = Quaternion.Euler(35, 0, 0);
            //transform.rotation = Quaternion.Euler(0, -160, 0);
            //transform.position = new Vector3(1.8f, 35f, 6f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerCamera.transform.localRotation = Quaternion.Euler(35, 0, 0);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.position = new Vector3(-300f, 40f, -160f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playerCamera.transform.localRotation = Quaternion.Euler(35, 0, 0);
            transform.rotation = Quaternion.Euler(0, 25, 0);
            transform.position = new Vector3(-185f, 20f, -310f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            playerCamera.transform.localRotation = Quaternion.Euler(35, 0, 0);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.position = new Vector3(-115f, 15f, -295f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            playerCamera.transform.localRotation = Quaternion.Euler(35, 0, 0);
            transform.rotation = Quaternion.Euler(0, -25, 0);
            transform.position = new Vector3(185f, 20f, -310f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            playerCamera.transform.localRotation = Quaternion.Euler(35, 0, 0);
            transform.rotation = Quaternion.Euler(0, -150, 0);
            transform.position = new Vector3(220f, 20f, -35f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            playerCamera.transform.localRotation = Quaternion.Euler(25, 0, 0);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            transform.position = new Vector3(125f, 2.5f, -27.5f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            playerCamera.transform.localRotation = Quaternion.Euler(30, 0, 0);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.position = new Vector3(-45f, 3f, -27.5f);
        }

        // Repeated
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            playerCamera.transform.localRotation = Quaternion.Euler(90, 0, 0);
            transform.rotation = Quaternion.Euler(0, -180, 0);
            transform.position = new Vector3(2f, 147.5f, -160f);
        }
    }
}
