using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

    public Vector3 newRotation;

	void Start () {

        //newRotation = transform.rotation.eulerAngles;

       // Debug.Log(newRotation);

    }
	

    void OnTriggerStay(Collider other)
    {
        //Debug.Log("Something in me");

        if (other.transform.root.tag == "Hero")
        {

            Debug.Log("In here!");

            //other.transform.root.Rotate(Vector3.right * Time.deltaTime);
            //other.transform.root.Rotate(new Vector3(0,0,-1000) * Time.deltaTime);

            other.transform.root.rotation = Quaternion.Euler(newRotation);

        }




    }

}
