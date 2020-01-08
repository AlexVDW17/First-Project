using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryingToGetWMRInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.rotation=  Input.gyro.attitude;
        Rigidbody rb =gameObject.GetComponent<Rigidbody>();
        rb.AddForce(Input.gyro.userAcceleration, ForceMode.Force);
	}
}
