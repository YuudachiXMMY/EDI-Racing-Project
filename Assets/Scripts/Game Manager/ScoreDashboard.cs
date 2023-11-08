using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class ScoreDashboard : MonoBehaviour
{

    public GameObject[] scoredashboardColumns;
    public GameObject[] generalScoredashboardColumns;

    private Dictionary<string, carSpec> carsData;

    TMPro.TextMeshProUGUI[] compTextTMP = new TMPro.TextMeshProUGUI[2]; // TMP Array from Game Objects' Components

    // Start is called before the first frame update
    void Start()
    {
        carsData = new Dictionary<string, carSpec>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        parseCarSpec();
        updateScoreDashboard(scoredashboardColumns, 30);
        updateScoreDashboard(generalScoredashboardColumns, 40);
    }

    private void parseCarSpec()
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
        }
    }

    private void updateScoreDashboard(GameObject[] columns, int splitNum)
    {
        var sortedCarsData = carsData.OrderByDescending(pair => pair.Value.automoveRankedTime)
                                     .OrderByDescending(pair => pair.Value.automoveTargetsTotalCount);
                                    //.OrderByDescending(pair => pair.Value.automoveRound);
        int scoredashboardIndex = 0;
        int counts = 0;
        TMPro.TextMeshProUGUI[] mTextTMP = new TMPro.TextMeshProUGUI[2]; // Temporary TMP Array

        // Initializing
        compTextTMP[0] = columns[0].GetComponent<TMPro.TextMeshProUGUI>();
        compTextTMP[1] = columns[1].GetComponent<TMPro.TextMeshProUGUI>();
        mTextTMP[0] = new TMPro.TextMeshProUGUI();
        mTextTMP[1] = new TMPro.TextMeshProUGUI();

        foreach (var pair in sortedCarsData)
        {
            mTextTMP[scoredashboardIndex].text += generateScorboardTextFormat(counts, pair.Key, pair.Value.automoveRound, pair.Value.automoveRankedTime);
            counts++;
            if (counts % (sortedCarsData.Count() / 2) == 0)
            {
                scoredashboardIndex++;
            }
        }

        // Updating Game Objects' TMP Components
        compTextTMP[0].text = mTextTMP[0].text;
        compTextTMP[1].text = mTextTMP[1].text;
    }

    // return String : Score Dashboard Content
    private string generateScorboardTextFormat(float count, string groupName, float round, float RankedTime)
    {
        return "(" + (count + 1).ToString() + ") " + groupName + ": ["
                + round.ToString() + "] " + System.Math.Round(RankedTime, 2).ToString() + "\n";
    }
}
