using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class rollingpractice : MonoBehaviour {
    Rigidbody rb;
    public GameObject target;
	// Use this for initialization
	void Start () {

        rb = gameObject.GetComponent<Rigidbody>();
        float xdistance = target.transform.position.x - gameObject.transform.position.x;
        float ydistance = target.transform.position.y - gameObject.transform.position.y;
        float zdistance = target.transform.position.z - gameObject.transform.position.z;

        Fire(xdistance, 0, zdistance);

        float horDistance = (float)Math.Sqrt(xdistance * xdistance + ydistance * ydistance);
        Debug.Log("HorDistance: " + horDistance);
        float horVelocity = (float)Math.Sqrt(rb.velocity.x * rb.velocity.x+rb.velocity.z*rb.velocity.z);
        Debug.Log("HorVelocity: " + horVelocity);

        float time = horDistance / horVelocity;
        Debug.Log("time: "+ time);
        float accel = -9.8f;
        float initial = (ydistance - 0.5f * accel * time * time) / time;
        Debug.Log("Initial velo is " + initial);
        Fire(xdistance, initial, zdistance);






       // rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + 20, rb.velocity.z);
	}
	void Fire(float x, float y, float z)
    {
        rb.velocity = new Vector3(x, y, z);

    }
	// Update is called once per frame
	void Update () {
		
	}
}
