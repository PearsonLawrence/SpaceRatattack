using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour {

    public float CurrentHP;
    public GameObject PS;
    public GameObject HitBox;
    public float MaxScale;
	// Use this for initialization
	void Start () {
		
	}

    public void Explosion()//Barrel shrinks,expands, and then deletes itself
    {
        GameObject temp = Instantiate(PS, transform.position, PS.transform.rotation);
        Destroy(temp, 3);
        GetComponent<MeshCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        //transform.localScale -= new Vector3(.1f, .1f, .1f);
        HitBox.transform.localScale += new Vector3(.2f, .2f, .2f);

        HitBox.SetActive(true);

        Destroy(gameObject,.5f);

    }
	
	// Update is called once per frame
	void Update () {
        CurrentHP = GetComponent<Health_Component>().CurrentHealth;
        if (CurrentHP <= 0)
        {

            Explosion();

        }

	}
}
