using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIFacingPlayer : MonoBehaviour
{

    private GameObject _object;

    // Start is called before the first frame update
    void Start()
    {
        _object = GameObject.Find("InstructorPlayer");

        string groupName = this.transform.parent.gameObject.GetComponent<carSpec>().groupName;
        this.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = Left(groupName, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _object.transform.position);
    }

    private string Left(string str, int length)
    {
        return str.Substring(0, System.Math.Min(length, str.Length));
    }

}
