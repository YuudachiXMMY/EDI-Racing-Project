using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class ScoreDashboard : MonoBehaviour
{

    public GameObject[] scoredashboardColumns;
    public GameObject scoredashboardTop10;

    private Dictionary<string, carSpec> carsData;
    //private Dictionary<string, float> carsDataRanking;

    // Start is called before the first frame update
    void Start()
    {
        carsData = new Dictionary<string, carSpec>();
    }

    // Update is called once per frame
    void Update()
    {
        parseCarSpec();
        updateScoreDashboard();
    }

    void parseCarSpec()
    {
        GameObject[] carsObj = GameObject.FindGameObjectsWithTag("Cars");

        foreach (GameObject carObj in carsObj)
        {
            carSpec carSpecification = carObj.GetComponent<carSpec>();
            if (!carsData.ContainsKey(carSpecification.groupName))
            {
                carsData.Add(carSpecification.groupName, carSpecification);
            } else
            {
                carsData[carSpecification.groupName] = carSpecification;
            }
            //if (!carsDataRanking.ContainsKey(carSpecification.groupName))
            //{
            //    carsDataRanking.Add(carSpecification.groupName, carSpecification.automoveDistanceTraveled);
            //}
            //else
            //{
            //    carsDataRanking[carSpecification.groupName] = carSpecification.automoveDistanceTraveled;
            //}
        }
    }

    void updateScoreDashboard()
    {
        var sortedCarsData = carsData.OrderByDescending(pair => pair.Value.automoveDistanceTraveled);
        int scoredashboardIndex = 0;
        int counts = 0;
        TMPro.TextMeshProUGUI mTextTMP = scoredashboardColumns[scoredashboardIndex].GetComponent<TMPro.TextMeshProUGUI>();
        mTextTMP.text = "";
        foreach (var pair in sortedCarsData)
        {
            mTextTMP.text += (counts+1).ToString() + ". " + pair.Key + ": " + System.Math.Round(pair.Value.automoveDistanceTraveled, 2).ToString() + "\n";
            counts ++;
            if (counts % 18 == 0)
            {
                scoredashboardIndex++;
                mTextTMP = scoredashboardColumns[scoredashboardIndex].GetComponent<TMPro.TextMeshProUGUI>();
                mTextTMP.text = "";
            }
        }

        var top10 = sortedCarsData.Take(10);
        counts = 0;
        mTextTMP = scoredashboardTop10.GetComponent<TMPro.TextMeshProUGUI>();
        mTextTMP.text = "[Top 10]\n";
        foreach (var pair in top10)
        {
            mTextTMP.text += (counts + 1).ToString() + ". " + pair.Key + ": " + System.Math.Round(pair.Value.automoveDistanceTraveled, 2).ToString() + "\n";
            counts++;
        }
    }
}
