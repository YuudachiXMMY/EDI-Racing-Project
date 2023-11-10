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
        {1, "male" },
        {2, "glasses" },
        {3, "facerecog" },
        {4, "language" },
        {5, "password" },
        {6, "distance" }
    };

    public Material material_Day1;
    public Material material_Snow1;
    public Material material_Night1;

    private void Start()
    {
        lt = ltObj.GetComponent<Light>();
        snow = GameObject.Find("SNOW");
        snow.SetActive(false);

        RenderSettings.skybox = material_Day1;
        RenderSettings.ambientIntensity = 1;
    }

    private void FixedUpdate()
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

        ResetInputField("Event-1");
    }

    public void Event_2(string input)
    {
        changeCarSpeedByColor(input, 20);
        ResetInputField("Event-2");
    }

    public void Event_3(string input)
    {
        changeCarSpeedByColor(input, -20);
        ResetInputField("Event-3");
    }

    public void Event_4(string input)
    {
        changeCarSpeedByFunction(input, 20);
        ResetInputField("Event-4");
    }

    public void Event_5(string input)
    {
        changeCarSpeedByFunction(input, -20);
        ResetInputField("Event-5");
    }

    public void Event_6()
    {
        if (!event6_triggered)
        {
            event6_triggered = true;
            snow.SetActive(event6_triggered);

            RenderSettings.skybox = material_Snow1;
            RenderSettings.ambientIntensity = 0.55f;

            //lt.color -= UnityEngine.Color.white * 20;

            //// Change Car Speed during the event
            //foreach (GameObject car in cars)
            //{
            //    carSpec carSpecification = car.gameObject.GetComponent<carSpec>();
            //    Automovement carAutomovement = car.gameObject.GetComponent<Automovement>();
            //    bool flag = System.Array.IndexOf(carSpecification.functionList, "Winter Tires") < 0;
            //    detectTriggerSpeedEvent(flag, -10, carAutomovement);
            //}
        } else
        {
            event6_triggered = false;
            snow.SetActive(event6_triggered);

            RenderSettings.skybox = material_Day1;
            RenderSettings.ambientIntensity = 1;

            //lt.color += UnityEngine.Color.white * 20;
        }
    }

    public void Event_7()
    {
        if (!event7_triggered)
        {
            event7_triggered = true;

            RenderSettings.skybox = material_Night1;
            RenderSettings.ambientIntensity = 0.2f;

            //lt.color -= UnityEngine.Color.white * 100;

            //// Change Car Speed during the event
            ////foreach (GameObject car in cars)
            ////{
            ////    carSpec carSpecification = car.gameObject.GetComponent<carSpec>();
            ////    Automovement carAutomovement = car.gameObject.GetComponent<Automovement>();
            ////    if (System.Array.IndexOf(carSpecification.functionList, "Assisted Night Vision") != -1)
            ////    {
            ////        carAutomovement.triggerSpeedEvent(10, waitTime);
            ////    }
            ////}
            //changeCarSpeedByFunction("4", 10);

        }
        else
        {
            event7_triggered = false;

            RenderSettings.skybox = material_Day1;
            RenderSettings.ambientIntensity = 1;

            //lt.color += UnityEngine.Color.white * 100;
        }
    }


    private void ResetInputField(string GameObjectName)
    {
        GameObject.Find(GameObjectName).GetComponent<TMP_InputField>().text = "";
    }

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
