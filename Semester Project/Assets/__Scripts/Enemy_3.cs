using UnityEngine;
using System.Collections;

public class Enemy_3 : Enemy
{

    // Worm


    /*
    public Vector3[] points;
    public float birthTime;
    public float lifeTime = 10;
*/
    public float waveFrequency = 2;
    public float waveWidth = 4;
    //public float waveRot = 10;

    private float x0;
    private float z0;

    private float birthTime;

    void Start()
    {

        base.Orient();

       // weapons[0].SetType(WeaponType.blaster);

        x0 = pos.x;
        z0 = pos.z;

        birthTime = Time.time;

        //InvokeRepeating("Fire", fireRate, fireRate);

    }


    public override void Move()
    {
        /*
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
        */
        base.Move();
    }

    /*

    void Start()
    {
        points = new Vector3[3];

        points[0] = pos;

        float xMin = Utils.camBounds.min.x + Main.S.enemySpawnPadding;
        float xMax = Utils.camBounds.max.x - Main.S.enemySpawnPadding;

        Vector3 v;

        v = Vector3.zero;
        v.x = Random.Range(xMin, xMax);
        v.y = Random.Range(Utils.camBounds.min.y, 0);
        points[1] = v;

        v = Vector3.zero;
        v.y = pos.y;
        v.x = Random.Range(xMin, xMax);
        points[2] = v;

        birthTime = Time.time;
    }

    public override void Move()
    {
        float u = (Time.time - birthTime) / lifeTime;
        if (u > 1)
        {
            Destroy(this.gameObject);
            return;
        }

        Vector3 p01, p12;
        u = u - 0.2f * Mathf.Sin(u * Mathf.PI * 2);
        p01 = (1 - u) * points[0] + u * points[1];
        p12 = (1 - u) * points[1] + u * points[2];
        pos = (1 - u) * p01 + u * p12;
    }
    */
}