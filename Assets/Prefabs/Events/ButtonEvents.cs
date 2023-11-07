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

    private float waitTime = 5.0f;
    private GameObject[] cars;

    private GameObject snow;
    private bool event6_triggered = false;
    private bool event7_triggered = false;

    private Dictionary<int, string> carFunctionDictionary = new Dictionary<int, string>() {
        {1, "Facial Recognition" },
        {2, "Inter-car Communication" },
        {3, "Tracking" },
        {4, "Assisted Night Vision" },
        {5, "Winter Tires" },
        {6, "Nitrogen Accelerator" },
        {7, "HEV" },
        {8, "Proactive Safety Control" }
    };

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
            bool flag = carSpecification.groupName.Length > Int32.Parse(input);
            detectTriggerSpeedEvent(flag, -20, carAutomovement);
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

    public void Event_4(string input)
    {
        changeCarSpeedByFunction(input, 20);
        GameObject.Find("Event-4").GetComponent<TMP_InputField>().text = "";
    }

    public void Event_5(string input)
    {
        changeCarSpeedByFunction(input, -20);
        GameObject.Find("Event-5").GetComponent<TMP_InputField>().text = "";
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
                bool flag = System.Array.IndexOf(carSpecification.functionList, "Winter Tires") < 0;
                detectTriggerSpeedEvent(flag, -10, carAutomovement);
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

            //foreach (GameObject car in cars)
            //{
            //    carSpec carSpecification = car.gameObject.GetComponent<carSpec>();
            //    Automovement carAutomovement = car.gameObject.GetComponent<Automovement>();
            //    if (System.Array.IndexOf(carSpecification.functionList, "Assisted Night Vision") != -1)
            //    {
            //        carAutomovement.triggerSpeedEvent(10, waitTime);
            //    }
            //}
            changeCarSpeedByFunction("4", 10);

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
            bool flag = carSpecification.color == input;
            detectTriggerSpeedEvent(flag, addSpeed, carAutomovement);
        }
    }
    private void changeCarSpeedByFunction(string input, float addSpeed)
    {
        foreach (GameObject car in cars)
        {
            carSpec carSpecification = car.gameObject.GetComponent<carSpec>();
            Automovement carAutomovement = car.gameObject.GetComponent<Automovement>();
            bool flag = System.Array.IndexOf(carSpecification.functionList, carFunctionDictionary[Int32.Parse(input)]) != -1;
            detectTriggerSpeedEvent(flag, addSpeed, carAutomovement);
        }
    }

    private void detectTriggerSpeedEvent(bool flag, float addSpeed, Automovement carAutomovement)
    {
        if (flag)
        {
            carAutomovement.triggerSpeedEvent(addSpeed, waitTime);
        }
    }
}
