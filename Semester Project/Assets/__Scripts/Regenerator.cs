using UnityEngine;
using System.Collections;

public class Regenerator : MonoBehaviour {


    // Shield Regeneration Variables
    public float regenTime = 1f;
    public int regenAmount = 1;
    private float timeChange = 0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other)
    {
        if (other.transform.root.tag == "Hero")
            RegenShield(other);
    }

    public void RegenShield(Collider hero)
    {
        if (timeChange > regenTime)
        {
            timeChange = 0f;
            hero.transform.root.GetComponent<Player>().AddShieldLevel(regenAmount);
        }
        else
            timeChange += Time.deltaTime;
    }

}
