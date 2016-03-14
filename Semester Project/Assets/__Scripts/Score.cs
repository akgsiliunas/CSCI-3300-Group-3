using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public Texture tex;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		if (!tex)
			Debug.LogError("Missing texture, assign a texture in the inspector");
		GUILayout.Label ("score" + Enemy.score);
		GUILayout.Label ("kills" + Enemy.kills);
	}
}
