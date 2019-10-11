using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianAI : MonoBehaviour
{
    public float moveSpeed;

    public bool isWalking;
    public bool isWalkingRight;
    private Rigidbody2D myRigidBody;

    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            if (isWalkingRight)
            {
                myRigidBody.velocity = new Vector2(moveSpeed, 0);
//                myRigidBody.AddForce(new Vector2(moveSpeed, 0), ForceMode2D.Impulse);
            }
            else
            {
                myRigidBody.velocity = new Vector2(-moveSpeed, 0);
            }
        }
    }


    //Detect collision with trigger element   
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Pedstrian");
        switch (other.gameObject.tag)
        {
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

    private void OnTriggerStay2D(Collider2D collision)
    {
    }

    private void Stop()
    {
        isWalking = false;
    }

    private void Run()
    {
        isWalking = true;
    }

    // Change Vehicule direction
    public void ChangeDirection()
    {
        isWalkingRight = !isWalkingRight;
        isWalking = true;
        if (isWalkingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}

