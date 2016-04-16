using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PowerUpSpawnDefinition
{
    public WeaponType type;
    public int spawnProbability;
}

public class Main : MonoBehaviour
{
    static public Main S;
	static public Dictionary<WeaponType,WeaponDefinition> W_DEFS;

    public GameObject[] prefabEnemies;
    public float enemySpawnPerSecond = 0.5f;
    public float enemySpawnPadding = 1.5f;
	public WeaponDefinition[] weaponDefinitions;

    static public Dictionary<WeaponType, int> powerUpDict;
    public PowerUpSpawnDefinition[] powerUpFrequency;

    public GameObject powerUpPrefab;

    public bool ____________;

	public WeaponType[] activeWeaponTypes;
    public float enemySpawnRate;

    void Awake()
    {
        S = this;
        Utils.SetCameraBounds(this.GetComponent<Camera>());
        enemySpawnRate = 1f / enemySpawnPerSecond;
        //Invoke("SpawnEnemy", enemySpawnRate);

		W_DEFS = new Dictionary<WeaponType,WeaponDefinition> ();
        powerUpDict = new Dictionary<WeaponType, int>();

        foreach (WeaponDefinition def in weaponDefinitions) 
			W_DEFS [def.type] = def;

        foreach (PowerUpSpawnDefinition powerUp in powerUpFrequency)
            powerUpDict.Add(powerUp.type, powerUp.spawnProbability);
    }

	static public WeaponDefinition GetWeaponDefinition(WeaponType wt){
		if (W_DEFS.ContainsKey(wt))
			return (W_DEFS[wt]);
		return(new WeaponDefinition());
	}

	void Start(){
		activeWeaponTypes = new WeaponType[weaponDefinitions.Length];
		for (int i = 0; i < weaponDefinitions.Length; i++) {
			activeWeaponTypes [i] = weaponDefinitions [i].type;
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
        pos.z = -1*(Utils.camBounds.max.z + enemySpawnPadding);
        //pos.y = Utils.camBounds.max.y + enemySpawnPadding;
        go.transform.position = pos;
        Invoke("SpawnEnemy", enemySpawnRate);
    }

    public void ShipDestroyed(float powerUpDropChance, Vector3 enemyPosition)
    {
        if (Random.value <= powerUpDropChance)
        {

            WeaponType weaponType = WeightedRandomizer.From(powerUpDict).TakeOne();

            GameObject clone = Instantiate(powerUpPrefab) as GameObject;

            PowerUp powerUp = clone.GetComponent<PowerUp>();
            powerUp.SetType(weaponType);

            powerUp.transform.position = enemyPosition;

            //int ndx = Random.Range(0, powerUpFrequency.Length);
            //WeaponType puType = powerUpFrequency[ndx];

            // GameObject go = Instantiate(prefabPowerUp) as GameObject;
            //PowerUp pu = go.GetComponent<PowerUp>();
            //pu.SetType(puType);

            // pu.transform.position = enemyPosition;

        }
    }



}