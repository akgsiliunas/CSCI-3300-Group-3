using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Player1Stat
{
	[SerializeField]
	private Player1BarScript p1Bar;
	
	[SerializeField]
	private float maxVal;
	
	[SerializeField]
	private float currentVal;
	
	public float CurrentVal
	{
		get
		{
			return currentVal;
		}
		
		set
		{
			this.currentVal = Mathf.Clamp(value, 0, MaxVal);
			p1Bar.Value = currentVal;
		}
	}
	
	public float MaxVal
	{
		get
		{
			return maxVal;
		}
		
		set
		{
			this.maxVal = value;
			p1Bar.MaxValue = maxVal;
		}
	}
	
	public void Initialize()
	{
		this.MaxVal = maxVal;
		this.CurrentVal = currentVal;
	}
}