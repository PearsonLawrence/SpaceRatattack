using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapons_respawn_controller : MonoBehaviour {

    public string DesiredName;
    public float ResetTime, SetResetTime;
    public bool NeedsReset;
    float DT;

	// Use this for initialization
	void Start () {
        SetResetTime = ResetTime;
        NeedsReset = false;

	}

    public void SpawnSpecialWeapon()
    {
        NeedsReset = false;

        GetComponent<MeshCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false; //Need to make the Weapon pickup reappear
    }
	
	// Update is called once per frame
	void Update () {
        DT = Time.deltaTime;

        if (NeedsReset == true)
        {
           if(SetResetTime <= 0)
            {
                SpawnSpecialWeapon();
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GetComponent<MeshCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            other.GetComponent<Player_Controller_Main>().CurrentWeapon.DesiredSpecialWeapon = DesiredName;
            NeedsReset = true;
            SetResetTime = ResetTime;
        }
    }
}
