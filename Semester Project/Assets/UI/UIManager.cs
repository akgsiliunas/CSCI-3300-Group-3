using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public bool TestMode,DebugMode;
	public static string PlayerName;
	public InputField iField;
	public int LoadingTime;
	public Text OutPutText;
	public Text TimerText;
	//private bool InputDisable;

	void OnEnable()
	{

		//InputDisable = false;
	}

	public void Hero1()
	{
		//if(!InputDisable)
		{
            //when you select Hero 1 than this method called
			//InputDisable=true;
			if(TestMode)
			{
				OutPutText.text="Hero 1 Selected";
			}
			if(DebugMode)
			{
				Debug.Log ("Hero 1 Selected");
				Debug.Log("Player Name = "+PlayerName);
			}
			StartCoroutine("Counting");
		}
	}
	public void Hero2()
	{
		//if(!InputDisable)
		{
            //when you select hero 2 than this method called
			//InputDisable=true;
			if(TestMode)
			{
				OutPutText.text="Hero 2 Selected";
			}
			if(DebugMode)
			{
				Debug.Log ("Hero 2 Selected");
				Debug.Log("Player Name = "+PlayerName);
			}
			StartCoroutine("Counting");
		}
	}
	public void Hero3()
	{
		//if(!InputDisable)
		{
            //click on hero3 button method
			//InputDisable=true;
			if(TestMode)
			{
				OutPutText.text="Hero 3 Selected";
			}
			if(DebugMode)
			{
				Debug.Log ("Hero 3 Selected");
				Debug.Log("Player Name = "+PlayerName);
			}
			StartCoroutine("Counting");
		}
	}
	public void Hero4()
	{
		//if(!InputDisable)
		{
            //lclick  on hero 4 method 
			//InputDisable=true;

			if(TestMode)
			{
				OutPutText.text="Hero 4 Selected";
			}
			if(DebugMode)
			{
				Debug.Log ("Hero 4 Selected");
				Debug.Log("Player Name = "+PlayerName);
			}
			StartCoroutine("Counting");
		}
	}

	public void TextFiledValue()
	{
		PlayerName = iField.text;
	}


	IEnumerator Counting() //this is for counting timer
	{
		TimerText.text = "Game Start In "+LoadingTime.ToString ()+" Second";
		yield return new WaitForSeconds(1);
		LoadingTime--;
		if(LoadingTime>0)
		{
			StartCoroutine("Counting");
		}
		else
		{
			TimerText.text = "Game Start In 0 Second";
			LoadingComplete();
		}

	}

	void LoadingComplete()
	{
		if(DebugMode)
		{
		 Debug.Log ("Loading Complete");
            Application.LoadLevel(1);//it load the next level
		}
	}
}
