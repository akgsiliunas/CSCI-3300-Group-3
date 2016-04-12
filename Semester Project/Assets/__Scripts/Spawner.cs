using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject spawnBox;

    public GameObject[] prefabEnemies;
    public float enemySpawnPerSecond = 0.5f;
    public float enemySpawnPadding = 1.5f;

    public float enemySpawnRate;

    public enum Orientation { Left, Right, Top, Bottom }

    public Orientation orientation;

    void Awake()
    {
       // enemySpawnRate = 1f / enemySpawnPerSecond;
        Invoke("SpawnEnemy", enemySpawnRate);
        Debug.Log(enemySpawnRate);
    }

    public void SpawnEnemy()
    {
        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate(prefabEnemies[ndx]) as GameObject;
        Vector3 pos = Vector3.zero;

        if( orientation == Orientation.Left || orientation == Orientation.Right)
        {
            float zMax = spawnBox.GetComponent<Renderer>().bounds.extents.z;
            float zMin = -spawnBox.GetComponent<Renderer>().bounds.extents.z;

            pos.z = Random.Range(zMax, zMin);

            pos.x = (spawnBox.GetComponent<Renderer>().bounds.center.x);

            if (orientation == Orientation.Left)
                go.GetComponent<Enemy>().movement = Enemy.Movement.Left;
            else
                go.GetComponent<Enemy>().movement = Enemy.Movement.Right;
        }

        else
        {

            float xMax = spawnBox.GetComponent<Renderer>().bounds.extents.x;
            float xMin = -spawnBox.GetComponent<Renderer>().bounds.extents.x;

            pos.x = Random.Range(xMax, xMin);

            pos.z = (spawnBox.GetComponent<Renderer>().bounds.center.z);
            
            if (orientation == Orientation.Top)
                go.GetComponent<Enemy>().movement = Enemy.Movement.Top;
            else
                go.GetComponent<Enemy>().movement = Enemy.Movement.Bottom;
        }

        go.transform.position = pos;
        Invoke("SpawnEnemy", enemySpawnRate);
    }

}
