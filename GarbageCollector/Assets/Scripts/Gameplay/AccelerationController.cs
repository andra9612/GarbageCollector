using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxelerationTester : MonoBehaviour {
    private float minStep = 1f/60f;
    private float maxStep = 1f;
    public float speed;

    private float LowPassFilterFactor; 
    private Vector3 lowPassValue = Vector3.zero;

    private void Start()
    {
        LowPassFilterFactor = minStep / maxStep;
    }

    // Update is called once per frame
    void Update () {
		if(Input.acceleration != Vector3.zero)
        {
            lowPassValue = -Vector3.Lerp(lowPassValue, Input.acceleration, LowPassFilterFactor);
            Vector3 acc = -Input.acceleration;
            lowPassValue.x *= Time.deltaTime * speed;
            transform.Rotate(0,0, lowPassValue.x);
        }
	}
}
