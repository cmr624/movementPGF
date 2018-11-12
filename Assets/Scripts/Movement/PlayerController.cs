using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Motor))]
[RequireComponent(typeof(ZeroG))]
public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private Motor motor;
    private CameraController cc;
    public float jumpSpeed;
    public float movementSpeed;
    private bool isGrounded;

    private ZeroG zeroG;
    //number of jumps allowed
    public int numberOfJumps;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        isGrounded = false;
        zeroG = GetComponent<ZeroG>();
        motor = GetComponent<Motor>();

    }

    //Don't allow double jump, not working
    void OnCollisionStay (Collision collision) {
        isGrounded = true;
    }

    //FixedUpdate - Physics
    void FixedUpdate()
    {
        
        if (Input.GetKeyDown( KeyCode.Space) && isGrounded)
        {
            motor.Jump(jumpSpeed);
            isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            zeroG.MoveInZeroG();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            zeroG.Reset();
        }
        motor.Move(movementSpeed);


    }

}
