using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationController : MonoBehaviour {

    public float speed;
	
	// Update is called once per frame
	void Update () {
		if(Input.acceleration != Vector3.zero)
        {
            Vector3 acc = -Input.acceleration;
            acc.x *= Time.deltaTime * speed;
            transform.Rotate(0,0, acc.x);
        }
	}
}
