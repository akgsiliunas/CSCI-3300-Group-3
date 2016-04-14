using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SpawnerDefinition
{
    public GameObject spawnerPrefab;
    public int spawnProbability;
}

public class NewSpawner : MonoBehaviour {

    static public Dictionary<GameObject, int> enemyDict;
    public EnemySpawnDefinition[] enemyList;

    static public Dictionary<GameObject, int> spawnerDict;
    public SpawnerDefinition[] spawnerList;

    //public enum Orientation { Left, Right, Top, Bottom }
    //public Orientation orientation;

    public float normalSpawnRate = 10f;
    public float normalTimeChange = 0f;

    private bool normalSpawning = false;

    private float waveSpawnRate = 2f;
    public float waveTimeChange = 0f;

    private bool waveSpawning = true;

    public bool spawnerSelection = false;

    public GameObject firstSelectedSpawner;
    public GameObject secondSelectedSpawner;

    void Awake () {

        enemyDict = new Dictionary<GameObject, int>();
        spawnerDict = new Dictionary<GameObject, int>();

        foreach (SpawnerDefinition spawner in spawnerList)
            spawnerDict.Add(spawner.spawnerPrefab, spawner.spawnProbability);

        foreach (EnemySpawnDefinition enemy in enemyList)
            enemyDict.Add(enemy.enemyPrefab, enemy.spawnProbability);
    }



    public void Normal()
    {
        if (normalTimeChange > normalSpawnRate)
        {
            normalTimeChange = 0f;
            NormalSpawn(WeightedRandomizer.From(enemyDict).TakeOne(), WeightedRandomizer.From(spawnerDict).TakeOne());
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

            if (Random.Range(0f, 1f)  < 0.5f)
                NormalSpawn(WeightedRandomizer.From(enemyDict).TakeOne(), firstSelectedSpawner);
            else
                NormalSpawn(WeightedRandomizer.From(enemyDict).TakeOne(), secondSelectedSpawner);
        }
        else
            waveTimeChange += Time.deltaTime;
    }


    void Update()
    {
        if (normalSpawning == true)
            Normal();

        else if (waveSpawning == true)
            Wave();
    }


    public void NormalSpawn(GameObject enemyPrefab, GameObject spawner)
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
