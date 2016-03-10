using UnityEngine;
using System.Collections;

public class RegeneratorHitBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {

        //Debug.Log(collider.tag);

        GameObject other = collider.gameObject;

        if (other.tag == "ProjectileEnemy")
        {
            Destroy(other);
        }

    }


}
