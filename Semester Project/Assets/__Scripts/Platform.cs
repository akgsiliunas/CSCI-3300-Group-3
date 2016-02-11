using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Platform : MonoBehaviour {

    public Vector3 newRotation;

    public GameObject spawner;

    public GameObject[] prefabEnemies;
    public float enemySpawnPerSecond = 0.5f;
    public float enemySpawnPadding = 1.5f;

    public float enemySpawnRate;

    void Awake()
    {
        Debug.Log(spawner.GetComponent<Renderer>().bounds.center);

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


    public virtual void SpawnEnemy()
    {
        // Spawn Stuff
    }







}
