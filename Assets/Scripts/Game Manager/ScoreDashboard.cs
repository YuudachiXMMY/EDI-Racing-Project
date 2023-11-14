using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

public class ScoreDashboard : MonoBehaviour
{

    public GameObject[] scoredashboardColumns;
    public GameObject[] generalScoredashboardColumns;

    private Dictionary<string, carSpec> carsData;

    private int scoredashboardIndexMax = 4;
    TMPro.TextMeshProUGUI[] compTextTMP; // TMP Array from Game Objects' Components

    // Start is called before the first frame update
    void Start()
    {
        carsData = new Dictionary<string, carSpec>();
        compTextTMP = new TMPro.TextMeshProUGUI[scoredashboardIndexMax];
        parseCarSpec();
    }

    // Update is called once per frame
    void LateUpdate()
    {
    }

    public void updateCarSpec(carSpec carSpec)
    {
        carsData[carSpec.groupName] = carSpec;
        updateScoreDash();
    }

    private void updateScoreDash()
    {
        updateScoreDashboard(scoredashboardColumns, 20, true);
        updateScoreDashboard(generalScoredashboardColumns, 30);
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

    private void updateScoreDashboard(GameObject[] columns, int splitNum, bool scoreDash = false)
    {
        var sortedCarsData = carsData.OrderByDescending(pair => pair.Value.automoveTargetsTotalCount)
                                      .ThenByDescending(pair => pair.Value.automoveRankedTime);
                                    //.OrderByDescending(pair => pair.Value.automoveRound);
        int scoredashboardIndex = 0;
        int counts = 0;

        // Initializing
        string[] mTextTMP = new string[scoredashboardIndexMax]; // Temporary TMP Array
        for (int i = 0; i < scoredashboardIndexMax; i++)
        {
            mTextTMP[i] = "";
            compTextTMP[i] = columns[i].GetComponent<TMPro.TextMeshProUGUI>();
        }

        foreach (var pair in sortedCarsData)
        {
            mTextTMP[scoredashboardIndex] += generateScorboardTextFormat(counts, pair.Key, pair.Value.automoveRound, pair.Value.automoveRankedTime, scoreDash);
            counts++;
            if ( counts % splitNum == 0)
            {
                scoredashboardIndex++;
            }
        }

        //Updating Game Objects' TMP Components
        for (int i = 0; i < scoredashboardIndexMax; i++)
        {
            compTextTMP[i].text = mTextTMP[i];
        }
    }

    // return String : Score Dashboard Content
    private string generateScorboardTextFormat(float count, string groupName, float round, float RankedTime, bool scoreDash)
    {
        string res = "(" + (count + 1).ToString() + ") " + "[" + round.ToString() + "] " + groupName;
        if (scoreDash)
        {
            res += " - " + System.Math.Round(RankedTime, 2).ToString();
        }
        return res + "\n";
    }
}
