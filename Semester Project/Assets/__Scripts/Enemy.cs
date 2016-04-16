using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed = 2.0f;
    public float fireRate = 0.3f;
    public float health = 10;

    public int score;
    public float collideDamage = 50f;

    public float powerUpDropChance = 1f;

    public enum Movement { Left, Right, Top, Bottom};
    public Movement movement;

    public Weapon[] weapons;

    public delegate void WeaponFireDelegate();
    public WeaponFireDelegate fireDelegate;

    public delegate void BossCountDelegate();
    public BossCountDelegate bossCountDelegate;

    public ParticleSystem deathPS;

    private bool isDead = false;

    protected virtual void Start()
    {
        speed = speed * UIManager.UM.DiffLevel;
        fireRate = fireRate * UIManager.UM.DiffLevel;
        health = 10 * UIManager.UM.DiffLevel;

        deathPS.Pause();
        Orient();
    }



    void Update()
    {
        Move();
    }

    public virtual void Move()
    {
        Vector3 tempPos = pos;

        if (movement == Movement.Left)
            tempPos.x -= 1 * speed * Time.deltaTime;

        else if( movement == Movement.Right)
            tempPos.x -= -1 * speed * Time.deltaTime;

        else if (movement == Movement.Top)
            tempPos.z -= -1 * speed * Time.deltaTime;

        else
            tempPos.z -= 1 * speed * Time.deltaTime;

       // Debug.Log("speed2: " + this.speed);
        pos = tempPos;
    }

    public Vector3 pos
    {
        get
        {
            return (this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    }

    public virtual void Orient()
    {
        if (movement == Movement.Left)
            transform.rotation = Quaternion.Euler(new Vector3(270, -90, 0));

        else if (movement == Movement.Right)
            transform.rotation = Quaternion.Euler(new Vector3(270, 90, 0));

        else if (movement == Movement.Top)
            transform.rotation = Quaternion.Euler(new Vector3(270, 0, 0));

        else
            transform.rotation = Quaternion.Euler(new Vector3(-90, -180, 0));
    }

    public void GatherHit(GameObject other)
    {
        Projectile p = other.GetComponent<Projectile>();
        health -= Main.W_DEFS[p.type].damageOnHit;

        if (health < 0)
        {
            ScoreManager.SM.addScore(score);
            Die();

            if (isDead == false)
            {
                Main.S.ShipDestroyed(powerUpDropChance, this.transform.position);
                isDead = true;
            }
        }
    }


    public virtual void Fire()
    {

        if (fireDelegate != null)
            fireDelegate();
    }

    public void CollisionDie()
    {
        deathPS.Play();
        Destroy(this.gameObject);
    }

    public void Die()
    {
        if (bossCountDelegate != null)
            bossCountDelegate();

        // Turn off all mesh renderers and colliders on models
        foreach (Transform child in transform)
        {
            if (child.GetComponent<Collider>() != null)
                child.GetComponent<Collider>().enabled = false;
            if (child.GetComponent<MeshRenderer>() != null)
                child.GetComponent<MeshRenderer>().enabled = false;
        }

        deathPS.Play();
        Destroy(this.gameObject, 0.7f);
    }



}