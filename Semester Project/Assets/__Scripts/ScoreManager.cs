using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	static public ScoreManager SM;
	
	public int globalScore;
	
	[SerializeField]
	private Stat globalScoreStat;
	
	public void addScore(int addedScore)
	{
		globalScore += addedScore;
		globalScoreStat.CurrentVal = globalScore;
	}
	
	public int returnScore()
	{
		return globalScore;
	}
	
	// Ensures the ScoreManager game object is not destroyed when a new game is loaded
	void Awake()
	{
		SM = this;
		globalScoreStat.Initialize();
		//DontDestroyOnLoad(transform.gameObject);
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
