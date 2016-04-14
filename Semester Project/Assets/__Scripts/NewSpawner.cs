using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewSpawner : MonoBehaviour {

    static public Dictionary<GameObject, float> weights;

    static public Dictionary<EnemyType, EnemySpawnDefinition> E_DEFS;
    public EnemySpawnDefinition[] enemyDefinitions;

    void Awake () {

        weights = new Dictionary<GameObject, float>();
        E_DEFS = new Dictionary<EnemyType, EnemySpawnDefinition>();

        foreach (EnemySpawnDefinition def in enemyDefinitions)
        {
            E_DEFS[def.type] = def;
            weights.Add(def.enemyPrefab, def.spawnProbability);
        }

        //GameObject selected = WeightedRandomizer.From(weights).TakeOne();
    }

    static public EnemySpawnDefinition GetEnemyDefinition(EnemyType wt)
    {
        if (E_DEFS.ContainsKey(wt))
            return (E_DEFS[wt]);
        return (new EnemySpawnDefinition());
    }



}
