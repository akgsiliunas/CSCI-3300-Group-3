using UnityEngine;
using System.Collections;

public class RegeneratorHitBox : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {
        GameObject other = collider.gameObject;

        if (other.tag == "ProjectileEnemy" || other.tag == "ProjectileHero")
            Destroy(other);
    }

}
