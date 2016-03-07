using UnityEngine;
using System.Collections;

public class Regenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other)
    {
        if (other.transform.root.tag == "Hero")
            other.transform.root.GetComponent<Player>().RegenShield();
    }
}
