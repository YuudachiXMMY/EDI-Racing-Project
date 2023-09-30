using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftBackground : MonoBehaviour
{

    // Move Left
    private float speed = 20;

    // Spawn
    private float startDelay = 2;
    private float repeatRate = 2;

    // Reset Position
    private Vector3 startPos;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);

        // Reset Position
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Move Left
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        // Reset Position
        if (transform.position.x < startPos.x - repeatWidth) {
            transform.position = startPos;
        }
    }
}
