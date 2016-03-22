using UnityEngine;
using System.Collections;

public class Rotor : MonoBehaviour {

    // Use this for initialization
    void Start() {



    }

    // Update is called once per frame
    void Update() {

        //transform.RotateAround(Vector3.zero, Vector3.up, OrbitSpeed * Time.deltaTime);

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.transform.root.tag == "Hero")
            other.transform.root.SetParent(transform);
    }
    

    void OnTriggerStay(Collider other)
    {

        //Debug.Log(other.name);
       

        if (other.transform.root.tag == "Hero")
        {
            //Debug.Log(other.transform.root.name);
            //other.transform.root.Rotate(new Vector3(0f,0f,0.09f));

            //other.transform.root.SetParent(transform);
        }


      //  if (other.transform.parent.tag == "Hero")
      //      other.transform.parent = transform;


    }

    
    void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.tag == "Hero")
            other.transform.parent.SetParent(null);


    }
    

}
