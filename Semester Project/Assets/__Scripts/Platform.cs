using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Platform : MonoBehaviour {

    public Camera mainCamera;

    public Vector3 newRotation;

    public GameObject[] prefabEnemies;
    public float enemySpawnPerSecond = 0.5f;
    public float enemySpawnPadding = 1.5f;

    public float enemySpawnRate;

    void Awake()
    {
        Utils.SetCameraBounds(mainCamera);
        enemySpawnRate = 1f / enemySpawnPerSecond;
        Invoke("SpawnEnemy", enemySpawnRate);
    }
	
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.tag == "Hero")
        {
            other.transform.root.DORotateQuaternion(Quaternion.Euler(newRotation), 0.5f);
            //other.transform.root.rotation = Quaternion.Euler(newRotation);
        }
    }


    public void SpawnEnemy()
    {
        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate(prefabEnemies[ndx]) as GameObject;
        Vector3 pos = Vector3.zero;
        float xMin = Utils.camBounds.min.x + enemySpawnPadding;
        float xMax = Utils.camBounds.max.x - enemySpawnPadding;
        pos.x = Random.Range(xMin, xMax);
        pos.z = -1 * (Utils.camBounds.max.z + enemySpawnPadding);
        go.transform.position = pos;
        Invoke("SpawnEnemy", enemySpawnRate);
    }







}
