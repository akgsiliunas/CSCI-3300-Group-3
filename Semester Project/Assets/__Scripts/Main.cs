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

	public WeaponDefinition[] weaponDefinitions;

    static public Dictionary<WeaponType, int> powerUpDict;
    public PowerUpSpawnDefinition[] powerUpFrequency;

    public GameObject powerUpPrefab;

	public WeaponType[] activeWeaponTypes;

    void Awake()
    {
        S = this;
        Utils.SetCameraBounds(this.GetComponent<Camera>());

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

    public void ShipDestroyed(float powerUpDropChance, Vector3 enemyPosition)
    {
        if (Random.value <= powerUpDropChance)
        {

            WeaponType weaponType = WeightedRandomizer.From(powerUpDict).TakeOne();

            GameObject clone = Instantiate(powerUpPrefab) as GameObject;

            PowerUp powerUp = clone.GetComponent<PowerUp>();
            powerUp.SetType(weaponType);

            powerUp.transform.position = enemyPosition;
        }
    }



}