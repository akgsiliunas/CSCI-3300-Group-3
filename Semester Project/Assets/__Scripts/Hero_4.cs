using UnityEngine;
using System.Collections;

public class Hero_4 : Player
{
    void OnEnable()
    {
        if (!UIManager.player4)
        {
            this.gameObject.SetActive(false);
        }
    }
    public override void Update()
    {
        float xAxis = Input.GetAxis("Hero_4_Horizontal");
        float zAxis = Input.GetAxis("Hero_4_Vertical");

        Vector3 pos = transform.position;
        pos.x += -xAxis * speed * Time.deltaTime;
        pos.z += -zAxis * speed * Time.deltaTime;
        transform.position = pos;

        if (Input.GetKey("o") == true && fireDelegate != null)
            fireDelegate();
    }
}
