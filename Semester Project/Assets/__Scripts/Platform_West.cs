using UnityEngine;
using System.Collections;

public class Platform_West : Platform {

    public override void SpawnEnemy()
    {
        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate(prefabEnemies[ndx]) as GameObject;
        Vector3 pos = Vector3.zero;

        float zMax = spawner.GetComponent<Renderer>().bounds.extents.z;
        float zMin = -spawner.GetComponent<Renderer>().bounds.extents.z;

        pos.z = Random.Range(zMax, zMin);

        pos.x = (spawner.GetComponent<Renderer>().bounds.center.x);

        go.transform.position = pos;
        Invoke("SpawnEnemy", enemySpawnRate);
    }
}
