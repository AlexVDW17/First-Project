using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArrowLauncher : MonoBehaviour {
    public GameObject arrow;
    //shouldnt need the following line but it gives me easy access to the transform so oh well
    public GameObject target;
    public GameObject bow;
    float xdif;
    float zdif;
    float ydif;
    double theta;

    Rigidbody body;
        
	// Use this for initialization
	void Start () {
        
        xdif = GetXDif(bow, target);
        ydif = GetYDif(bow, target);
        zdif = GetZDif(bow, target);
        theta = Math.Atan((xdif/ydif));
        GameObject newArrow = GameObject.Instantiate(arrow);
        newArrow.transform.position = gameObject.transform.position;
        body = newArrow.GetComponent<Rigidbody>();
        double distance = Math.Sqrt(xdif * xdif + zdif * zdif);

        FireX(newArrow);
        
       // Rigidbody body = newArrow.GetComponent<Rigidbody>();
        Debug.Log(body.velocity.x);
        double horizontalVelo = Math.Sqrt(body.velocity.x * body.velocity.x + body.velocity.z * body.velocity.z);
        double time = distance / horizontalVelo;
        double accel = 1;
        double height = target.transform.position.y - gameObject.transform.position.y;
        float vf = (float)((height +(1/2) * accel *time*time)/ time);
        Debug.Log("the time is " + time);
        Debug.Log("the distance is "+ distance+ "\nthe horizontal velo is "+horizontalVelo+"\nthe vert velocity is "+ vf);
        //body.AddForce(new Vector3(0,vf,0) , ForceMode.VelocityChange);
        body.velocity = new Vector3(body.velocity.x, body.velocity.y + vf, body.velocity.z);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public float forceMultiplier;
    void FireX(GameObject currentArrow)
    {
      //Rigidbody body = currentArrow.gameObject.GetComponent<Rigidbody>();
        Vector3 dir = new Vector3(xdif*forceMultiplier,0f, zdif*forceMultiplier);
        //body.AddForce(dir, ForceMode.VelocityChange);
        body.velocity = new Vector3(body.velocity.x+xdif*forceMultiplier, body.velocity.y, body.velocity.z+zdif*forceMultiplier);
        Debug.Log("here the velocity is " + body.velocity.x);

    }

    float GetYDif(GameObject currentBow, GameObject currentTarget)
    {
        float y = currentTarget.transform.position.y - currentBow.transform.position.y;
        return y;
    }
    float GetZDif(GameObject currentBow, GameObject currentTarget)
    {
        float z = currentTarget.transform.position.z - currentBow.transform.position.z;
        return z;
    }
    float GetXDif(GameObject currentBow, GameObject currentTarget)
    {
        float x = currentTarget.transform.position.x - currentBow.transform.position.x;
        return x;
    }
}
