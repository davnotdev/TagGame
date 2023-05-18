using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public BoxCollider ground;

    public GameObject[] powerUpPrefabs;
    public float startDelay = 0;
    public float spawnRate = 6;
    private int spawnRange = 18;
    private float topSpawnRange = 4.5f;

    //public GameObject timerText;
    public TextMeshProUGUI TextTimerUI;
    //this is hell
    public float timer = 30;
    public int timerDisplay;

    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        if (MenuManager.inst)
        {
            timer = MenuManager.inst.beginTime;
        }
        else
        {
            timer = 5.0f;
        }

        List<GameObject> taggables = new List<GameObject>();
        var tagManager = TagManager.GetTagManager();

        taggables.Add(player);

        Vector3[] enemySpawnPositions = {
            ground.center + new Vector3( ground.size.x, 0.0f,  ground.size.z),
            ground.center + new Vector3(-ground.size.x, 0.0f,  ground.size.z),
            ground.center + new Vector3( ground.size.x, 0.0f, -ground.size.z),
        };

        foreach (var enemySpawn in enemySpawnPositions)
        {
            var taggable = Instantiate(enemy, enemySpawn, Quaternion.identity);
            taggables.Add(taggable);
        }

        tagManager.Begin();

        int randomTag = Random.Range(0, taggables.Count);
        taggables[randomTag].GetComponent<Taggable>().TagYouAreIt(null);

        InvokeRepeating("spawnPowerUp", startDelay, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnPowerUp()
    {
        int powerUpIndex = Random.Range(0, powerUpPrefabs.Length);
        int locationSet = Random.Range(1, 5);
        if (locationSet != 4)
        {
            Instantiate(powerUpPrefabs[powerUpIndex], new Vector3(Random.Range(spawnRange, -spawnRange), 1.04f, Random.Range(spawnRange, -spawnRange)), powerUpPrefabs[powerUpIndex].transform.rotation);
        }
        else if (locationSet == 4)
        {
            Instantiate(powerUpPrefabs[powerUpIndex], new Vector3(Random.Range(topSpawnRange, -topSpawnRange), 6.1f, Random.Range(topSpawnRange, -topSpawnRange)), powerUpPrefabs[powerUpIndex].transform.rotation);
        }
    }

    //timer ahhh
    private void FixedUpdate()
    {
        if (!isGameOver)
        {
            timer -= (Time.deltaTime);
            timerDisplay = Mathf.RoundToInt(timer);
            TryEndGame();
        }
        TextTimerUI.text = timerDisplay.ToString();
    }

    public void TryEndGame()
    {
        if (timerDisplay <= 0.0f)
        {
            timer = 0;
            isGameOver = true;
        }
    }
}
