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

public class WeaponDefinition{
	public WeaponType type=WeaponType.none;
	public string letter;
	public Color color = Color.white;
	public GameObject projectilePrefab;
	public Color projectileColor = Color.white;
	public float damageOnHit=0;
	public float delayBetweenShots=0;
	public float velocity=20;
}

public class Weapon : MonoBehaviour {
	static public Transform PROJECTILE_ANCHOR;
	public bool _;
	[SerializeField]
	private WeaponType _type = WeaponType.blaster;
	public WeaponDefinition def;
	public GameObject collar;
	public float lastShot;

	// Use this for initialization
	void Start () {
		collar = transform.Find ("Collar").gameObject;
		SetType (_type);
		if (PROJECTILE_ANCHOR == null) {
			GameObject go = new GameObject ("_Projectile_Anchor");
			PROJECTILE_ANCHOR = go.transform;
		}
		GameObject parentGo = transform.parent.gameObject;
		if (parentGo.tag == "Hero")
			Hero.S.fireDelegate += Fire;

	}

	public WeaponType type{
		get {return (_type);}
		set { SetType(value); }
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

	public void Fire(){
		if (!gameObject.activeInHierarchy)
			return;
		if (Time.time - lastShot < def.delayBetweenShots)
			return;
		Projectile p;
		switch (type) {
		case WeaponType.blaster:
			p = MakeProjectile ();
			p.GetComponent<Rigidbody>().velocity = Vector3.up * def.velocity;
			break;

		case WeaponType.spread:
			p = MakeProjectile ();
			p.GetComponent<Rigidbody>().velocity.velocity = Vector3.up * def.velocity;
			p = MakeProjectile ();
			p.GetComponent<Rigidbody>().velocity.velocity = new Vector3 (-0.2f, 0.9f, 0) * def.velocity;
			p = MakeProjectile ();
			p.GetComponent<Rigidbody>().velocity.velocity = new Vector3 (0.2f, 0.9f, 0) * def.velocity;
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
		go.transform.parent = PROJECTILE_ANCHOR;
		Projectile p = go.GetComponent<Projectile> ();
		p.type = type;
		lastShot = Time.time;
		return p;
	}
	// Update is called once per frame
	void Update () {
	
	}
}

