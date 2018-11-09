using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Rigidbody rb;
    public float lookSensitivity = 3.0f;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
    public void Update () {
        float xRot = Input.GetAxisRaw("Mouse X");
        Vector3 xRotation = new Vector3(0f, xRot, 0f) * lookSensitivity;
        rb.MoveRotation(transform.rotation * Quaternion.Euler(xRotation));

        float yRot = Input.GetAxisRaw("Mouse Y");
        Vector3 yRotation = new Vector3(yRot, 0f, 0f) * lookSensitivity;

        Camera.main.transform.Rotate(-yRotation);
    }
}
