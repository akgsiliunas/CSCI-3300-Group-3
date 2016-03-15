using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarScript : MonoBehaviour 
{
	private float fillAmount;
	
	[SerializeField]
	private float lerpSpeed;
	
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
			fillAmount = Map(value, 0, MaxValue, 0, 1);
		}
	}
	
	// Use this for initialization
	void Start ()
	{
		//Value = 2; // player health
	}
	
	// Update is called once per frame
	void Update ()
	{
		HandleBar();
	}
	
	private void HandleBar()
	{
		if (fillAmount != content.fillAmount)
		{
			content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
		}
	}
	// Translates the Player's health value to its equivalent Health Bar value
	private float Map(float value, float inMin, float inMax, float outMin, float outMax)
	{
		// (Current Health - Minimum Health) * (fillAmountMax - fillAmountMin) / (Maximum Health - Minimum Health) + fillAmountMin
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}
}