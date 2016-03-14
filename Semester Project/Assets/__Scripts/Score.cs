using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    public 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Texture tex;

    void OnGUI()
    {
        if (!tex)
            Debug.LogError("Error!");
        GUILayout.Label(tex);
        GUILayout.Label("Score" + Enemy.score);
        GUILayout.Label("Kills" + Enemy.kills);
    }
}
