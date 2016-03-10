using UnityEngine;
using System.Collections;

public class EnemyHitBox : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.root.tag == "Enemy")
        {
            Core.C.Damage(collider.transform.root.GetComponent<Enemy>().collideDamage);
            collider.transform.root.GetComponent<Enemy>().Die();
        }
    }
}
