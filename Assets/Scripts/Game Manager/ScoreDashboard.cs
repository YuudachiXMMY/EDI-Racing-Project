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

    // Start is called before the first frame update
    void Start()
    {
        carsData = new Dictionary<string, carSpec>();
    }

    // Update is called once per frame
    void FixedUpdate()
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
        TMPro.TextMeshProUGUI mTextTMP = columns[scoredashboardIndex].GetComponent<TMPro.TextMeshProUGUI>();
        mTextTMP.text = "";
        foreach (var pair in sortedCarsData)
        {
            mTextTMP.text += generateScorboardTextFormat(counts, pair.Key, pair.Value.automoveRound, pair.Value.automoveRankedTime);
            counts++;
            if (counts % splitNum == 0)
            {
                scoredashboardIndex++;
                mTextTMP = columns[scoredashboardIndex].GetComponent<TMPro.TextMeshProUGUI>();
                mTextTMP.text = "";
            }
        }
    }

    // return String : Score Dashboard Content
    private string generateScorboardTextFormat(float count, string groupName, float round, float RankedTime)
    {
        return "(" + (count + 1).ToString() + ") " + groupName + ": ["
                + round.ToString() + "] " + System.Math.Round(RankedTime, 2).ToString() + "\n";
    }
}
