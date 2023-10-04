using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automovement : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    public Transform[] target;
    private int targetCounter;

    private bool arrived = false;

    public float range = 10f;
    public float distanceTraveled;
    private float distance;
    private float prevDistance;
    private float totalDistance = 2461.054f;
    public float percentageDistance;

    public float carSpeed = 50.0f;
    public float carAcceleration = 8.0f;

    void Start()
    {
        navMeshAgent.speed = carSpeed;
        navMeshAgent.acceleration = carAcceleration;
        prevDistance = Vector3.Distance(transform.position, target[targetCounter].position);
    }

    // Update is called once per frame
    void Update()
    {

        if (!arrived)
        {
            navMeshAgent.SetDestination(target[targetCounter].position);
        }

        distance = Vector3.Distance(transform.position, target[targetCounter].position);


        if (distance > range)
        {
            arrived = false;
            navMeshAgent.speed = carSpeed;
            navMeshAgent.acceleration = carAcceleration;

            distanceTraveled += Mathf.Abs(distance - prevDistance);
            percentageDistance = (float)System.Math.Round(distanceTraveled / totalDistance * 100, 2);
            prevDistance = distance;
        } else
        {
            arrived = true;
            navMeshAgent.speed = 0;
            if (targetCounter != target.Length - 1)
            {
                targetCounter++;
            }
        }

    }
}
