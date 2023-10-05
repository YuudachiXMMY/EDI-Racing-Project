using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automovement : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent navMeshAgent;

    public Transform[] targets;
    private int targetsCounter;

    private bool arrive = false;

    public float distancePercentage;
    public float distanceTraveled;
    private float range = 30f;
    private float distanceBetweenTar;
    private float distancePrevious;
    private float distanceTotal = 3749.302f;

    public float speed;
    public float angularSpeed;
    public float acceleration;

    // Start is called before the first frame update
    void Start()
    {
        //navMeshAgent.speed = speed;
        //navMeshAgent.angularSpeed = angularSpeed;
        //navMeshAgent.acceleration = acceleration;

        distancePrevious = Vector3.Distance(transform.position, targets[targetsCounter].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (!arrive)
        {
            navMeshAgent.SetDestination(targets[targetsCounter].position);
        }

        distanceBetweenTar = Vector3.Distance(transform.position, targets[targetsCounter].position);

        if (distanceBetweenTar < range)
        {
            arrive = true;
            navMeshAgent.speed = 0;
            if (targetsCounter < targets.Length)
            {
                targetsCounter++;
            }
        }
        else
        {
            arrive = false;
            navMeshAgent.speed = speed;
            navMeshAgent.angularSpeed = angularSpeed;
            navMeshAgent.acceleration = acceleration;
            distanceTraveled += Mathf.Abs(distanceBetweenTar - distancePrevious);
            distancePercentage = (float)System.Math.Round(distanceTraveled / distanceTotal * 100, 2);
            distancePrevious = Vector3.Distance(transform.position, targets[targetsCounter].position);
        }
    }
}
