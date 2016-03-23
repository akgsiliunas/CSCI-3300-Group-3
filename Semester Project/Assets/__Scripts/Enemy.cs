﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float fireRate = 0.3f;
    public float health = 10;
    public int score;
    public float collideDamage = 50f;

    public float powerUpDropChance = 1f;

    public bool _____________________;

    public enum Movement { Left, Right, Top, Bottom};
    public Movement movement;

    public Weapon[] weapons;

    public delegate void WeaponFireDelegate();
    public WeaponFireDelegate fireDelegate;

    public ParticleSystem deathPS;



    void Start()
    {
        deathPS.Pause();
        Orient();
    }

    public virtual void Fire() {

        if (fireDelegate != null)
            fireDelegate();
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

    void OnCollisionEnter(Collision collider)
    {
        GameObject other = collider.gameObject;

        if (other.tag == "ProjectileHero")
        {
            Projectile p = other.GetComponent<Projectile>();
            health -= Main.W_DEFS[p.type].damageOnHit;

            //Debug.Log(Main.W_DEFS[p.type]);

            Destroy(other);

            if (health < 0)
            {
                Die(); 
            }
        }
    }

    public void Die()
    {
        deathPS.Play();
        Main.S.ShipDestroyed(this);
        Destroy(this.gameObject, 0.7f);
		ScoreManager.SM.addScore(score);
    }

}