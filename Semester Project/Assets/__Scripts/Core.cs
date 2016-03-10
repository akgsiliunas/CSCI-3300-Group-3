using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Core : MonoBehaviour {

    static public Core C;

    public float health = 1000;
    public float fullHealth = 1000;

    public Animator coreAnimator;
    public ParticleSystem deathPS;

    void Awake()
    {
        C = this;
        coreAnimator.SetFloat("Health", fullHealth);
        deathPS.Pause();
    }

	void Update () {

        if (health < 0)
        {
            deathPS.Play();
            StartCoroutine("Counting");

        }

        Debug.Log(health);
        coreAnimator.SetFloat("Health", health);
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

    IEnumerator Counting() //this is for counting timer
    {
        yield return new WaitForSeconds(10);
        Application.LoadLevel(0);
    }
}
