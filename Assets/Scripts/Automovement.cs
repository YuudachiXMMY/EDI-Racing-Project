using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private float TravelingTimer = 0.0f;
    public float DashboardTime = 0.0f;

    // speedEvents = [ {{"addSpeed" : float}, {"triggeredTime" : float}, {"waitTime" : float}} ]
    private List<Dictionary<string, float>> speedEvents = new List<Dictionary<string, float>>();
    private int speedEventsCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        carSpecification = this.GetComponent<carSpec>();
    }

    private void FixedUpdate()
    {
        updateTimes();
        checkSpeedEvents();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.speed = carSpecification.speed;
        navMeshAgent.angularSpeed = carSpecification.automoveAngularSpeed;
        navMeshAgent.acceleration = carSpecification.automoveAcceleration;
        navMeshAgent.SetDestination(targets[targetsCounter].position);
    }


    /// Public Methods

    // If arrived, Update DashboardTime to 0 and Arrive to true.
    // Should be used by carPointDetect.cs
    public void resetRankedTime()
    {
        DashboardTime = 0;
        updateNavMeshAgent(true);
    }

    public void triggerSpeedEvent(float addSpeed, float waitTime)
    {
        carSpecification.speed = carSpecification.speed + addSpeed;
        Dictionary<string, float> newEvent = new Dictionary<string, float>();
        newEvent.Add("addSpeed", addSpeed);
        newEvent.Add("triggeredTime", TravelingTimer);
        newEvent.Add("waitTime", waitTime);
        speedEvents.Add(newEvent);
        speedEventsCounter++;
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

    // Check if the Speed Events need to be reset,
    // if Yes, reset the speed by minusing the added speed.
    private void checkSpeedEvents()
    {
        foreach (Dictionary<string, float> speedEvent in speedEvents.ToList())
        {
            if (speedEvent["waitTime"] + speedEvent["triggeredTime"] < TravelingTimer)
            {
                carSpecification.speed -= speedEvent["addSpeed"];
                speedEvents.Remove(speedEvent);
            }
        }
    }
}
