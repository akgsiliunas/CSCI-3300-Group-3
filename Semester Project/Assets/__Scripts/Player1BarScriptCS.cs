using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player1BarScript : MonoBehaviour 
{
	[SerializeField]
	private Image content;
	
	[SerializeField]
	private Text valueText;
	
	public float MaxValue { get; set; }
	
	public float Value
	{
		set
		{
			string[] tmp = valueText.text.Split(':');
			valueText.text = tmp[0] + ": " + value;
		}
	}
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}