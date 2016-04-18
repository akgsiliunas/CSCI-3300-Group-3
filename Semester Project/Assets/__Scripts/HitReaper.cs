using UnityEngine;
using System.Collections;

public class HitReaper : MonoBehaviour
{

    void OnCollisionEnter(Collision collider)
    {
        GameObject other = collider.gameObject;

        if (other.tag == "ProjectileHero")
        {
            this.transform.root.GetComponent<Enemy>().GatherHit(other);

            //Destroy(other);

          other.GetComponent<Projectile>().Die();
        }
    }
}