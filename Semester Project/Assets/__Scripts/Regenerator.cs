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
            //hero.transform.root.GetComponent<Player>().AddShieldLevel(regenAmount);
			if (hero.transform.root.GetComponent<Hero_1>())
			{
				hero.transform.root.GetComponent<Hero_1>().AddShieldLevel(regenAmount);
				Hero1Manager.H1.addHealth((float)regenAmount);
			}
			
			if (hero.transform.root.GetComponent<Hero_2>())
			{
				hero.transform.root.GetComponent<Hero_2>().AddShieldLevel(regenAmount);
			  	Hero2Manager.H2.addHealth((float)regenAmount);
			}
			
			if (hero.transform.root.GetComponent<Hero_3>())
			{
				hero.transform.root.GetComponent<Hero_3>().AddShieldLevel(regenAmount);
			  	Hero3Manager.H3.addHealth((float)regenAmount);
			}
			
			if (hero.transform.root.GetComponent<Hero_4>())
			{
				hero.transform.root.GetComponent<Hero_4>().AddShieldLevel(regenAmount);
			  	Hero4Manager.H4.addHealth((float)regenAmount);
			}
        }
        else
            timeChange += Time.deltaTime;
    }

}
