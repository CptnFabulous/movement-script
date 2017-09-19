using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public GameObject head;
    Vector3 movementValue;
    Rigidbody rb;

    float moveFB;
    float strafeLR;
    float jumpUD;
    public float speedWalk;
    public float forceJump;

    float lookHorizontal;
    float lookVertical;
    public float sensitivityX;
    public float sensitivityY;


	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        moveFB = Input.GetAxis("Vertical") * speedWalk;
        strafeLR = Input.GetAxis("Horizontal") * speedWalk;

        Jump();

        movementValue = new Vector3(strafeLR, 0, moveFB);
        movementValue = transform.rotation * movementValue;

        lookHorizontal = Input.GetAxis("Mouse X") * sensitivityX;
        lookVertical = Input.GetAxis("Mouse Y") * -sensitivityY;
        transform.Rotate(0, lookHorizontal, 0);
        head.transform.Rotate(lookVertical, 0, 0);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpUD = forceJump;
        }
    }

    void FixedUpdate ()
    {
        /*
        rb.AddForce(movementValue * speedWalk);
        if (jumpUD > 0)
        {
            jumpUD = 0;
        }
        */

        rb.AddForce(movementValue * speedWalk);
        rb.AddForce(transform.up * jumpUD * 10);
        if (jumpUD > 0)
        {
            jumpUD = 0;
        }
        
    }
}
