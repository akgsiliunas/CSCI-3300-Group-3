using UnityEngine;
using System.Collections;

public enum WeaponType{
	none,
	blaster,
	spread,
	phaser,
	missile,
	laser,
	shield
}

[System.Serializable]
public class WeaponDefinition {
	public WeaponType type=WeaponType.none;
	public string letter;
	public Color color = Color.white;
	public GameObject projectilePrefab;
	public Color projectileColor = Color.white;
	public float damageOnHit = 0;
    public float continuousDamage = 0;
	public float delayBetweenShots = 0;
	public float velocity = 20;
}

public class Weapon : MonoBehaviour {
	static public Transform PROJECTILE_ANCHOR;

	public bool ________________;
	[SerializeField]
	private WeaponType _type = WeaponType.blaster;
	public WeaponDefinition def;
	public GameObject collar;
	public float lastShot;

    public Transform left;
    public Transform right;
    public Transform center;


    void Awake()
    {
        collar = transform.Find("Collar").gameObject;

        GameObject parentGo = transform.parent.gameObject;

        if (parentGo.tag == "Enemy")
            transform.root.GetComponent<Enemy>().fireDelegate += Fire;

        if (parentGo.tag == "Hero")
        {
            //Debug.Log("tagged");
            transform.root.GetComponent<Player>().fireDelegate += Fire;
        }
//        Hero.S.fireDelegate += Fire;

    }


    // Use this for initialization
    void Start () {

		SetType (_type);

		if (PROJECTILE_ANCHOR == null) {
			GameObject go = new GameObject ("_Projectile_Anchor");
			PROJECTILE_ANCHOR = go.transform;
		}


	}

	public WeaponType type{
		get {   return (_type); }
		set {   SetType(value); }
	}

	public void SetType(WeaponType wt){
		_type=wt;
		if (type==WeaponType.none){
			this.gameObject.SetActive (false);
			return;
		}
		else
			this.gameObject.SetActive (false);
		def = Main.GetWeaponDefinition (_type);
		collar.GetComponent<Renderer>().material.color=def.color;
		lastShot = 0;
	}

    public void Fire()
    {
        if (Time.time - lastShot < def.delayBetweenShots)
            return;

        Projectile p;
        switch (type)
        {
            case WeaponType.blaster:
                p = MakeProjectile();
                p.GetComponent<Rigidbody>().velocity = (center.position - collar.transform.position) * def.velocity;

                //p.GetComponent<Rigidbody>().velocity = transform.root.up * def.velocity;

               // reference.position - collar.transform.position

                //p.GetComponent<Rigidbody>().velocity = Vector3.left * def.velocity;
                break;

    

            case WeaponType.spread:
                p = MakeProjectile();
                p.GetComponent<Rigidbody>().velocity = (center.position - collar.transform.position) * def.velocity;
               // p.GetComponent<Rigidbody>().velocity = transform.root.up * def.velocity;
                p = MakeProjectile();
                p.GetComponent<Rigidbody>().velocity =  (left.position - collar.transform.position) * def.velocity;

                //p.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-0.2f,0,-0.9f) * def.velocity);

                p = MakeProjectile();
                p.GetComponent<Rigidbody>().velocity = (right.position - collar.transform.position) * def.velocity;
                //p.GetComponent<Rigidbody>().velocity = new Vector3(0.2f, 0, -0.9f) * def.velocity;
                break;
        }

    }
	
	public Projectile MakeProjectile(){
		GameObject go = Instantiate (def.projectilePrefab) as GameObject;

		if (transform.parent.gameObject.tag == "Hero") {
			go.tag = "ProjectileHero";
			go.layer = LayerMask.NameToLayer ("ProjectileHero");
		} else {
			go.tag = "ProjectileEnemy";
			go.layer = LayerMask.NameToLayer ("ProjectileEnemy");
		}
		go.transform.position = collar.transform.position;
        go.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
        go.transform.parent = PROJECTILE_ANCHOR;
		Projectile p = go.GetComponent<Projectile> ();
		p.type = type;
		lastShot = Time.time;
		return p;
	}
}

