using UnityEngine;
using System.Collections;

public class Hero_1 : Player {
	
	public override void Update()
    {
        float xAxis = Input.GetAxis("Hero_1_Horizontal");
        float yAxis = Input.GetAxis("Hero_1_Vertical");

        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;


        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);

        if (Input.GetKey("space") == true && fireDelegate != null)
            fireDelegate();
    }
}
