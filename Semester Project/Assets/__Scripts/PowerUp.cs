using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PowerUp : MonoBehaviour {


    public Vector2 rotMinMax = new Vector2(15, 90);
    //public Vector2 driftMinMax = new Vector2(.25f, 2);
    public float lifeTime = 6f;
    public float fadeTime = 4f;

    public bool __________________;

    public WeaponType type;
    public GameObject cube;
    // public TextMesh letter;
    private GameObject weaponGraphic;

    public GameObject weaponGraphicTransform;

    public Vector3 rotPerSecond;
    public float birthTime;

    void Awake()
    {
        //cube = transform.Find("Cube").gameObject;

        //letter = GetComponent<TextMesh>();

        //Vector3 vel = Random.onUnitSphere;

        //vel.z = 0;
        //vel.Normalize();
        //vel *= Random.Range(driftMinMax.x, driftMinMax.y);

        //GetComponent<Rigidbody>().velocity = vel;

        transform.rotation = Quaternion.identity;

        rotPerSecond = new Vector3(Random.Range(rotMinMax.x, rotMinMax.y), Random.Range(rotMinMax.x, rotMinMax.y), Random.Range(rotMinMax.x, rotMinMax.y));

        //InvokeRepeating("CheckOffscreen", 2f, 2f);

        birthTime = Time.time;
    }

	void Update () {

        cube.transform.rotation = Quaternion.Euler(rotPerSecond * Time.time);

        float u = (Time.time - (birthTime + lifeTime)) / fadeTime;

        if (u >= 1)
        {
            Destroy (this.gameObject);
            return;
        }

        if (u > 0)
        {
            // USE FADE ALL CHILDREN CODE FROM CAPSTONE
        }
	}

    public void SetType( WeaponType wt)
    {
        WeaponDefinition def = Main.GetWeaponDefinition(wt);
        //letter.text = def.letter;

        weaponGraphic = def.weaponGraphic;
        GameObject clone = Instantiate(weaponGraphic, weaponGraphicTransform.transform.position, weaponGraphicTransform.transform.rotation) as GameObject;


        clone.transform.parent = weaponGraphicTransform.transform.parent;

        clone.transform.position = weaponGraphicTransform.transform.position;
 
        type = wt;
    }

    public void AbsorbedBy (GameObject target)
    {
        Destroy(this.gameObject);
    }






}
