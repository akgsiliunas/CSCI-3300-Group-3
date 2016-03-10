using UnityEngine;
using System.Collections;

public class Core : MonoBehaviour {

    static public Core C;

    public float health = 100;

    void Awake()
    {
        C = this;
    }

	void Update () {

        if (health < 0)
        {
            Application.LoadLevel(0);
        }

        Debug.Log(health);
	
	}


    public void Damage(float damageValue)
    {
        health -= damageValue;
    }


    void OnTriggerEnter(Collider collider)
    {
        GameObject other = collider.gameObject;

        if (other.tag == "ProjectileEnemy")
        {
            Projectile p = other.GetComponent<Projectile>();
            health -= Main.W_DEFS[p.type].damageOnHit;
            Destroy(other);
        }

    }
}
