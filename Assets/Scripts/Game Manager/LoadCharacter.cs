using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using System.IO;
using System.Linq;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
	public Transform spawnPoint;

    private GameObject player;
    //public TMP_Text label;

    public Transform[] automoveTargets;
    private float rbMass;
    private float rbAngularDrag;
    private float automoveBaseOffset;
    private float automoveSpeed;
    private float automoveAngularSpeed;
    private float automoveAcceleration;

    private Vector3 randomUnitVector;

    void Start()
    {

        //int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        //label.text = PlayerPrefs.GetString("characterName");

        // Load Character From .csv File
        StreamReader strReader = new StreamReader("vehicleGroupData.csv");
        bool endOfFile = false;
        while (!endOfFile)
        {
            string lines = strReader.ReadLine();
            if (lines == null)
            {
                endOfFile = true;
                break;
            }
            var columns = lines.Split(",");
            string characterName = columns[0].ToString();
            int selectedCharacter = int.Parse(columns[1]);
            string[] funcList = columns[2].Split("/").Select(func => func.Trim().ToLower()).ToArray();
            initializePlayer(characterPrefabs[selectedCharacter], characterName, funcList);
        }
    }

    // Initialize Player Object from CahracterSelection characterPrefabs
    void initializePlayer(GameObject character, string characterName, string[] funcList)
	{
        carSpec carSpecification = character.GetComponent<carSpec>();
        carSpecification.groupName = characterName;
        carSpecification.functionList = funcList;

        rbMass = carSpecification.rbMass;
        rbAngularDrag = carSpecification.rbAngularDrag;
        automoveSpeed = carSpecification.automoveSpeed;
        automoveAngularSpeed = carSpecification.automoveAngularSpeed;
        automoveAcceleration = carSpecification.automoveAcceleration;
        automoveBaseOffset = carSpecification.automoveBaseOffset;

        randomUnitVector = new Vector3(Random.Range(-7f, 7f), 0, Random.Range(-1.2f, 1.2f));
        player = Instantiate(character, spawnPoint.position + 5 * randomUnitVector, spawnPoint.rotation) as GameObject;
        player.transform.localScale *= 2.5f;
        player.name = characterName;

        //MeshCollider playerMS = player.AddComponent<MeshCollider>();
        //playerMS.convex = true;
        //playerMS.isTrigger = true;

        Rigidbody playerRB = player.AddComponent<Rigidbody>();
        playerRB.mass = rbMass;
        playerRB.angularDrag = rbAngularDrag;

        UnityEngine.AI.NavMeshAgent navMeshAgent = player.AddComponent<UnityEngine.AI.NavMeshAgent>();
        navMeshAgent.baseOffset = automoveBaseOffset;
        navMeshAgent.speed = automoveSpeed;
        navMeshAgent.angularSpeed = automoveAngularSpeed;
        navMeshAgent.acceleration = automoveAcceleration;
        navMeshAgent.autoBraking = true;

        Automovement automovement = player.AddComponent<Automovement>();
        automovement.navMeshAgent = navMeshAgent;
        //automovement.speed = automoveSpeed;
        //automovement.angularSpeed = automoveAngularSpeed;
        //automovement.acceleration = automoveAcceleration;
        automovement.targets = automoveTargets;

        //GameObject freelookCamera = GameObject.Find("FreeLook Camera");
        //CinemachineFreeLook cinemachineFreeLook= freelookCamera.GetComponent<CinemachineFreeLook>();
        //cinemachineFreeLook.Follow = player.transform;
        //cinemachineFreeLook.LookAt = player.transform;
    }
}
