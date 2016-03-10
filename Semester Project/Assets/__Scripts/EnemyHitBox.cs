using UnityEngine;
using System.Collections;

public class EnemyHitBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.root.tag == "Enemy")
        {
            Core.C.Damage(collider.transform.root.GetComponent<Enemy>().collideDamage);

            collider.transform.root.GetComponent<Enemy>().Die();


            //Destroy(collider.transform.root.gameObject);
        }
            

    }
}
