using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapHitboxController : MonoBehaviour {
    public float damageAmount = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Health_Component>() != null)
        {
            other.GetComponent<Health_Component>().AddDamage(damageAmount);
        }
    }
}
