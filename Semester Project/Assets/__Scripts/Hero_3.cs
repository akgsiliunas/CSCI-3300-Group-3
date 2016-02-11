﻿using UnityEngine;
using System.Collections;

public class Hero_3 : Player {

    public override void Update()
    {
        float xAxis = Input.GetAxis("Hero_3_Horizontal");
        float zAxis = Input.GetAxis("Hero_3_Vertical");

        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.z += zAxis * speed * Time.deltaTime;
        transform.position = pos;


        transform.rotation = Quaternion.Euler(-90 + -zAxis * pitchMult, 0, -xAxis * rollMult);

        if (Input.GetKey("t") == true && fireDelegate != null)
            fireDelegate();
    }
}
