using UnityEngine;
using System.Collections;

public class Hero_2 : Player {

    public override void Update()
    {
        float xAxis = Input.GetAxis("Hero_2_Horizontal");
        float yAxis = Input.GetAxis("Hero_2_Vertical");

        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;


        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);

        if (Input.GetKey("q") == true && fireDelegate != null)
            fireDelegate();
    }
}
