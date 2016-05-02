using UnityEngine;
using System.Collections;

public class Hero4Manager : MonoBehaviour
{
	public static Hero4Manager H4;
	
	public static int globalHero4Health;
	
	[SerializeField]
	private Stat globalHero4Stat;
	
	public void manageHealth(float health)
	{
		globalHero4Health = (int)health;
		globalHero4Stat.CurrentVal = globalHero4Health;
	}
	
	public void addHealth(float addHealth)
	{
		globalHero4Health += (int)addHealth;
		globalHero4Stat.CurrentVal = globalHero4Health;
	}
	
	public int returnHero4Health()
	{
		return globalHero4Health;
	}
	
	void Awake()
	{
		H4 = this;
		globalHero4Stat.Initialize();
        DontDestroyOnLoad(transform.gameObject);
    }
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}