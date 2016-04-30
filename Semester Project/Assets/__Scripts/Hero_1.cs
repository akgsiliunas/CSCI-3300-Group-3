using UnityEngine;
using System.Collections;

public class Hero_1 : Player {
    void OnEnable()
    {
        if (!UIManager.player1)
        {
            this.gameObject.SetActive(false);
        }
    }
    public override void Update()
    {
        float xAxis = Input.GetAxis("Hero_1_Horizontal");
        float zAxis = Input.GetAxis("Hero_1_Vertical");

        Vector3 pos = transform.position;
        pos.x += -xAxis * speed * Time.deltaTime;
        pos.z += -zAxis * speed * Time.deltaTime;
        transform.position = pos;

        if (Input.GetKey("space") == true && fireDelegate != null)
            fireDelegate();
    }
}
