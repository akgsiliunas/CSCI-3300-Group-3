using UnityEngine;
using System.Collections;

public class Hero_2 : Player {
    void OnEnable()
    {
        if (!UIManager.player2)
        {
            this.gameObject.SetActive(false);
        }
    }
    public override void Update()
    {
        float xAxis = Input.GetAxis("Hero_2_Horizontal");
        float zAxis = Input.GetAxis("Hero_2_Vertical");

        Vector3 pos = transform.position;
        pos.x += -xAxis * speed * Time.deltaTime;
        pos.z += -zAxis * speed * Time.deltaTime;
        transform.position = pos;

        if (Input.GetKey("q") == true && fireDelegate != null)
            fireDelegate();
    }
}
