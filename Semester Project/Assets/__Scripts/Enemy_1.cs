using UnityEngine;
using System.Collections;

public class Enemy_1 : Enemy {

    //public float speed = 2.0f * UIManager.DiffLevel;

    public float waveFrequency = 2;
    public float waveWidth = 4;
    //public float waveRot = 10;

    private float x0;  
    private float z0;

    private float birthTime;


	void Start () {

        base.Orient();

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

        // Rotate
        //Vector3 rot = new Vector3(-90, 0, sin * waveRot);
        //this.transform.rotation = Quaternion.Euler(rot);

        base.Move();
    }

}
