using UnityEngine;
using System.Collections;

public class Hero_3 : Player {

    public override void Update()
    {
        float xAxis = Input.GetAxis("Hero_3_Horizontal");
        float yAxis = Input.GetAxis("Hero_3_Vertical");

        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;


        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);

        if (Input.GetKey("t") == true && fireDelegate != null)
            fireDelegate();
    }
}
