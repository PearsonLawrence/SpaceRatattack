using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour {

   

    private GameObject Player;
    private Vector3 Offset;
    float DT;
	// Use this for initialization
	void Start () {

        Player = GameObject.FindGameObjectWithTag("Player"); // Finds the gameobject with 
        Offset = transform.position;

	}
	
	// Update is called once per frame
	void LateUpdate () {
        DT = Time.deltaTime;
        Vector3 DesiredPostion = new Vector3(Player.transform.position.x, Offset.y, Player.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, DesiredPostion, .1f);

	}
}
