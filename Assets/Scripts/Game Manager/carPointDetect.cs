using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carPointDetect : MonoBehaviour
{

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        Automovement automovement = other.gameObject.GetComponent<Automovement>();
        automovement.resetRankedTime();
        ScoreDashboard scoreDashboard = GameObject.Find("GameManager_Track_1").GetComponent<ScoreDashboard>();
        scoreDashboard.updateCarSpec(automovement.getCarSpec());
    }
}
