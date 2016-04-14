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
    public float timeChange = 0f;

    void Awake () {

        enemyDict = new Dictionary<GameObject, int>();
        spawnerDict = new Dictionary<GameObject, int>();

        foreach (SpawnerDefinition spawner in spawnerList)
            spawnerDict.Add(spawner.spawnerPrefab, spawner.spawnProbability);

        foreach (EnemySpawnDefinition enemy in enemyList)
            enemyDict.Add(enemy.enemyPrefab, enemy.spawnProbability);
    }


    void Update()
    {
        if (timeChange > normalSpawnRate)
        {
            timeChange = 0f;
            NormalSpawn(WeightedRandomizer.From(enemyDict).TakeOne(), WeightedRandomizer.From(spawnerDict).TakeOne());
        }
        else
            timeChange += Time.deltaTime;

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
