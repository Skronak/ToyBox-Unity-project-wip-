using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehiculeAIWithWait : MonoBehaviour {

	public 	float moveSpeed;

	private Rigidbody2D myRigidBody;

	public bool isWalking;
	public float waitTime;
	private float waitCounter;
	public bool isWalkingRight;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
		waitCounter = waitTime;
	}

	// Update is called once per frame
	void Update () {
        if (isWalking)
        {
            if (isWalkingRight)
            {
                myRigidBody.velocity = new Vector2(moveSpeed, 0);
            }
            else
            {
                myRigidBody.velocity = new Vector2(-moveSpeed, 0);
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            myRigidBody.velocity = Vector2.zero;
            if (waitCounter < 0)
            {
                isWalking = true;
                waitCounter = waitTime;

            }
        }
	}


	//Detect collision with trigger element   
 	private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("vehicule");
        switch (other.gameObject.tag){
            case "stopTrigger":
                if (!isWalkingRight)
                {
                    Stop();
                }
                break;
            case "borderTrigger":
                ChangeDirection();
                break;
        }
    }
	
    private void Stop()
    {
        isWalking = false;
        waitCounter = waitTime;
    }

	// Change Vehicule direction
	public void ChangeDirection() {
		isWalkingRight = !isWalkingRight;
		isWalking = true;
		if (isWalkingRight) {
             transform.localRotation = Quaternion.Euler(0, 0, 0);
         } else {
             transform.localRotation = Quaternion.Euler(0, 180, 0);
         }
	}
}
