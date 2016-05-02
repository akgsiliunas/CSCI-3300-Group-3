using UnityEngine;
using System.Collections;

public class Hero_1 : Player {
	/*
	public float speed = 30;

    [SerializeField]
    private float _shieldLevel = 1;
    public float maxShieldStrength = 50f;
	
	//[SerializeField]
	//private Stat health;

    //Weapon Fields
    public Weapon[] weapons;

    public delegate void WeaponFireDelegate();
    public WeaponFireDelegate fireDelegate;

    // Shield Regeneration Variables
    public float regenTime = 1f;
    public int regenAmount = 1;
    private float timeChange = 0f;
	*/
	
	void Start()
    {
        ClearWeapons();
        weapons[0].SetType(WeaponType.blaster);
    }

    void OnColliderEnter(Collider co)
    {
        Debug.Log(co.gameObject.name);
    }
	
	
	public void Update()
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
	
	void OnTriggerEnter(Collider other)
    {
        //GameObject rootGameObject = Utils.FindTaggedParent(other.gameObject);

        if (other.tag == "ProjectileEnemy")
        {
           // Debug.Log("jasdfowaefjws");
            shieldLevel--;
			//health.CurrentVal = _shieldLevel;
			Hero1Manager.H1.manageHealth(_shieldLevel);
            //Destroy(other.transform.root.gameObject);
            other.GetComponent<Projectile>().Die();
        }
        if (other.transform.root.tag == "Enemy")
        {
            shieldLevel--;
			//health.CurrentVal = _shieldLevel;
			Hero1Manager.H1.manageHealth(_shieldLevel);

            other.transform.root.gameObject.GetComponent<Enemy>().Die();

          // other.GetComponent<Enemy>().deathPS.Play();
           // Destroy(other.transform.root.gameObject);
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
			//health.CurrentVal = _shieldLevel;
			Hero1Manager.H1.manageHealth(_shieldLevel);
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
		//health.CurrentVal = _shieldLevel;
		Hero1Manager.H1.manageHealth(_shieldLevel);
      //  Debug.Log(_shieldLevel);
    }
	
	public void AbsorbPowerUp(GameObject go)
    {
        PowerUp pu = go.GetComponent<PowerUp>();
        switch (pu.type)
        {
            case WeaponType.shield:
                WeaponDefinition shieldDef = Main.GetWeaponDefinition(WeaponType.shield);
                _shieldLevel += shieldDef.shieldValue;
				//health.CurrentVal = _shieldLevel;
				Hero1Manager.H1.manageHealth(_shieldLevel);
                break;

            case WeaponType.repair:
                WeaponDefinition repairDef = Main.GetWeaponDefinition(WeaponType.repair);
                Core.C.Repair(repairDef.repairValue);
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
