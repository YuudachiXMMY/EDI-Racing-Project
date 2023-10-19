using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonEvents : MonoBehaviour
{

    private GameObject[] event1UpdateList;
    private int event1UpdateListIndex;
    private GameObject[] event2UpdateList;
    private int event2UpdateListIndex;

    private float timer = 0.0f;
    private float event1Time = 0.0f;
    private float event2Time = 0.0f;
    private float waitTime = 2.0f;

    private bool event1Triggered = false;
    private bool event2Triggered = false;

    void Start()
    {
        event1UpdateList = new GameObject[100];
        event1UpdateListIndex = -1;
        event2UpdateList = new GameObject[100];
        event2UpdateListIndex = -1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (event1Triggered && timer > event1Time + waitTime)
        {
            while (event1UpdateListIndex != -1)
            {
                event1UpdateList[event1UpdateListIndex].GetComponent<carSpec>().speed = event1UpdateList[event1UpdateListIndex].GetComponent<carSpec>().automoveSpeed;
                event1UpdateListIndex--;
            }
            event1Triggered = false;
        }
        if (event2Triggered && timer > event2Time + waitTime)
        {
            while (event2UpdateListIndex != -1)
            {
                event2UpdateList[event2UpdateListIndex].GetComponent<carSpec>().speed = event2UpdateList[event2UpdateListIndex].GetComponent<carSpec>().automoveSpeed;
                event2UpdateListIndex--;
            }
            event2Triggered = false;
        }
    }

    public void Event_1()
    {
        GameObject[] cars = GameObject.FindGameObjectsWithTag("Cars");

        foreach (GameObject car in cars)
        {
            carSpec carSpecification = car.gameObject.GetComponent<carSpec>();
            if (System.Array.IndexOf(carSpecification.functionList, "FacialRecognition") != -1 ||
                System.Array.IndexOf(carSpecification.functionList, "FingerprintDetection") != -1)
            {
                carSpecification.speed = carSpecification.speed + 20;
                event1Time = timer;
                event1UpdateListIndex++;
                event1UpdateList[event1UpdateListIndex] = car.gameObject;
                event1Triggered = true;
            }
        }
    }

    public void Event_2(string input)
    { 
        GameObject[] cars = GameObject.FindGameObjectsWithTag("Cars");

        foreach (GameObject car in cars)
        {
            carSpec carSpecification = car.gameObject.GetComponent<carSpec>();
            if (carSpecification.color == input)
            {
                carSpecification.speed = carSpecification.speed - 20;
                event2Time = timer;
                event2UpdateListIndex++;
                event2UpdateList[event2UpdateListIndex] = car.gameObject;
                event2Triggered = true;
            }
        }

        GameObject.Find("BE-2").GetComponent<TMP_InputField>().text = "";
    }

    //FacialRecognition
    //VoiceAssistant
    //AutomaticEmergencyResponseSystem
    //FingerprintDetection
    //Anti-TheftSystem
    //PedestrianDetection
}
