using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public GameObject[] powerUpPrefabs;
    public float startDelay = 0;
    public float spawnRate = 6;
    private int spawnRange = 18;
    private float topSpawnRange = 4.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnPowerUp", startDelay, spawnRate);
        Debug.Log("hi");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnPowerUp()
    {
        int powerUpIndex = Random.Range(0, powerUpPrefabs.Length);
        int locationSet = Random.Range(1, 5);
        Debug.Log(locationSet);
        if (locationSet != 4)
        {
            Instantiate(powerUpPrefabs[powerUpIndex], new Vector3(Random.Range(spawnRange, -spawnRange), 1.04f, Random.Range(spawnRange, -spawnRange)), powerUpPrefabs[powerUpIndex].transform.rotation);
        } else if (locationSet == 4)
        {
            Instantiate(powerUpPrefabs[powerUpIndex], new Vector3(Random.Range(topSpawnRange, -topSpawnRange), 6.1f, Random.Range(topSpawnRange, -topSpawnRange)), powerUpPrefabs[powerUpIndex].transform.rotation);
        }
    }
}
