using UnityEngine;
using System.Collections;

public class Hero2Manager : MonoBehaviour
{
	public static Hero2Manager H2;
	
	public static int globalHero2Health;
	
	[SerializeField]
	private Stat globalHero2Stat;
	
	public void manageHealth(float health)
	{
		globalHero2Health = (int)health;
		globalHero2Stat.CurrentVal = globalHero2Health;
	}
	
	public void addHealth(float addHealth)
	{
		globalHero2Health += (int)addHealth;
		globalHero2Stat.CurrentVal = globalHero2Health;
	}
	
	public int returnHero2Health()
	{
		return globalHero2Health;
	}
	
	void Awake()
	{
		H2 = this;
		globalHero2Stat.Initialize();
        DontDestroyOnLoad(transform.gameObject);
    }
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}