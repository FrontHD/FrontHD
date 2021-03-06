﻿using UnityEngine;

public class CharacterController : MonoBehaviour {
    public float inputDelay = 0.1f;
    public float forwardVel = 12;
    public float rotateVel = 100;

    Quaternion targetRotation;
    Rigidbody rBody;
    float forwardInput, turnInput;

    public Quaternion TargetRotation { get { return targetRotation; } }

    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    private void LateUpdate()
    {
        GetInput();
        Turn();
    }

    private void FixedUpdate()
    {
        Run();
    }

    void Run() {
        if (Mathf.Abs(forwardInput) > inputDelay)
        {
            Vector3 motion = transform.forward * forwardInput * forwardVel;
            rBody.velocity = new Vector3(motion.x, rBody.velocity.y, motion.z); 
        }
        else
        {
            rBody.velocity = new Vector3(0, rBody.velocity.y, 0); // = Vector3.zero;
        }
    }

    void Turn() {
        targetRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
        transform.rotation = targetRotation;
    }

    // Use this for initialization
    void Start() {
        targetRotation = transform.rotation;
        if (GetComponent<Rigidbody>())
            rBody = GetComponent<Rigidbody>();
        else
            Debug.LogError("The character needs a rigid body");
        forwardInput = turnInput = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
