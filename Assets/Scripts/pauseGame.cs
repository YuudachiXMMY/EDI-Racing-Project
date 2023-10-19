using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseGame : MonoBehaviour
{

    private bool gamePause = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gamePause && Input.GetKeyDown(KeyCode.Tab))
        {
            gamePause = true;
        }else if (gamePause && Input.GetKeyDown(KeyCode.Tab))
        {
            gamePause = false;
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
