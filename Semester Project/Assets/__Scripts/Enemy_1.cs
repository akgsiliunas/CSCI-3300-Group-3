using UnityEngine;
using System.Collections;

// Standard Virus Movement and Shooting Code

public class Enemy_1 : Enemy {

    public float waveFrequency = 2;
    public float waveWidth = 4;

    private float x0;  
    private float z0;

    private float birthTime;


	protected override void Start () {

        base.Start();

        weapons[0].SetType(WeaponType.blaster);

        x0 = pos.x;
        z0 = pos.z; 

        birthTime = Time.time;

        InvokeRepeating("Fire", fireRate, fireRate);
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

        base.Move();
    }

}
