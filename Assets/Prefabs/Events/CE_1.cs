using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CE_1 : MonoBehaviour
{
    private float waitTime = 2.0f;

    void OnTriggerEnter(Collider other)
    {
        carSpec carSpecification = other.gameObject.GetComponent<carSpec>();
        Automovement carAutomovement = other.gameObject.GetComponent<Automovement>();
        if (System.Array.IndexOf(carSpecification.functionList, "FacialRecognition") != -1 ||
            System.Array.IndexOf(carSpecification.functionList, "FingerprintDetection") != -1)
        {
            carAutomovement.triggerSpeedEvent(20, waitTime);
        }
    }
}
