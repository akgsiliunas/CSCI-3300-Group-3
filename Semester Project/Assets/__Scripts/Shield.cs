using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {
	public float rotationPerSecond = 0.1f;
	public bool __________;
	public int levelShown = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int currLevel = Mathf.FloorToInt (transform.root.GetComponent<Player>().shieldLevel);
		if (levelShown != currLevel) {
			levelShown = currLevel;
			Material mat = GetComponent<Renderer> ().material;
			mat.mainTextureOffset = new Vector2 (0.2f * levelShown, 0);
		}
		float rZ = (rotationPerSecond * Time.time * 360) % 360f;
		transform.rotation = Quaternion.Euler (0, 0, rZ);
	}
}
