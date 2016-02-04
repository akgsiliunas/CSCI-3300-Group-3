using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {
	static public Hero S;
	public float speed=30;
	public float rollMult = -45;
	public float pitchMult = 30;
	public float gameRestartDelay = 2f;

    [SerializeField]
    private float _shieldLevel=1;

    //Weapon Fields
    public Weapon[] weapons;

    public int playerNumber;

	public bool _____________;
	public delegate void WeaponFireDelegate();
	public WeaponFireDelegate fireDelegate;

    void Awake() {
        S = this;
    }

    void Start()
    {
        ClearWeapons();
        weapons[0].SetType(WeaponType.blaster);
	}
	
	void Update () {
		float xAxis = Input.GetAxis ("Horizontal");
		float yAxis = Input.GetAxis ("Vertical");

        //Debug.Log(xAxis);

		Vector3 pos = transform.position;
		pos.x += xAxis * speed * Time.deltaTime;
		pos.y += yAxis * speed * Time.deltaTime;
		transform.position = pos;


		transform.rotation = Quaternion.Euler (yAxis * pitchMult, xAxis * rollMult, 0);

        if (Input.GetAxis("Jump") == 1 && fireDelegate != null)
        {
            fireDelegate();
        }
    }

    /*
    public void Move ()
    {
        if (playerNumber == 1)
        {
            if (Input.GetAxis)



        }



    }
    */



    void OnTriggerEnter(Collider other)
    {
        GameObject rootGameObject = Utils.FindTaggedParent(other.gameObject);

        if (rootGameObject.tag == "Enemy")
        {
            shieldLevel--;
            Destroy(rootGameObject);
        }
        else if( rootGameObject.tag == "PowerUp")
        {
            AbsorbPowerUp(rootGameObject);
        }
        else
        {
            Debug.Log(rootGameObject.tag);
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
                Main.S.DelayedRestart(gameRestartDelay);	// Tells Main.S to restart the game after a delay
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
