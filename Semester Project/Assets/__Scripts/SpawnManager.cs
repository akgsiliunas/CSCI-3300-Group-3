using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SpawnerDefinition
{
    public GameObject spawnerPrefab;
    public int spawnProbability;
}

[System.Serializable]
public class BossDefinition
{
    public GameObject bossPrefab;
    public int spawnProbability;
}

public class SpawnManager : MonoBehaviour {

    static public Dictionary<GameObject, int> enemyDict;
    public EnemySpawnDefinition[] enemyList;

    static public Dictionary<GameObject, int> spawnerDict;
    public SpawnerDefinition[] spawnerList;

    static public Dictionary<GameObject, int> bossDict;
    public BossDefinition[] bossList;

    // Stage variables
    private bool normalSpawning = true;
    private bool waveSpawning = false;
    private bool bossSpawning = false;

    // Time Change Variables
    private float timeChange = 0f;
    private float normalTimeChange = 0f;
    private float waveTimeChange = 0f;

    // Spawn Rates
    private float normalSpawnRate = 4f;
    private float waveSpawnRate = 2f;

    // Stage Lifespans
    private float waveCountDown = 5f;
    private float waveLifeSpan = 2.5f;
    private float bossLifeSpan = 5f;

    // Randomized Spawner Variables
    private bool spawnerSelection = false;
    private GameObject firstSelectedSpawner;
    private GameObject secondSelectedSpawner;

    // Boss Spawning Variables
    private bool bossSpawned = false;
    private int wormCount = 4;
    private int rookCount = 8;


    void Awake()
    {

        enemyDict = new Dictionary<GameObject, int>();
        spawnerDict = new Dictionary<GameObject, int>();
        bossDict = new Dictionary<GameObject, int>();

        foreach (EnemySpawnDefinition enemy in enemyList)
            enemyDict.Add(enemy.enemyPrefab, enemy.spawnProbability);

        foreach (SpawnerDefinition spawner in spawnerList)
            spawnerDict.Add(spawner.spawnerPrefab, spawner.spawnProbability);

        foreach (BossDefinition boss in bossList)
            bossDict.Add(boss.bossPrefab, boss.spawnProbability);
    }

    void Update()
    {
        // Stage Switch Timer
        Pacing();

        if (normalSpawning == true)
            Normal();
        else if (waveSpawning == true)
            Wave();
        else if (bossSpawning == true)
            Boss();
    }


    public void Pacing()
    {
        if (normalSpawning == true && waveSpawning == false && bossSpawning == false)
        {
            if (timeChange > waveCountDown)
            {
                timeChange = 0f;
                normalSpawning = false;
                waveSpawning = true;
                bossSpawning = false;
            }
            else
                timeChange += Time.deltaTime;
        }
        else if (normalSpawning == false && waveSpawning == true && bossSpawning == false)
        {
            if (timeChange > waveLifeSpan)
            {
                timeChange = 0f;
                normalSpawning = false;
                waveSpawning = false;
                bossSpawning = true;
            }
            else
                timeChange += Time.deltaTime;
        }
        else if (normalSpawning == false && waveSpawning == false && bossSpawning == true)
        {
            if (timeChange > bossLifeSpan)
            {
                timeChange = 0f;
                normalSpawning = true;
                waveSpawning = false;
                bossSpawning = false;
                bossSpawned = false;
            }
            else
                timeChange += Time.deltaTime;
        }
    }

    public void Normal()
    {
        if (normalTimeChange > normalSpawnRate)
        {
            normalTimeChange = 0f;
            Spawn(WeightedRandomizer.From(enemyDict).TakeOne(), WeightedRandomizer.From(spawnerDict).TakeOne());
        }
        else
            normalTimeChange += Time.deltaTime;
    }

    public void Wave()
    {
        if (spawnerSelection == false)
        {
            firstSelectedSpawner = WeightedRandomizer.From(spawnerDict).TakeOne();
            secondSelectedSpawner = WeightedRandomizer.From(spawnerDict).TakeOne();
            spawnerSelection = true;
        }

        if (waveTimeChange > waveSpawnRate)
        {
            waveTimeChange = 0f;

            if (Random.Range(0f, 1f) < 0.5f)
                Spawn(WeightedRandomizer.From(enemyDict).TakeOne(), firstSelectedSpawner);
            else
                Spawn(WeightedRandomizer.From(enemyDict).TakeOne(), secondSelectedSpawner);
        }
        else
            waveTimeChange += Time.deltaTime;
    }

    public void Boss()
    {
        if (bossSpawned == false)
        {
            GameObject boss = WeightedRandomizer.From(bossDict).TakeOne();
            Debug.Log(boss.name);

            if (boss.name == "Virus Boss")
            {
                firstSelectedSpawner = WeightedRandomizer.From(spawnerDict).TakeOne();
                Spawn(boss, firstSelectedSpawner);
            }
            else if (boss.name == "Worm 6")
            {
                for (int i = 0; i < wormCount; i++)
                    Spawn(boss, WeightedRandomizer.From(spawnerDict).TakeOne());
            }
            else if (boss.name == "Rook")
            {
                for (int i = 0; i < rookCount; i++)
                    Spawn(boss, WeightedRandomizer.From(spawnerDict).TakeOne());
            }
            bossSpawned = true;
        }
    }

    public void Spawn(GameObject enemyPrefab, GameObject spawner)
    {
        GameObject enemy = Instantiate(enemyPrefab);

        Vector3 pos = Vector3.zero;

        if (spawner.GetComponent<Spawner>().orientation == Spawner.Orientation.Left || spawner.GetComponent<Spawner>().orientation == Spawner.Orientation.Right)
        {
            float zMax = spawner.GetComponent<Renderer>().bounds.extents.z;
            float zMin = -spawner.GetComponent<Renderer>().bounds.extents.z;

            pos.z = Random.Range(zMax, zMin);

            pos.x = (spawner.GetComponent<Renderer>().bounds.center.x);

            if (spawner.GetComponent<Spawner>().orientation == Spawner.Orientation.Left)
                enemy.GetComponent<Enemy>().movement = Enemy.Movement.Left;
            else
                enemy.GetComponent<Enemy>().movement = Enemy.Movement.Right;
        }
        else
        {
            float xMax = spawner.GetComponent<Renderer>().bounds.extents.x;
            float xMin = -spawner.GetComponent<Renderer>().bounds.extents.x;

            pos.x = Random.Range(xMax, xMin);

            pos.z = (spawner.GetComponent<Renderer>().bounds.center.z);

            if (spawner.GetComponent<Spawner>().orientation == Spawner.Orientation.Top)
                enemy.GetComponent<Enemy>().movement = Enemy.Movement.Top;
            else
                enemy.GetComponent<Enemy>().movement = Enemy.Movement.Bottom;
        }

        enemy.transform.position = pos;
    }
}
