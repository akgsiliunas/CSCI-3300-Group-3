using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {
	static public Hero S;
	public float speed=30;
	public float rollMult = -45;
	public float pitchMult = 30;

    [SerializeField]
    private float _shieldLevel=1;

    public int playerNumber;

	public bool _____________;
	public delegate void WeaponFireDelegate();
	public WeaponFireDelegate fireDelegate;

	void Awake(){
		S = this;
	}
	
	void Update () {
		float xAxis = Input.GetAxis ("Horizontal");
		float yAxis = Input.GetAxis ("Vertical");

        //Debug.Log(xAxis);

		Vector3 pos = transform.position;
		pos.x += xAxis * speed * Time.deltaTime;
		pos.y += yAxis * speed * Time.deltaTime;
		transform.position = pos;


		transform.rotation = Quaternion.Euler (yAxis * pitchMult, xAxis * rollMult, 0);

        if (Input.GetAxis("Jump") == 1 && fireDelegate != null)
        {
            fireDelegate();
        }
    }


    void OnTriggerEnter(Collider other)
    {
        GameObject rootGameObject = Utils.FindTaggedParent(other.gameObject);

        if (rootGameObject.tag == "Enemy")
        {
            shieldLevel--;
            Destroy(rootGameObject);
        }
    }

    public float shieldLevel
    {
        get
        {
            return (_shieldLevel);
        }
        set
        {
            _shieldLevel = Mathf.Min(value, 4);
            if (value < 0)
            {
                Destroy(this.gameObject);
            }
        }
    }



}
