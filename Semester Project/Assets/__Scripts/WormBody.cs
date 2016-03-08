using UnityEngine;
using System.Collections;

public class WormBody : MonoBehaviour
{

    void OnCollisionEnter(Collision collider)
    {
        GameObject other = collider.gameObject;

        if (other.tag == "ProjectileHero")
        {
            this.transform.root.GetComponent<Enemy_3>().GatherHit(other);
            Destroy(other);
        }
    }
}