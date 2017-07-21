using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up_Health_AM : MonoBehaviour {

    public float ResetTIme;
    float SetResetTime;
    bool ToBeReset;
    private Rigidbody RB;
    public float HealthAmount;
    float DT;
	// Use this for initialization
	void Start () {
        RB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        DT = Time.deltaTime;
        SetResetTime -= DT;
        if(ToBeReset)
        {
            if(SetResetTime <= 0)
            {
                ToBeReset = false;
                GetComponent<MeshRenderer>().enabled = true;
                GetComponent<MeshCollider>().enabled = true;
                SetResetTime = ResetTIme;
            }
        }

	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (other.GetComponent<Health_Component>().CurrentHealth < other.GetComponent<Health_Component>().StartHealth)
            {

                other.GetComponent<Health_Component>().AddHealth(HealthAmount);

                other.GetComponent<Health_Component>().CurrentHealth = Mathf.Clamp(other.GetComponent<Health_Component>().CurrentHealth, -1, other.GetComponent<Health_Component>().StartHealth);

                ToBeReset = true;
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<MeshCollider>().enabled = false;
                SetResetTime = ResetTIme;
            }
        }
    }
}
