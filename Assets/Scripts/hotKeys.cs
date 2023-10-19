using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotKeys : MonoBehaviour
{

    private bool gamePause = true;
    private GameObject[] eventButtons;

    // Start is called before the first frame update
    void Start()
    {
        eventButtons = GameObject.FindGameObjectsWithTag("ButtonEvents");
    }

    // Update is called once per frame
    void Update()
    {
        // Tab to Pause Game
        if (!gamePause && Input.GetKeyDown(KeyCode.Tab))
        {
            gamePause = true;
        }

        // "E" to Pause Game and Open Events Menu
        if (!gamePause && Input.GetKeyDown(KeyCode.E))
        {
            gamePause = true;
            foreach (GameObject eventButton in eventButtons)
            {
                eventButton.SetActive(true);
            }
        }

        // "Escape" to Continue Game and Close All Menu
        if (gamePause && Input.GetKeyDown(KeyCode.Escape))
        {
            gamePause = false;
            foreach (GameObject eventButton in eventButtons)
            {
                eventButton.SetActive(false);
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
