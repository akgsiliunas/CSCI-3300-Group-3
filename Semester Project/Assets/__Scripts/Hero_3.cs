﻿using UnityEngine;
using System.Collections;

public class Hero_3 : Player {

    void OnEnable()
    {
        if (!UIManager.player3)
        {
            this.gameObject.SetActive(false);
        }
    }
    public override void Update()
    {
        float xAxis = Input.GetAxis("Hero_3_Horizontal");
        float zAxis = Input.GetAxis("Hero_3_Vertical");

        Vector3 pos = transform.position;
        pos.x += -xAxis * speed * Time.deltaTime;
        pos.z += -zAxis * speed * Time.deltaTime;
        transform.position = pos;

        if (Input.GetKey("t") == true && fireDelegate != null)
            fireDelegate();
    }
}
