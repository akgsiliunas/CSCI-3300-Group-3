using UnityEngine;
using System.Collections;

public class Platform_North : Platform {

    public override void SpawnEnemy()
    {
        Debug.Log(spawner.GetComponent<Renderer>().bounds.extents);


        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate(prefabEnemies[ndx]) as GameObject;
        Vector3 pos = Vector3.zero;


        float xMax = spawner.GetComponent<Renderer>().bounds.extents.x;
        float xMin = -spawner.GetComponent<Renderer>().bounds.extents.x;

        pos.x = Random.Range(xMax, xMin);

        pos.z = (spawner.GetComponent<Renderer>().bounds.center.z);

        go.transform.position = pos;
        Invoke("SpawnEnemy", enemySpawnRate);
    }





}
