using UnityEngine;
using System.Collections;

public class DiffLevel : MonoBehaviour {
	public static DiffLevel DL;
	public static readonly float Tutorial = 0.5f;
	public static readonly float Easy = 1;
	public static readonly float Normal = 2;
	public static readonly float Hard = 4;
	public static readonly float ExtremelyHard = 8;
	private bool startScreen = true;

	public float DiffLevels;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (startScreen == true) {      
			if (Input.GetKey ("z") == true) {
				DiffLevels = 0.5f;
			}

			if (Input.GetKey ("x") == true) {
				DiffLevels = 1;
			}

			if (Input.GetKey ("c") == true) {
				DiffLevels = 2;
			}

			if (Input.GetKey ("v") == true) {
				DiffLevels = 3;
			}

			if (Input.GetKey ("b") == true) {
				DiffLevels = 4;
			}

		}
	}

	void Awake(){
		DL = this;
	}
}
