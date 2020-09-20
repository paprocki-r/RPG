using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float moveSpeed;
	private float currentMoveSpeed;

	private Animator anim;
	private Rigidbody2D myRigidbody;
	private bool playerMoving;
	public Vector2 lastMove;

	private static bool playerExists;

	private bool attacking;
	public float attackTime;
	private float attackTimeCounter;

	public string startPoint;
	public bool canMove;

	private Vector2 moveInput;

	private SFXManager sfxMan;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        sfxMan = FindObjectOfType<SFXManager>();

        if(!playerExists)
        {
        	playerExists = true;
        	DontDestroyOnLoad(transform.gameObject);
        }
        else{
        	Destroy(gameObject);
        }
    	canMove = true;
    	lastMove = new Vector2(0, -1f); //when started face down


    }

    // Update is called once per frame
    void Update()
    {
    	playerMoving = false;

    	if(!canMove)
    	{
    		myRigidbody.velocity = Vector2.zero;
    		return;
    	}

    	if(!attacking)
    	{


    		moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    		if(moveInput != Vector2.zero)
    		{
    			myRigidbody.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
    			playerMoving = true;
    			lastMove = moveInput;
    		}
    		else
    		{
    			myRigidbody.velocity = Vector2.zero;
    		}

	        if(Input.GetKeyDown(KeyCode.J))
	        {
	    		attackTimeCounter = attackTime;
	    		attacking = true;
	    		myRigidbody.velocity = Vector2.zero;
		    	anim.SetBool("Attack", true);

		    	sfxMan.playerAttack.Play();
	        }



		}

		if(attackTimeCounter>0)
		{
			attackTimeCounter -= Time.deltaTime;
		}

		if(attackTimeCounter<=0)
		{
			attacking = false;
			anim.SetBool("Attack", false);
		}

        anim.SetFloat("MoveX",Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY",Input.GetAxisRaw("Vertical"));
    	anim.SetBool("PlayerMoving", playerMoving);
    	anim.SetFloat("LastMoveX", lastMove.x);
    	anim.SetFloat("LastMoveY", lastMove.y);

    }
}

