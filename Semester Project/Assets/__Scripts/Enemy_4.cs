using UnityEngine;
using System.Collections;

// Boss Movement and Shooting Code

public class Enemy_4 : Enemy
{
    protected override void Start()
    {

        base.Start();

        weapons[0].SetType(WeaponType.bomblast);
        weapons[1].SetType(WeaponType.spread);
        weapons[2].SetType(WeaponType.spread);
        weapons[3].SetType(WeaponType.missile);
        weapons[4].SetType(WeaponType.missile);

        InvokeRepeating("Fire", fireRate, fireRate);
    }

    public override void Move()
    {
        base.Move();
    }
}