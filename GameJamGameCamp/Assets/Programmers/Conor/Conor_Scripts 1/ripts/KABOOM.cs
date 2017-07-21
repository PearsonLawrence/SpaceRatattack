using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KABOOM : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public GameObject HitBox;
    public MeshRenderer ourmesh;
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {

        if(!other.CompareTag("Player"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            HitBox.SetActive(true);
            ourmesh.enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject, .2f);
        }
        //
    }
}
