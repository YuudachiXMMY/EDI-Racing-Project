using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;

    public TMP_Text warningMessage;
    private string groupName = null;

    private float timer = 0.0f;
    private float curTime = 0.0f;
    private float waitTime = 2.0f;

    public Dictionary<string, bool> functionList;
    public int functionSize;

    // Character Selections

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
    }

    public void ReadStringInput(string input)
    {
        groupName = input;
    }

    // Function Selections

    void Awake()
    {
        functionList = new Dictionary<string, bool>();
        functionList.Add("FacialRecognition", false);
        functionList.Add("VoiceAssistant", false);
        functionList.Add("AutomaticEmergencyResponseSystem", false);
        functionList.Add("FingerprintDetection", false);
        functionList.Add("Anti-TheftSystem", false);
        functionList.Add("PedestrianDetection", false);
    }

    public void toggleFunction(string functionName)
    {
        if (!functionList[functionName] && functionSize < 4)
        {
            functionList[functionName] = true;
            functionSize++;
        }
        else
        {
            functionList[functionName] = false;
            functionSize--;
        }
        //if (functionSize < 3)
        //{
        //    enableUnselectedToggle();
        //}
        //else
        //{
        //    disableUnselectedToggle();
        //}
        Debug.Log(functionList[functionName]);
        Debug.Log(functionSize);
    }

    static void disableUnselectedToggle()
    {
        setInteractableOfUnselectedToggle(false);
    }

    static void enableUnselectedToggle()
    {
        setInteractableOfUnselectedToggle(true);
    }

    static void setInteractableOfUnselectedToggle(bool status)
    {
        //GameObject[] children = GameObject.FindGameObjectsWithTag("FunctionToggle");
        //Debug.Log(children);
        //Debug.Log(children==null);
        //foreach (GameObject child in children)
        //{
        //    if (!child.GetComponent<UnityEngine.UI.Toggle>().isOn)
        //    {
        //        child.GetComponent<UnityEngine.UI.Toggle>().interactable = status;
        //    }
        //}
    }

    // Error Message

    public void StartGame()
	{
        if (!string.IsNullOrEmpty(groupName))
        {
            PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
            PlayerPrefs.SetString("characterName", groupName);

            SceneManager.LoadScene("Map-2", LoadSceneMode.Single);
        } else
        {
            ShowWarningMessage("Please Enter Your Group Name");
        }
    }

    void ShowWarningMessage(string message)
    {
        warningMessage.text = message;
        curTime = timer;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > curTime + waitTime)
        {
            warningMessage.text = "";
        }
    }
}
