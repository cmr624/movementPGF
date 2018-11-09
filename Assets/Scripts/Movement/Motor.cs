using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour {
    private Rigidbody rb;
    private Vector3 velocity;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}

    private void FixedUpdate()
    {
        DoMovement(velocity);
    }
    public void Move(float movementSpeed)
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 moveHorizontal = transform.right * x;
        Vector3 moveVertical = transform.forward * z;

        velocity = (moveHorizontal + moveVertical).normalized * movementSpeed;
    } 
    private void DoMovement(Vector3 velocity)
    {
        if (velocity != Vector3.zero){
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }
    }
    public void Jump(float jumpSpeed)
    {
        rb.AddForce(new Vector3(0f, jumpSpeed, 0f), ForceMode.Impulse);
    }
}
