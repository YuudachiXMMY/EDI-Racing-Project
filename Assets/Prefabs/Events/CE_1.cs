using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CE_1 : MonoBehaviour
{

    private GameObject[] updateList;
    private int updateListIndex;

    private float timer = 0.0f;
    private float curTime = 0.0f;
    private float waitTime = 2.0f;

    private bool triggered = false;

    void Start()
    {
        updateList = new GameObject[100];
        updateListIndex = -1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (triggered && timer > curTime + waitTime)
        {
            Debug.Log("Time Triggered");
            while (updateListIndex != -1)
            {
                updateList[updateListIndex].GetComponent<carSpec>().speed = updateList[updateListIndex].GetComponent<carSpec>().automoveSpeed;
                updateListIndex--;
                Debug.Log(updateListIndex);
            }
            triggered = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Event"))
        //{
        //    Debug.Log("Event Triggered");
        //}
        carSpec carSpecification = other.gameObject.GetComponent<carSpec>();
        if (System.Array.IndexOf(carSpecification.functionList, "FacialRecognition") != -1 ||
            System.Array.IndexOf(carSpecification.functionList, "FingerprintDetection") != -1)
        {
            carSpecification.speed = carSpecification.speed + 20;
            curTime = timer;
            updateListIndex++;
            updateList[updateListIndex] = other.gameObject;
            Debug.Log(updateListIndex);
            triggered = true;
        }
    }

    //FacialRecognition
    //VoiceAssistant
    //AutomaticEmergencyResponseSystem
    //FingerprintDetection
    //Anti-TheftSystem
    //PedestrianDetection
}
