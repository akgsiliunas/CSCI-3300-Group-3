using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewSpawner : MonoBehaviour {

    static public Dictionary<GameObject, int> weights;

    static public Dictionary<GameObject, int> spawners;
    public GameObject[] spawnerList;

    static public Dictionary<EnemyType, EnemySpawnDefinition> E_DEFS;
    public EnemySpawnDefinition[] enemyDefinitions;

    public enum Orientation { Left, Right, Top, Bottom }
    public Orientation orientation;


    public float normalSpawnRate = 10f;
    public float timeChange = 0f;

    void Awake () {

        weights = new Dictionary<GameObject, int>();
        spawners = new Dictionary<GameObject, int>();
        E_DEFS = new Dictionary<EnemyType, EnemySpawnDefinition>();

        foreach (GameObject spawner in spawnerList)
            spawners.Add(spawner, 25);

        foreach (EnemySpawnDefinition def in enemyDefinitions)
        {
            E_DEFS[def.type] = def;
            weights.Add(def.enemyPrefab, def.spawnProbability);
        }

    }

    static public EnemySpawnDefinition GetEnemyDefinition(EnemyType wt)
    {
        if (E_DEFS.ContainsKey(wt))
            return (E_DEFS[wt]);
        return (new EnemySpawnDefinition());
    }


    void Update()
    {
        if (timeChange > normalSpawnRate)
        {
            timeChange = 0f;
            NormalSpawn(WeightedRandomizer.From(weights).TakeOne(), WeightedRandomizer.From(spawners).TakeOne());
        }
        else
            timeChange += Time.deltaTime;

    }


    public void NormalSpawn(GameObject enemyPrefab, GameObject spawner)
    {
        //  int ndx = Random.Range(0, prefabEnemies.Length);
        //  GameObject go = Instantiate(prefabEnemies[ndx]) as GameObject;
        // Vector3 pos = Vector3.zero;

        // if (enemy == null)
        //    Debug.LogWarning("kkk");
        // Debug.LogWarning(enemyPrefab.name);
        GameObject enemy = Instantiate(enemyPrefab);

        Vector3 pos = Vector3.zero;

        if (orientation == Orientation.Left || orientation == Orientation.Right)
        {
            float zMax = spawner.GetComponent<Renderer>().bounds.extents.z;
            float zMin = -spawner.GetComponent<Renderer>().bounds.extents.z;

            pos.z = Random.Range(zMax, zMin);

            pos.x = (spawner.GetComponent<Renderer>().bounds.center.x);

            if (orientation == Orientation.Left)
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

            if (orientation == Orientation.Top)
                enemy.GetComponent<Enemy>().movement = Enemy.Movement.Top;
            else
                enemy.GetComponent<Enemy>().movement = Enemy.Movement.Bottom;
        }

        enemy.transform.position = pos;
    }



}
