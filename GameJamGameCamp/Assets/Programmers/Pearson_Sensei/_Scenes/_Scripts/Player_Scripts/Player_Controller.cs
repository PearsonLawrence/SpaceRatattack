using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller: MonoBehaviour {

    private Rigidbody RB;
    public float Speed = 100.0f;
    float DT;
    bool FirePressed;
    public DefaultWeaponController CurrentWeapon;

	// Use this for initialization
	void Start () { 

        RB = GetComponent<Rigidbody>();

	}

    public void MovementFunction()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        Vector3 Movement = new Vector3(Horizontal, 0, Vertical);

        RB.AddForce(Movement * Speed * DT);
    }

	// Update is called once per frame
	void Update () {
        DT = Time.deltaTime;
        FirePressed = Input.GetMouseButton(0);
        MovementFunction();
        CurrentWeapon.Fire(DT, FirePressed); 
	}
}
