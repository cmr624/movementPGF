﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The Zero Gravity script
 * Basically, it has two methods, MoveInZeroG and Reset, where if you drop out of
 * Zero G gravity is reapplied and regular physics calculations for the motor take over
 * This is a momentum / acceleration based movement, contrary to the motor movement which is position based
 * using rb.MovePosition.
 * Can also set the drag and thrust as public variables (eventually powerups)
 */
public class ZeroG : MonoBehaviour {

    [HideInInspector]
    public bool inZeroG = false;

    //private drag variables to save old state
    private float originalDrag = 0f;
    private float originalAngularDrag = 0f;

    //public boys and girls
    public float zeroGravDrag = 0f;
    public float zeroGravAngularDrag = 0f;

    //zero g thrust
    public float thrust = 1.0f;

    private Rigidbody rb;
    private Vector3 velocity;
    private Camera cam;
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>(); 
        originalDrag = rb.drag;
        originalAngularDrag = rb.angularDrag;
	}

    //idk how to get fixedUpdate to work within a separate code, so I just have the boolean determine when to do it ?
    private void FixedUpdate()
    {
        if (inZeroG)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");
            //regular x movement
            Vector3 moveHorizontal = transform.right * x;

            //move in the direction you're facing
            Vector3 moveVertical = Camera.main.transform.forward * z;

            //move vertically using the jump button (pharah-esque ??)
            Vector3 moveUp = transform.up * (Input.GetButton("Jump") ? 1 : 0);
            
            //calculate velocity
            velocity = (moveHorizontal + moveVertical + moveUp).normalized * thrust;
            
            //unsure about forcemode here? acceleration seems to be a good boy?
            rb.AddForce(velocity, ForceMode.Acceleration);
        }

    }

    //basic variable setting for use in ZeroG
    public void MoveInZeroG(){
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        rb.drag = zeroGravDrag;
        rb.angularDrag = zeroGravAngularDrag;
        inZeroG = true;
    }

    //set those variables back
    public void Reset() 
    {
        rb.useGravity = true;
        rb.drag = originalDrag;
        rb.angularDrag = originalAngularDrag;
        inZeroG = false;
    }
}
