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

    private carSpec carSpecification;

    private bool arrive = false;

    private float TravelingTimer = 0.0f;
    public float DashboardTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        targetsCounter = 0;
        targetsRound = 0;
        targetsTotalCount = 0;

        carSpecification = this.GetComponent<carSpec>();
    }

    private void FixedUpdate()
    {
        updateTimes();
    }

    // Update is called once per frame
    void Update()
    {
        updateNavMeshAgent();
    }


    /// Public Methods

    // If arrived, Update DashboardTime to 0 and Arrive to true.
    // Should used by carPointDetect.cs
    public void resetRankedTime()
    {
        DashboardTime = 0;
        SetArrive(true);
    }

    // Set Vehicle Arrive status
    public void SetArrive(bool statue)
    {
        arrive = statue;
    }


    /// Private Methods

    // If arrived, Update NavMesh Agent from one Target/Checkpoint to another
    private void updateNavMeshAgent()
    {
        if (arrive)
        {
            SetArrive(false);
            if (targetsCounter < targets.Length)
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
        }
        else
        {
            navMeshAgent.speed = carSpecification.speed;
            navMeshAgent.angularSpeed = carSpecification.automoveAngularSpeed;
            navMeshAgent.acceleration = carSpecification.automoveAcceleration;
            navMeshAgent.SetDestination(targets[targetsCounter].position);
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
