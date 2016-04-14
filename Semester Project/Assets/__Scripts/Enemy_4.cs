using UnityEngine;
using System.Collections;
[System.Serializable]

// Boss Code

public class Enemy_4 : Enemy
{

    public override void Start()
    {

        base.Orient();

        weapons[0].SetType(WeaponType.blaster);
        weapons[1].SetType(WeaponType.blaster);
        weapons[2].SetType(WeaponType.blaster);
        weapons[3].SetType(WeaponType.blaster);
        weapons[4].SetType(WeaponType.blaster);

        InvokeRepeating("Fire", fireRate, fireRate);

    }

    void Update()
    {
        // Debug.Log(movement);
        base.Move();
    }
}