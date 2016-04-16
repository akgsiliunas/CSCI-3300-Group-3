using UnityEngine;
using System.Collections;

[System.Serializable]
public class EnemySpawnDefinition
{
    public GameObject enemyPrefab;
    public int spawnProbability;
}

public class Enemy : MonoBehaviour
{


    public float speed = 2.0f * UIManager.UM.DiffLevel;
    public float fireRate = 0.3f * UIManager.UM.DiffLevel;
    public float health = 10 * UIManager.UM.DiffLevel;
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

    public delegate void BossCountDelegate();
    public BossCountDelegate bossCountDelegate;

    private bool isDead = false;

    public virtual void Start()
    {
        //Debug.Log("speed: " + this.speed);
        deathPS.Pause();
        Orient();
        //FreezeContraints();
        //Debug.Log("health: " + health);
        //Debug.Log("Rate: " + fireRate);
    }

    public virtual void Fire() {

        if (fireDelegate != null)
            fireDelegate();
    }

    void Update()
    {
       // Debug.Log(movement);
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
                Debug.Log("I made it to death");
                Main.S.ShipDestroyed(powerUpDropChance, this.transform.position);
                isDead = true;
            }
        }
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