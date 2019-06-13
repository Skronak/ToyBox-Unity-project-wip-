using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehiculeMovement : MonoBehaviour {

	public 	float moveSpeed;

	private Rigidbody2D myRigidBody;

	public bool isWalking;
	public float walkTime;
	private float walkCounter;
	public float waitTime;
	private float waitCounter;
	public bool isWalkingRight;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
		waitCounter = waitTime;
		walkCounter = walkTime;

	}

	// Update is called once per frame
	void Update () {
		if (isWalking) {
			walkCounter -= Time.deltaTime;
			if (isWalkingRight) {
				myRigidBody.velocity = new Vector2(moveSpeed,0);
			} else {
				myRigidBody.velocity = new Vector2(-moveSpeed,0);
			}
			if(walkCounter<0) {
				isWalking=false;
				walkCounter=waitTime;
			}	
			
		} else {
			waitCounter -= Time.deltaTime;
			myRigidBody.velocity = Vector2.zero;
			if (waitCounter<0) {
				ChangeDirection();
			}
		}
	}

	public void ChangeDirection() {
		isWalkingRight = !isWalkingRight;
		isWalking = true;
		walkCounter = walkTime;
		if (isWalkingRight) {
             transform.localRotation = Quaternion.Euler(0, 0, 0);
         } else {
             transform.localRotation = Quaternion.Euler(0, 180, 0);
         }
	}
}
