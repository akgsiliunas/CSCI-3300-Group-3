using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float fireRate = 0.3f;
    public float health = 10;
    public int score = 100;

    public float powerUpDropChance = 1f;

    public bool _____________________;

    public enum Movement { Left, Right, Top, Bottom};

    public Movement movement;

    public Bounds bounds;
    public Vector3 boundsCenterOffset;

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
                Main.S.ShipDestroyed(this);
                Destroy(this.gameObject);
                
            }
        }
    }




    void Awake()
    {
        //InvokeRepeating("CheckOffscreen", 0f, 2f);
    }
    /*
    void CheckOffscreen()
    {
        if (bounds.size == Vector3.zero)
        {
            bounds = Utils.CombineBoundsOfChildren(this.gameObject);
            boundsCenterOffset = bounds.center - transform.position;
        }
        bounds.center = transform.position + boundsCenterOffset;
        Vector3 off = Utils.ScreenBoundsCheck(bounds, BoundsTest.offScreen);
        if (off != Vector3.zero)
        {
            if (off.y < 0)
            {
                Destroy(this.gameObject);
            }
        }

    }
    */
}