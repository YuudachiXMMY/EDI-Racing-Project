using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Windows;

public class ButtonEvents : MonoBehaviour
{
    private float waitTime = 2.0f;
    private GameObject[] cars;

    private void Update()
    {
       cars  = GameObject.FindGameObjectsWithTag("Cars");
    }

    public void Event_1(string input)
    {
        foreach (GameObject car in cars)
        {
            carSpec carSpecification = car.gameObject.GetComponent<carSpec>();
            Automovement carAutomovement = car.gameObject.GetComponent<Automovement>();
            if (carSpecification.groupName.Length > Int32.Parse(input))
            {
                carAutomovement.triggerSpeedEvent(-20, waitTime);
            }
        }

        GameObject.Find("Event-1").GetComponent<TMP_InputField>().text = "";
    }

    public void Event_2(string input)
    {
        changeCarSpeedByColor(input, 20);
        GameObject.Find("Event-2").GetComponent<TMP_InputField>().text = "";
    }

    public void Event_3(string input)
    {
        changeCarSpeedByColor(input, -20);
        GameObject.Find("Event-3").GetComponent<TMP_InputField>().text = "";
    }

    public void Event_4()
    {
        foreach (GameObject car in cars)
        {
            carSpec carSpecification = car.gameObject.GetComponent<carSpec>();
            Automovement carAutomovement = car.gameObject.GetComponent<Automovement>();
            if (System.Array.IndexOf(carSpecification.functionList, "FacialRecognition") != -1 ||
                System.Array.IndexOf(carSpecification.functionList, "FingerprintDetection") != -1)
            {
                carAutomovement.triggerSpeedEvent(20, waitTime);
            }
        }
    }

    public void Event_5()
    {
        foreach (GameObject car in cars)
        {
            carSpec carSpecification = car.gameObject.GetComponent<carSpec>();
            Automovement carAutomovement = car.gameObject.GetComponent<Automovement>();
            if (System.Array.IndexOf(carSpecification.functionList, "FacialRecognition") != -1 ||
                System.Array.IndexOf(carSpecification.functionList, "FingerprintDetection") != -1)
            {
                carAutomovement.triggerSpeedEvent(-20, waitTime);
            }
        }
    }

    public void Event_7()
    {
        foreach (GameObject car in cars)
        {
            carSpec carSpecification = car.gameObject.GetComponent<carSpec>();
            Automovement carAutomovement = car.gameObject.GetComponent<Automovement>();
            if (System.Array.IndexOf(carSpecification.functionList, "FacialRecognition") != -1 ||
                System.Array.IndexOf(carSpecification.functionList, "FingerprintDetection") != -1)
            {
                carAutomovement.triggerSpeedEvent(20, waitTime);
            }
        }
    }

    //FacialRecognition
    //VoiceAssistant
    //AutomaticEmergencyResponseSystem
    //FingerprintDetection
    //Anti-TheftSystem
    //PedestrianDetection



    private void changeCarSpeedByColor(string input, float addSpeed)
    {
        foreach (GameObject car in cars)
        {
            carSpec carSpecification = car.gameObject.GetComponent<carSpec>();
            Automovement carAutomovement = car.gameObject.GetComponent<Automovement>();
            if (carSpecification.color == input)
            {
                carAutomovement.triggerSpeedEvent(addSpeed, waitTime);
            }
        }
    }
}
