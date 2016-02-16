using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Platform : MonoBehaviour {

    public Vector3 newRotation;
	
    void OnTriggerStay(Collider other)
    {
        if (other.transform.root.tag == "Hero")
        {
           // other.transform.root.DORotateQuaternion(Quaternion.Euler(newRotation), 0.5f);

            other.transform.root.DORotate(newRotation, 0.5f);

            //other.transform.root.DoRo
            //other.transform.root.rotation = Quaternion.Euler(newRotation);
        }
    }

}
