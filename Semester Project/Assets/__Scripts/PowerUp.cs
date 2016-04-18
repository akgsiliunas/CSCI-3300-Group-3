using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PowerUp : MonoBehaviour {

    public float lifeSpan = 6f;
    public float scaleDownTime = 1f;
    private float timeChange = 0f;

    public WeaponType type;
    public GameObject cube;
    private GameObject weaponGraphic;
    public GameObject weaponGraphicTransform;

    public Vector3 rotPerSecond;
    public Vector2 rotMinMax = new Vector2(15, 90);

    public ParticleSystem absorbtion;

    void Awake()
    {
        transform.rotation = Quaternion.identity;
        rotPerSecond = new Vector3(Random.Range(rotMinMax.x, rotMinMax.y), Random.Range(rotMinMax.x, rotMinMax.y), Random.Range(rotMinMax.x, rotMinMax.y));
    }

	void Update () {

        if (timeChange > lifeSpan)
        {
            timeChange = 0f;

            foreach (Transform child in transform)
            {
                if (child.GetComponent<Collider>() != null)
                    child.GetComponent<Collider>().enabled = false;
            }

            transform.DOScale(0f, scaleDownTime);
            Destroy(this.gameObject, scaleDownTime);
        }
        else
            timeChange += Time.deltaTime;


        cube.transform.rotation = Quaternion.Euler(rotPerSecond * Time.time);
	}

    public void SetType( WeaponType wt)
    {
        WeaponDefinition def = Main.GetWeaponDefinition(wt);

        weaponGraphic = def.weaponGraphic;
        GameObject clone = Instantiate(weaponGraphic, weaponGraphicTransform.transform.position, weaponGraphicTransform.transform.rotation) as GameObject;
        clone.transform.parent = weaponGraphicTransform.transform.parent;
        clone.transform.position = weaponGraphicTransform.transform.position;
        clone.transform.parent = clone.transform.root;
 
        type = wt;
    }

    public void AbsorbedBy (GameObject target)
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<Collider>() != null)
                child.GetComponent<Collider>().enabled = false;
            if (child.GetComponent<MeshRenderer>() != null)
                child.GetComponent<MeshRenderer>().enabled = false;
        }

        // Stops bug where graphic's mesh renderer won't turn off. :/
        //transform.DOScale(0f, 0f);

        absorbtion.Play();

        Destroy(this.gameObject, 1f);
    }
}