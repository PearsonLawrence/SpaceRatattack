using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller_Main: MonoBehaviour {

    //this script should move the player, increase the health when the player hits a gem, and not let health go over 5
    private Rigidbody RB;
    public float Speed = 100.0f;
    float DT;
    bool FirePressed, SpecialFirePressed;
    public DefaultWeaponController CurrentWeapon;
    private int count;
    public Text countText;
    public Text dieText;


	// Use this for initialization
	void Start () { 

        RB = GetComponent<Rigidbody>();
        count = 5;
        SetCountText();
        //dieText.text = "";

	}

    public void MovementFunction()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        Vector3 Movement = new Vector3(Horizontal, 0, Vertical);

        RB.AddForce(Movement * Speed * DT);
    }

	// Update is called once per frame
	void Update ()
    {
        DT = Time.deltaTime;
        FirePressed = Input.GetMouseButton(0);
        SpecialFirePressed = Input.GetMouseButton(1);

        MovementFunction();

        CurrentWeapon.Fire(DT, FirePressed);
        CurrentWeapon.FireSpecialWeapon(DT, SpecialFirePressed);
	}

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up") && count < 5)
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }

      
    }

    void SetCountText()
    {
    //    countText.text = "Health = " + count.ToString() + "/5";
    //    if (count <= 0)
    //    {
    //        dieText.text = "You Lose";
    //    }
    }
      

    
}
