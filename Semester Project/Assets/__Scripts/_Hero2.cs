using UnityEngine;
using System.Collections;

public class _Hero2 : MonoBehaviour {
	static public _Hero2 S2;
	public float speed=30;
	public float rollMult = -45;
	public float pitchMult = 30;
	public float shieldLevel=1;
	public bool _____________;

	void Awake(){
		S2 = this;
	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		float xAxis = Input.GetAxis ("Horizontal");
		float yAxis = Input.GetAxis ("Vertical");
		Vector3 pos = transform.position;
		pos.x += xAxis * speed * Time.deltaTime;
		pos.y += yAxis * speed * Time.deltaTime;
		transform.position = pos;

		transform.rotation = Quaternion.Euler (yAxis * pitchMult, xAxis * rollMult, 0);
	}
}
