﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
   
    public float speed = 30;

    [SerializeField]
    private float _shieldLevel = 1;
    public float maxShieldStrength = 50f;

    //Weapon Fields
    public Weapon[] weapons;

    public delegate void WeaponFireDelegate();
    public WeaponFireDelegate fireDelegate;

    // Shield Regeneration Variables
    public float regenTime = 1f;
    public int regenAmount = 1;
    private float timeChange = 0f;

 


    void Start()
    {
        ClearWeapons();
        weapons[0].SetType(WeaponType.blaster);
    }

    public virtual void Update()
    {

    }
    
    /*
    public void RegenShield()
    {
        Debug.Log(shieldLevel);
        if (timeChange > regenTime)
        {
            
            timeChange = 0f;
            shieldLevel = Mathf.Min(maxShieldStrength, shieldLevel + regenAmount);
            Debug.Log(shieldLevel);
            Debug.Log("Regen amount is " + regenAmount);
            Debug.Log("I'm regening");
        }
        else
            timeChange += Time.deltaTime;
    }
    */

    void OnTriggerEnter(Collider other)
    {
        //GameObject rootGameObject = Utils.FindTaggedParent(other.gameObject);

        if (other.tag == "ProjectileEnemy")
        {
           // Debug.Log("jasdfowaefjws");
            shieldLevel--;
            //Destroy(other.transform.root.gameObject);
            other.GetComponent<Projectile>().Die();
        }
        if (other.transform.root.tag == "Enemy")
        {
            shieldLevel--;
           // other.GetComponent<Enemy>().deathPS.Play();
            Destroy(other.transform.root.gameObject);
        }
        else if (other.transform.root.tag == "PowerUp")
        {
            AbsorbPowerUp(other.transform.root.gameObject);
        }
        else
        {
            //Debug.Log(other.transform.root.tag);
        }
    }

    public float shieldLevel
    {
        get
        {
            return (_shieldLevel);
        }
        set
        {
            _shieldLevel = Mathf.Min(value, maxShieldStrength);
            if (value < 0)
            {
                Destroy(this.gameObject);
                Debug.Log("is it over?and out");
            }
        }
    }

    public void AddShieldLevel(int amount)
    {
        _shieldLevel = Mathf.Min(maxShieldStrength, _shieldLevel + amount);
        Debug.Log(_shieldLevel);
    }

    public void AbsorbPowerUp(GameObject go)
    {
        PowerUp pu = go.GetComponent<PowerUp>();
        switch (pu.type)
        {
            case WeaponType.shield:
                shieldLevel++;
                break;

            default:
                if (pu.type == weapons[0].type)
                {
                    Weapon w = GetEmptyWeaponSlot();
                    if (w != null)
                    {
                        w.SetType(pu.type);
                    }
                }
                else
                {
                    ClearWeapons();
                    weapons[0].SetType(pu.type);
                }
                break;
        }
        pu.AbsorbedBy(this.gameObject);
    }

    Weapon GetEmptyWeaponSlot()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].type == WeaponType.none)
                return (weapons[i]);
        }
        return (null);
    }

    void ClearWeapons()
    {
        foreach (Weapon w in weapons)
        {
            w.SetType(WeaponType.none);
        }
    }




}