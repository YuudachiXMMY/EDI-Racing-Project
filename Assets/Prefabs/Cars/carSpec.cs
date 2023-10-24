using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpec : MonoBehaviour
{
    public string groupName;
    public int model;
    public string color;
    public float rbMass;
    public float rbAngularDrag;

    public float speed;
    public float automoveSpeed;
    public float automoveAngularSpeed;
    public float automoveAcceleration;
    public float automoveBaseOffset;
    public float automoveRankedTime;
    public float automoveRound;
    public float automoveTargetsTotalCount;

    public string[] functionList;
}
