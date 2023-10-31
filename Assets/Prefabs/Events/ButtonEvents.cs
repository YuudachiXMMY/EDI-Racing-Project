using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Windows;
using Unity.VisualScripting;
using System.Drawing;

public class ButtonEvents : MonoBehaviour
{

    public GameObject ltObj;
    private Light lt;

    private float waitTime = 2.0f;
    private GameObject[] cars;

    private GameObject snow;
    private bool event6_triggered = false;
    private bool event7_triggered = false;

    private void Start()
    {
        lt = ltObj.GetComponent<Light>();
        snow = GameObject.Find("SNOW");
        snow.SetActive(false);
    }

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

    public void Event_6()
    {
        if (!event6_triggered)
        {
            event6_triggered = true;
            snow.SetActive(event6_triggered);

            lt.color -= UnityEngine.Color.white * 20;

            foreach (GameObject car in cars)
            {
                carSpec carSpecification = car.gameObject.GetComponent<carSpec>();
                Automovement carAutomovement = car.gameObject.GetComponent<Automovement>();
                if (System.Array.IndexOf(carSpecification.functionList, "WinterTire") < 0)
                {
                    carAutomovement.triggerSpeedEvent(-19, waitTime);
                }
            }
        } else
        {
            event6_triggered = false;
            snow.SetActive(event6_triggered);

            lt.color += UnityEngine.Color.white * 20;
        }
    }

    public void Event_7()
    {
        if (!event7_triggered)
        {
            event7_triggered = true;

            lt.color -= UnityEngine.Color.white * 100;

            foreach (GameObject car in cars)
            {
                carSpec carSpecification = car.gameObject.GetComponent<carSpec>();
                Automovement carAutomovement = car.gameObject.GetComponent<Automovement>();
                if (System.Array.IndexOf(carSpecification.functionList, "AssistedNightVision") != -1)
                {
                    carAutomovement.triggerSpeedEvent(10, waitTime);
                }
            }
        }
        else
        {
            event7_triggered = false;

            lt.color += UnityEngine.Color.white * 100;
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
