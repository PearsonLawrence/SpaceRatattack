using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Follow_Mouse : MonoBehaviour {

    private Vector3 MousePos;
    public Image CursorHolder;
	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Confined;
    }
	
    public void ForwardToMousePosition()
    {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        ImageFollowMouse(MousePos);
        MousePos.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
        MousePos = Camera.main.ScreenToWorldPoint(MousePos); // Vector 3

        Vector3 AngleBetween = -(transform.position - MousePos).normalized;
        Vector3 Desired = Vector3.Slerp(transform.forward, AngleBetween, .5f);
      
        transform.forward = new Vector3(Desired.x,0,Desired.z);
        
    }

    public void ImageFollowMouse(Vector2 MPos)
    {
        CursorHolder.rectTransform.position = MPos;
    }

	// Update is called once per frame
	void FixedUpdate () {

        MousePos = Input.mousePosition; // Vector 2
        ForwardToMousePosition();
       
    }
}
