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
    private Vector3 velocity;
	
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>(); 
        originalDrag = rb.drag;
        originalAngularDrag = rb.angularDrag;
	}

    public void MoveInZeroG(){
        rb.useGravity = false;
        //rb.velocity = Vector3.zero;
        rb.drag = zeroGravDrag;
        rb.angularDrag = zeroGravAngularDrag;
        inZeroG = true;
    }

    private void Move()
    {
   
    }
    public void Reset() 
    {
        rb.useGravity = true;
        rb.drag = originalDrag;
        rb.angularDrag = originalAngularDrag;
        inZeroG = false;
    }
}
