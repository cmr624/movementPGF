using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroG : MonoBehaviour {

    [HideInInspector]
    public bool inZeroG = false;
    private float originalDrag = 0f;
    private float originalAngularDrag = 0f;
    public float zeroGravDrag = 0f;
    public float zeroGravAngularDrag = 0f;
    private Rigidbody rb;
	
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        originalDrag = rb.drag;
        originalAngularDrag = rb.angularDrag;
	}

    void FixedUpdate()
    {
        if(inZeroG)
        {
            Move();
        }
    }
    public void MoveInZeroG(){
        rb.useGravity = false;
        rb.drag = zeroGravDrag;
        rb.angularDrag = zeroGravAngularDrag;
        inZeroG = true;
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        bool z = Input.GetKey(KeyCode.Space);
        Vector3 moveVertical = Vector3.zero;
        if (z)
        {
            moveVertical = transform.up * 1.0f;
        }
        else
        {
            moveVertical = transform.up * 0.0f;
        }
        Vector3 moveHorizontal = transform.right * x;
        Vector3 velocity = (moveHorizontal + moveVertical).normalized * GetComponent<Controller>().movementSpeed;
        if (velocity != Vector3.zero)
        {
            rb.AddForce(rb.position + velocity, ForceMode.Impulse);
        }
    }
    public void Reset()
    {
        rb.useGravity = true;
        rb.drag = originalDrag;
        rb.angularDrag = originalAngularDrag;
        inZeroG = false;
    }
}
