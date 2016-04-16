using UnityEngine;
using System.Collections;

// Rook Movement and Shooting Code

public class Enemy_2 : Enemy {

    public bool negativeZ = false;
    public bool negativeX = false;

    public float waveFrequency = 2;
    public float waveWidth = 4;

    private float x0;
    private float z0;

    private float birthTime;

    protected override void Start()
    {
        base.Start();

        weapons[0].SetType(WeaponType.missile);

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
        float atan = Mathf.Atan(theta);

        if (movement == Movement.Left || movement == Movement.Right)
        {
            if (negativeZ == true)
                tempPos.z = z0 + waveWidth * atan;
            else
                tempPos.z = z0 - waveWidth * atan;
        }
        else
        {
            if (negativeX == true)
                tempPos.x = x0 + waveWidth * atan;
            else
                tempPos.x = x0 - waveWidth * atan;
        }

        pos = tempPos;

        base.Move();
    }
}