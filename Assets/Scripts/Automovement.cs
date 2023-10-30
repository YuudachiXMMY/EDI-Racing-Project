using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Automovement : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent navMeshAgent;

    public Transform[] targets;
    private int targetsCounter;
    private int targetsRound;
    private int targetsTotalCount;

    private float range = 20.0f;
    private float distanceBetweenTarget;

    private carSpec carSpecification;

    private float TravelingTimer = 0.0f;
    public float DashboardTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        targetsCounter = 0;
        targetsRound = 0;
        targetsTotalCount = 0;
        //distanceBetweenTarget = Vector3.Distance(transform.position, targets[targetsCounter].transform.position);

        carSpecification = this.GetComponent<carSpec>();
    }

    private void FixedUpdate()
    {
        updateTimes();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.speed = carSpecification.speed;
        navMeshAgent.angularSpeed = carSpecification.automoveAngularSpeed;
        navMeshAgent.acceleration = carSpecification.automoveAcceleration;
        navMeshAgent.SetDestination(targets[targetsCounter].position);

        distanceBetweenTarget = Vector3.Distance(this.transform.position, targets[targetsCounter].position);

        if (distanceBetweenTarget < range)
        {
            updateNavMeshAgent();
        }
    }


    /// Public Methods

    // If arrived, Update DashboardTime to 0 and Arrive to true.
    // Should be used by carPointDetect.cs
    public void resetRankedTime()
    {
        DashboardTime = 0;
        updateNavMeshAgent(true);
    }

    /// Private Methods

    // If arrived, Update NavMesh Agent from one Target/Checkpoint to another
    private void updateNavMeshAgent(bool instant = false)
    {
        targetsCounter++;
        targetsTotalCount++;
        carSpecification.automoveTargetsTotalCount = targetsTotalCount;
        if (targetsCounter == targets.Length)
        {
            targetsCounter = 0;
            targetsRound += 1;
            carSpecification.automoveRound = targetsRound;
        }
    }

    // Refresh all Timer with deltaTime
    private void updateTimes()
    {
        TravelingTimer += Time.deltaTime;
        DashboardTime += Time.deltaTime;
        carSpecification.automoveRankedTime = DashboardTime;
    }
}
