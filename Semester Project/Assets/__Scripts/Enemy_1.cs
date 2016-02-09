using UnityEngine;
using System.Collections;

public class Enemy_1 : Enemy {


    public float waveFrequency = 2;
    public float waveWidth = 4;
    public float waveRotY = 45;

    private float x0 = -12345;   // The initial x value of pos
    private float birthTime;

	// Use this for initialization
	void Start () {

        x0 = pos.x;

        birthTime = Time.time;
	
	}
	
    public override void Move()
    {
        Vector3 tempPos = pos;
        float age = Time.time - birthTime;
        float theta = Mathf.PI * 2 * age / waveFrequency;
        float sin = Mathf.Sin(theta);
        tempPos.x = x0 + waveWidth * sin;
        pos = tempPos;
        Vector3 rot = new Vector3(0, sin * waveRotY, 0);
        this.transform.rotation = Quaternion.Euler(rot);
        base.Move();
    }
	// Update is called once per frame
	void Update () {
	
	}
}
