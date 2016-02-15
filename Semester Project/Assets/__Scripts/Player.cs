using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
   
    public float speed = 30;

    [SerializeField]
    private float _shieldLevel = 1;

    //Weapon Fields
    public Weapon[] weapons;

    public delegate void WeaponFireDelegate();
    public WeaponFireDelegate fireDelegate;


    void Start()
    {
        ClearWeapons();
        weapons[0].SetType(WeaponType.blaster);
    }

    public virtual void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        //GameObject rootGameObject = Utils.FindTaggedParent(other.gameObject);

        if (other.transform.root.tag == "Enemy")
        {
            shieldLevel--;
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
            _shieldLevel = Mathf.Min(value, 4);
            if (value < 0)
            {
                Destroy(this.gameObject);
            }
        }
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