using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    private Vector3 initialPosition = new Vector3(0, 1, 0); //(-138, 21.5f, 30);
    private Vector3 initialScale = new Vector3(1, 1, 1);
    private Quaternion initialRotation = new Quaternion(0, 0, 0, 0);

    public GameObject[] roadPrefabs;
    public int roadLength;
    private Vector3 initialRoadScale = new Vector3(10, 10, 10);

    // Start is called before the first frame update
    void Start()
    {
        int playerIndex = Random.Range(0, playerPrefabs.Length);
        GameObject player = Instantiate(playerPrefabs[playerIndex], initialPosition, initialRotation) as GameObject;
        player.transform.localScale = initialScale;

        for (int i = 0; i < roadLength; i++)
        {
            int roadIndex = Random.Range(0, roadPrefabs.Length);
            Vector3 spawnPos = new Vector3(0, 0, 0);
            GameObject initialRoad = Instantiate(roadPrefabs[roadIndex], spawnPos, roadPrefabs[roadIndex].transform.rotation);
            initialRoad.transform.localScale = initialRoadScale;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
