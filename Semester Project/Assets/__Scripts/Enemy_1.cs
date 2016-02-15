﻿using UnityEngine;
using System.Collections;

public class Enemy_1 : Enemy {


    public float waveFrequency = 2;
    public float waveWidth = 4;
    public float waveRot = 10;

    private float x0;   // The initial x value of pos
    private float z0;

    private float birthTime;

	// Use this for initialization
	void Start () {

        base.Orient();

        x0 = pos.x;
        z0 = pos.z; 

        birthTime = Time.time;
	
	}
	
    public override void Move()
    {
        Vector3 tempPos = pos;
        float age = Time.time - birthTime;
        float theta = Mathf.PI * 2 * age / waveFrequency;
        float sin = Mathf.Sin(theta);

        if (movement == Movement.Left || movement == Movement.Right)
            tempPos.z = z0 + waveWidth * sin;

        else
            tempPos.x = x0 + waveWidth * sin;

        pos = tempPos;

        // Rotate
        //Vector3 rot = new Vector3(-90, 0, sin * waveRot);
        //this.transform.rotation = Quaternion.Euler(rot);

        base.Move();
    }

}
