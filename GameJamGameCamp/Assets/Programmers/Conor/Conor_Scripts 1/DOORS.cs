using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOORS : MonoBehaviour {

    public GameObject DoorButton;
    public GameObject Door, Door2;
    public float smooth;
    private bool touchingDOOR = false;
    public bool Open;
    private Vector3 DoorOpen, Door2Open;
    private Vector3 DoorClosed, Door2Closed;
    bool runonce = true;
	void Start () {
        
       // DoorButton = GameObject.Find("Door Button");
        //DoorButton.SetActive(false);
        
    }

    private void Update()
    {
        if(runonce)
        {
            DoorOpen = -Door.transform.right;
            DoorClosed = Door.transform.forward;

            Door2Open = Door2.transform.right;
            Door2Closed = Door2.transform.forward;
            runonce = false;
        }
        if(Open)
        {

            Door.transform.forward = Vector3.Slerp(Door.transform.forward, DoorOpen, smooth);

            Door2.transform.forward = Vector3.Slerp(Door2.transform.forward, Door2Open, smooth);
            //Debug.Log("Door Opened");

        }
        else
        {

            Door.transform.forward = Vector3.Slerp(Door.transform.forward, DoorClosed, smooth);

            Door2.transform.forward = Vector3.Slerp(Door2.transform.forward, Door2Closed, smooth);
            //Debug.Log("Door Opened");

        }
    }

    bool autoDetect = false;

    private void OnCollisionEnter(Collision collision)
    {
       
    }
    // Update is called once per frame
    void OnTriggerStay (Collider other)
    {

        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            if (Open != true)
            {
                Open = true;
            }
            autoDetect = true;
        }



    }

    void OnTriggerExit(Collider other)
    {
        Open = false;
    }
}


