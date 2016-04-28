using UnityEngine;
using System.Collections;

public class Hero1Manager : MonoBehaviour
{
	public static Hero1Manager H1;
	
	public static int globalHero1Health;
	
	[SerializeField]
	private Stat globalHero1Stat;
	
	public void manageHealth(float health)
	{
		globalHero1Health = (int)health;
		globalHero1Stat.CurrentVal = globalHero1Health;
	}
	
	public void addHealth(float addHealth)
	{
		globalHero1Health += (int)addHealth;
		globalHero1Stat.CurrentVal = globalHero1Health;
	}
	
	public int returnHero1Health()
	{
		return globalHero1Health;
	}
	
	void Awake()
	{
		H1 = this;
		globalHero1Stat.Initialize();
        DontDestroyOnLoad(transform.gameObject);
    }
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}