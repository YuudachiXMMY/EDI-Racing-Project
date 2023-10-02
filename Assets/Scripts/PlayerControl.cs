using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Vector3 initialPosition = new Vector3(0, 14, 0); //(-138, 21.5f, 30);
    private Vector3 initialScale = new Vector3(1, 1, 1);
    private Quaternion initialRotation = new Quaternion(0, 0, 0, 0);
    private float speed = 15.0f;
    private float turnSpeed = 100.0f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = initialPosition;
        //transform.localScale = initialScale;
        //transform.rotation = initialRotation;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * speed * forwardInput * Time.deltaTime);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        if (Input.GetKeyDown("space")) {
            transform.position = initialPosition;
            transform.localScale = initialScale;
            transform.rotation = initialRotation;
        }
    }
}
