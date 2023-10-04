using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{

    private Vector3 initialPosition = new Vector3(1.8f, 113, 9.5f);
    private Vector3 initialScale = new Vector3(0.5f, 0.5f, 0.5f);
    private Quaternion initialRotation = new Quaternion(0, -18, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        transform.position = initialPosition;
        transform.localScale = initialScale;
        transform.rotation= initialRotation;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
