using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float damageAmount;
    public GameObject Parent;
    public string ParentName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if((other.GetComponent<Health_Component>() != null) && other.tag != ParentName )
        {
            other.GetComponent<Health_Component>().AddDamage(damageAmount);
            Destroy(Parent);
            return;
        }

        if(other.CompareTag("Boss") && other.tag != ParentName)
        {
            other.GetComponent<Boss_Health_Component>().AddDamage(damageAmount);
            Destroy(Parent);
            return;
        }
        if (other.CompareTag("Prop"))
        {
            Destroy(Parent);
        }
    }

}
