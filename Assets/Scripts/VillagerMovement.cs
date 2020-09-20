﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour
{

	public float moveSpeed;
	private Rigidbody2D  myRigidBody;
	public bool isWalking;
	public float walkTime;
	public float waitTime;
	private float walkCounter;
	private float waitCounter;

	private int  walkDirection;

	public Collider2D walkZone;
	private Vector2 minWalkPoint;
	private Vector2 maxWalkPoint;
	private bool hasWalkZone;

	public bool canMove;
	private DialogueManager theDM;

    // Start is called before the first frame update
    void Start()
    {
    	theDM = FindObjectOfType<DialogueManager>();
    	myRigidBody = GetComponent<Rigidbody2D>();    
    	walkCounter = walkTime;
    	waitCounter = waitTime;
    	ChooseDirection();

    	if(walkZone != null)
    	{
	    	minWalkPoint = walkZone.bounds.min;
	    	maxWalkPoint = walkZone.bounds.max;
	    	hasWalkZone = true;
    	}

    	canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
    	if(!theDM.dialogActive)
    	{
			 canMove = true;
    	}

    	if(!canMove)
    	{
    		myRigidBody.velocity = Vector2.zero;
    		return;
    	}

        if(isWalking)
        {
    		walkCounter -= Time.deltaTime;



    		switch(walkDirection)
    		{
    			case 0:
					myRigidBody.velocity = new Vector2(0, moveSpeed); 
					if(hasWalkZone && transform.position.y > maxWalkPoint.y)
					{
		    			isWalking = false;
    					waitCounter = waitTime;
					}
					break;
    			case 1:
					myRigidBody.velocity = new Vector2(moveSpeed, 0);
					if(hasWalkZone && transform.position.x > maxWalkPoint.x)
					{
		    			isWalking = false;
    					waitCounter = waitTime;
					}
					break;
    			case 2:
					myRigidBody.velocity = new Vector2(0, -moveSpeed);
					if(hasWalkZone && transform.position.y < maxWalkPoint.y)
					{
		    			isWalking = false;
    					waitCounter = waitTime;
					}					
					break;
    			case 3:
    				myRigidBody.velocity = new Vector2(-moveSpeed, 0);
					if(hasWalkZone && transform.position.x < maxWalkPoint.x)
					{
		    			isWalking = false;
    					waitCounter = waitTime;
					}    				
    				break;
    		}


    		if(walkCounter < 0)
    		{
    			isWalking = false;
    			waitCounter = waitTime;
    		}
        }
        else
        {
        	waitCounter -= Time.deltaTime;
        	myRigidBody.velocity = Vector2.zero;

        	if(waitCounter < 0)
        	{
        		ChooseDirection();
        	}
        }
    }

    public void ChooseDirection()
    {
    	walkDirection = Random.Range(0, 4);
    	isWalking = true;
    	walkCounter = walkTime;
    }
}
