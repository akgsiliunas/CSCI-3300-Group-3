using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static public UIManager UM;

    public bool player1 = false;
    public bool player2 = false;
    public bool player3 = false;
    public bool player4 = false;

    private bool counter = false;
    private bool startScreen = true;
    private bool staged = false;

    public Vector3 player1Position = new Vector3(0, 0, 0);
    public Vector3 player2Position = new Vector3(0, 0, 0);
    public Vector3 player3Position = new Vector3(0, 0, 0);
    public Vector3 player4Position = new Vector3(0, 0, 0);

    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public GameObject player3Prefab;
    public GameObject player4Prefab;

    public GameObject shield1;
    public GameObject shield2;
    public GameObject shield3;
    public GameObject shield4;
	
	public float player1GlobalHealth;
	
	public GameObject canvasMainPrefab;
	
	public Vector3 hero1HealthBarPosition = new Vector3(0, 0, 0);
	
	public GameObject hero1HealthBarPrefab;
	//public Image hero1HealthBarPrefab;
	
    //public static readonly float Tutorial = 0.01f;
    //public static readonly float Easy = 1;
    //public static readonly float Normal = 20;
    //public static readonly float Hard = 300;
    //public static readonly float ExtremelyHard = 4000;

    public float DiffLevel;

    

    public bool TestMode,DebugMode;
	//public static string PlayerName;
	//public InputField iField;
	public int LoadingTime;
	public Text OutPutText;
	public Text TimerText;
    //private bool InputDisable;



       
    void Update()
    {

        if (Application.loadedLevel == 1 && staged == false)
        {
            Stage();
            staged = true;
        }


        if (startScreen == true)
        {      
            if (Input.GetKey("z") == true)
            {
                DiffLevel = 0.5f;
            }

            if (Input.GetKey("x") == true)
            {
                DiffLevel = 1;
            }

            if (Input.GetKey("c") == true)
            {
                DiffLevel = 2;
            }

            if (Input.GetKey("v") == true)
            {
                DiffLevel = 3;
            }

            if (Input.GetKey("b") == true)
            {
                DiffLevel = 4;
            }

            if (Input.GetKey("1") == true && player1 == false)
            {
                player1 = true;
                shield1.GetComponent<MeshRenderer>().enabled = true;

                if (counter == false)
                {
                    StartCoroutine("Counting");
                    counter = true;
                }
            }

            else if (Input.GetKey("2") == true && player2 == false)
            {
                player2 = true;
                shield2.GetComponent<MeshRenderer>().enabled = true;
                if (counter == false)
                {
                    StartCoroutine("Counting");
                    counter = true;
                }
            }

            else if (Input.GetKey("3") == true && player3 == false)
            {
                player3 = true;
                shield3.GetComponent<MeshRenderer>().enabled = true;

                if (counter == false)
                {
                    StartCoroutine("Counting");
                    counter = true;
                }
            }

            else if (Input.GetKey("4") == true && player4 == false)
            {
                player4 = true;
                shield4.GetComponent<MeshRenderer>().enabled = true;

                if (counter == false)
                {
                    StartCoroutine("Counting");
                    counter = true;
                }
            }
        }
    }

    public void Stage()
    {
		GameObject canvasMain = Instantiate(canvasMainPrefab) as GameObject; //
        if (player1 == true)
        {
            GameObject player = Instantiate(player1Prefab) as GameObject;
            player.transform.position = player1Position;
        }
        if (player2 == true)
        {
            GameObject player = Instantiate(player2Prefab) as GameObject;
            player.transform.position = player2Position;
        }
        if (player3 == true)
        {
            GameObject player = Instantiate(player3Prefab) as GameObject;
            player.transform.position = player3Position;
        }
        if (player4 == true)
        {
            GameObject player = Instantiate(player4Prefab) as GameObject;
            player.transform.position = player4Position;
        }
    }

    void Awake()
    {
        // DontDestroyOnLoad(transform.gameObject);
        UM = this;
    }



    void OnEnable()
	{

		//InputDisable = false;
	}
    /*
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
    */


	IEnumerator Counting() //this is for counting timer
	{
		TimerText.text = "Game Starts In "+LoadingTime.ToString ()+" Second";
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

        Application.LoadLevel(1);

        DontDestroyOnLoad(transform.gameObject);

        startScreen = false;

        //Stage();

  

        if (DebugMode)
		{
		 //Debug.Log ("Loading Complete");

            Application.LoadLevel(1);

            DontDestroyOnLoad(transform.gameObject);
        }
	}
}
