using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotKeys : MonoBehaviour
{

    public static bool gamePause = true;
    private GameObject[] eventButtons;
    private GameObject[] pauseUIs;
    private GameObject[] scoreDashbaords;
    private GameObject[] scoreRanking;

    // Start is called before the first frame update
    void Start()
    {
        eventButtons = GameObject.FindGameObjectsWithTag("ButtonEvents");
        pauseUIs = GameObject.FindGameObjectsWithTag("paused");
        scoreDashbaords = GameObject.FindGameObjectsWithTag("ScoreDash");
        scoreRanking = GameObject.FindGameObjectsWithTag("ScoreRanking");
        setActive(eventButtons, false);
        setActive(scoreDashbaords, false);
        setActive(scoreRanking, false);
    }

    // Update is called once per frame
    void Update()
    {
        // `P` to Pause Game
        if (Input.GetKeyDown(KeyCode.P))
        {
            toggleGamePause();
            toggleActive(pauseUIs);
        }

        // `E` to Pause Game and Open Events Menu
        if (Input.GetKeyDown(KeyCode.E))
        {
            gamePause = true;
            setActive(eventButtons);
            setActive(pauseUIs);
            setActive(scoreRanking, false);
            setActive(scoreDashbaords, false);
        }

        // `Tab` to Open Score Dashboard
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            toggleGamePause();
            toggleActive(scoreDashbaords);
            toggleActive(pauseUIs);
            setActive(scoreRanking, false);
            setActive(eventButtons, false);
        }

        // "H" to Hide Score Ranking List
        if (Input.GetKeyDown(KeyCode.H))
        {
            toggleActive(scoreRanking);
        }

        // "Escape" to Continue Game and Close All Menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePause = false;
            setActive(eventButtons, false);
            setActive(scoreDashbaords, false);
            setActive(pauseUIs, false);
            setActive(scoreRanking);
        }

    }

    public bool isPaused()
    {
        return gamePause;
    }

    private void toggleGamePause()
    {
        if (gamePause)
        {
            gamePause = false;
        }
        else
        {
            gamePause = true;
        }
    }

    private void setActive(GameObject[] tars, bool status = true)
    {
        foreach (GameObject tar in tars)
        {
            tar.SetActive(status);
        }
    }

    private void toggleActive(GameObject[] tars, bool status = true)
    {
        foreach (GameObject tar in tars)
        {
            if (tar.activeSelf)
            {
                tar.SetActive(false);
            } else
            {
                tar.SetActive(true);
            }
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
