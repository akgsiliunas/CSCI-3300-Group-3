﻿using UnityEngine;
using System.Collections;

public class KillBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter(Collider victim)
    {

        //Debug.Log(victim.tag);

        if (victim.tag == "Projectile Enemy")
            Destroy(victim);

        if (victim.transform.root.tag == "Enemy")
            Destroy(victim.transform.root.gameObject);


    }


}
