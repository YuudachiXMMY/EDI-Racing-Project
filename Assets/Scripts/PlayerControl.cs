using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Vector3 initialPosition = new Vector3(0, 72, 30); //(-138, 21.5f, 30);
    private Vector3 initialScale = new Vector3(0.5f, 0.5f, 0.5f);
    private Quaternion initialRotation = new Quaternion(0, 0, 0, 0);

    //public Rigidbody rb = null;
    //public float speed = 25.0f;
    //public float turnSpeed = 0.9f;
    //private float horizontalInput;
    //private float forwardInput;

    //private Animator playerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = initialPosition;
        transform.localScale = initialScale;
        transform.rotation = initialRotation;

        //playerAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //forwardInput = Input.GetAxis("Vertical");
        //horizontalInput = Input.GetAxis("Horizontal");

        //rb.AddRelativeForce(Vector3.forward * forwardInput * speed, ForceMode.Acceleration);
        //rb.AddRelativeTorque(Vector3.up * horizontalInput * turnSpeed, ForceMode.VelocityChange);

        //if (forwardInput.GetKeyDown(KeyCode.w))
        //{
        //    playerAnimation.SetTrigger();
        //}

        //transform.Translate(Vector3.forward * speed * forwardInput * Time.deltaTime);
        //transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        if (Input.GetKeyDown("space"))
        {
            transform.position = initialPosition;
            transform.localScale = initialScale;
            transform.rotation = initialRotation;

            //transform.position = this.transform.position + new Vector3(0, 5, 0);
            //transform.rotation = new Quaternion(0, initialRotation.y, initialRotation.z, initialRotation.w);
        }
    }
}
