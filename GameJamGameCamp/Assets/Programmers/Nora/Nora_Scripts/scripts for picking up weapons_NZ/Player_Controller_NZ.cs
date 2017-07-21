using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller_NZ : MonoBehaviour
{

    private Rigidbody RB;
    public float Speed = 100.0f;
    float DT;

    public string CurrentSpecialWeapon;
    public string SetSpecialWeapon;

    // Use this for initialization
    void Start()
    {
        RB = GetComponent<Rigidbody>();
       // GetComponent.NeedsReset; need to get the bool 'NeedsReset' from weapons_respawn_controller script
        
    }

    public void MovementFunction()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        Vector3 Movement = new Vector3(Horizontal, 0, Vertical);

        RB.AddForce(Movement * Speed * DT);
    }

    // Update is called once per frame
    void Update()
    {
        DT = Time.deltaTime;
        SetSpecialWeapon = CurrentSpecialWeapon;
        MovementFunction();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Special1"))
        {
            other.gameObject.SetActive(false);
           // NeedsReset == true;
        }

    }
}
//Destroy(other.gameObject);