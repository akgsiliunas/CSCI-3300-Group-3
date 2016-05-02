using UnityEngine;
using System.Collections;

public class Hero3Manager : MonoBehaviour
{
	public static Hero3Manager H3;
	
	public static int globalHero3Health;
	
	[SerializeField]
	private Stat globalHero3Stat;
	
	public void manageHealth(float health)
	{
		globalHero3Health = (int)health;
		globalHero3Stat.CurrentVal = globalHero3Health;
	}
	
	public void addHealth(float addHealth)
	{
		globalHero3Health += (int)addHealth;
		globalHero3Stat.CurrentVal = globalHero3Health;
	}
	
	public int returnHero3Health()
	{
		return globalHero3Health;
	}
	
	void Awake()
	{
		H3 = this;
		globalHero3Stat.Initialize();
        DontDestroyOnLoad(transform.gameObject);
    }
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}