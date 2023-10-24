using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotKeys : MonoBehaviour
{

    public static bool gamePause = true;
    private GameObject[] eventButtons;
    private GameObject[] pauseUIs;
    private GameObject[] scoreDashbaords;
    private GameObject[] scoreRankingTop10;

    // Start is called before the first frame update
    void Start()
    {
        eventButtons = GameObject.FindGameObjectsWithTag("ButtonEvents");
        pauseUIs = GameObject.FindGameObjectsWithTag("paused");
        scoreDashbaords = GameObject.FindGameObjectsWithTag("ScoreDash");
        scoreRankingTop10 = GameObject.FindGameObjectsWithTag("ScoreRankingTop10");
        setActive(eventButtons, false);
        setActive(scoreDashbaords, false);
        setActive(scoreRankingTop10, false);
    }

    // Update is called once per frame
    void Update()
    {
            // `P` to Pause Game
            if (Input.GetKeyDown(KeyCode.P))
            {
                gamePause = true;
                setActive(pauseUIs);
            }

            // `E` to Pause Game and Open Events Menu
            if (Input.GetKeyDown(KeyCode.E))
            {
                gamePause = true;
                setActive(eventButtons);
                setActive(pauseUIs);
                setActive(scoreRankingTop10, false);
                setActive(scoreDashbaords, false);
            }

            // `Tab` to Open Score Dashboard
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                gamePause = true;
                setActive(scoreDashbaords);
                setActive(pauseUIs);
                setActive(scoreRankingTop10, false);
                setActive(eventButtons, false);
            }
        
        

        // "Escape" to Continue Game and Close All Menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePause = false;
            setActive(eventButtons, false);
            setActive(scoreDashbaords, false);
            setActive(pauseUIs, false);
            setActive(scoreRankingTop10);
        }

    }

    void setActive(GameObject[] buttons, bool status = true)
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(status);
        }
    }

    void LateUpdate()
    {
        if (gamePause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
