using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Core : MonoBehaviour {

    static public Core C;

    //public float health = 1000;
	
	[SerializeField]
	private Stat health;
	//health.currentVal = 1000;
	//health.maxVal = 1000;
    
	//public float fullHealth = 1000;
	
	
	
    public Animator coreAnimator;
    public ParticleSystem deathPS;

    void Awake()
    {
		health.Initialize();
        C = this;
        coreAnimator.SetFloat("Health", health.MaxVal);
        deathPS.Pause();
    }



	
	void Update () {

        if (health.CurrentVal <= 0)
        {
            deathPS.Play();
            StartCoroutine("Counting");

        }

      //  Debug.Log(health);
        coreAnimator.SetFloat("Health", health.CurrentVal);
    }


    public void Damage(float damageValue)
    {
        health.CurrentVal -= damageValue;
    }

    public void Repair(float repairValue)
    {
        health.CurrentVal += repairValue;
    }


    void OnTriggerEnter(Collider collider)
    {
        GameObject other = collider.gameObject;

        if (other.tag == "ProjectileEnemy")
        {
            Projectile p = other.GetComponent<Projectile>();
            health.CurrentVal -= Main.W_DEFS[p.type].damageOnHit;
            //Destroy(other);
            other.GetComponent<Projectile>().Die();
        }
    }

    IEnumerator Counting() //this is for counting timer
    {
        yield return new WaitForSeconds(5);
        Debug.Log("Here is game over"); // Abdullah edit it
        Application.LoadLevel(3);
    }
}
