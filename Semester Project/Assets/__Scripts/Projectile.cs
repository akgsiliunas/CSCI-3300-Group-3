using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	[SerializeField]
	private WeaponType _type;

    public ParticleSystem explosion;

	public WeaponType type{
		get{
			return _type;
		}
		set{
			SetType (value);
		}
	}

	void Awake(){
		InvokeRepeating ("CheckOffscreen", 2f, 2f);
	}

	public void SetType(WeaponType eType){
		_type=eType;
		WeaponDefinition def = Main.GetWeaponDefinition (_type);
		GetComponent<Renderer>().material.color = def.projectileColor;
	}

	void CheckOffscreen(){
		if (Utils.ScreenBoundsCheck (GetComponent<Collider> ().bounds, BoundsTest.offScreen) != Vector3.zero)
			Destroy (this.gameObject);
	}

    public void Die()
    {
        this.GetComponent<MeshRenderer>().enabled = false;

        this.GetComponent<Rigidbody>().velocity = Vector3.zero;

        // Turn off any bullet trail particle systems
        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == "BulletTrail")
                Destroy(child.gameObject);
        }
                
        explosion.Play();

        Destroy(this.gameObject,3f);
    }
}
