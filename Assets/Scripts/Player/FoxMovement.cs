using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class FoxMovement : MonoBehaviour {
	[SerializeField] private LayerMask m_WhatIsGround;       
    
	public float Maxspeed;
	public float JumpForce;
    Vector2 pos;
	private Animator anim;
	private bool flash;

	private bool isClimb;
	private bool isJump;
	private bool isTransformed;
	private bool isUp;
	private bool isDown;
    private Rigidbody2D rb;
	// Use this for initialization

    private float move = 0;
	public bool canClimb;
	private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded;
	private bool m_Grounded = false; 
	private Transform m_CeilingCheck;   // A position marking where to check for ceilings
	const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
	private bool m_FacingRight = true;
	private BoxCollider2D box;
	private CircleCollider2D circle;
    private Transform HumanGroundCheck;
    private Transform HumanCeilingCheck;
    private Transform FoxGroundCheck;
    private Transform FoxCeilingCheck;

	private Vector2 humanBoxSize;
	private Vector2 humanCircleOffset;
	private Vector2 foxBoxSize;
	private Vector2 foxCircleOffset;

    void Awake()
    {
        
		humanBoxSize = new Vector2(0.5f,0.5f);
		humanCircleOffset = new Vector2(0.0f,-0.3f);

		foxBoxSize = new Vector2(0.5f,0.25f);
		foxCircleOffset = new Vector2(0.0f,-0.15f);

          rb = GetComponent<Rigidbody2D>();
          anim = GetComponent<Animator>();
          flash = false;
        
          isClimb = false;
          isJump = false;
          isTransformed = false;
			canClimb = false;
		box =  GetComponent<BoxCollider2D>();
		circle = GetComponent<CircleCollider2D>();


        HumanGroundCheck = transform.Find("HumanGroundCheck");
        HumanCeilingCheck = transform.Find("HumanGroundCheck");
        FoxCeilingCheck = transform.Find("FoxCeilingCheck");
		FoxGroundCheck = transform.Find("FoxGroundCheck");

        m_CeilingCheck = HumanCeilingCheck;
        m_GroundCheck= HumanGroundCheck;

		//m_GroundCheck = transform.Find("FoxGroundCheck");
	//	m_CeilingCheck = transform.Find("FoxCeilingCheck");

    }
	
	// Update is called once per frame
   	private void Update()
    {
        if (!isJump)
        {

            isJump = Input.GetButtonDown("Jump");
            anim.SetBool("Jump", isJump);
        }

		if(Input.GetKeyDown(KeyCode.C)){
			
			isClimb =!isClimb;
			//print ("Climb "+ isClimb);
			
			
		}


		if (Input.GetKeyDown(KeyCode.T))
		{
			isTransformed = !isTransformed;
			Transformed();

		}
		
		
	}

	void FixedUpdate(){
		
	//	flash = Input.GetKey(KeyCode.F);
		//anim.SetBool("Flash",flash);
		move = Input.GetAxis("Horizontal");
        
		anim.SetBool("Transformed",isTransformed);
		anim.SetBool("Climb", isClimb);
		Climb();
		m_Grounded = false;

		#region GroundCHeck+JUMPING
		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
				m_Grounded = true;
		}

		anim.SetBool("Ground", m_Grounded);
		//anim.SetBool("Jump", isJump);

		if (m_Grounded && isJump && anim.GetBool("Ground"))
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			anim.SetBool("Ground", false);
			rb.AddForce(new Vector2(0f, JumpForce));
		 
		}

#endregion
		Move();
	  
    }

   	void Direction () {

		if(move>0 && !m_FacingRight)
			
			Flip ();
		
		else if (move < 0 && m_FacingRight)
			Flip();
	}

	void Move(){

		rb.velocity = new Vector2(move * Maxspeed, rb.velocity.y); 
		anim.SetFloat("Speed",Mathf.Abs(move));
	    isJump = false;
        anim.SetBool("Jump",isJump);
		Direction();
		anim.SetBool("Right", m_FacingRight);
	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    
   
	void Climb(){
		if(canClimb && isClimb){
			
			if(Input.GetKey(KeyCode.W)){
				//print ("CLimbing UP");
				transform.Translate(new Vector3(0.0f,1.0f,0.0f)*(Time.deltaTime*Maxspeed));
			
				rb.gravityScale =0;

				
			} 
			
			else if(Input.GetKey(KeyCode.S)){
			//	print ("Climbing:DOWN");
				transform.Translate(new Vector3(0.0f,-1.0f,0.0f)*(Time.deltaTime*Maxspeed));
				rb.gravityScale = 0;
			}
			
			
		}
		else
		
			rb.gravityScale = 1;
		

		}
void Transformed(){
		if (!isTransformed)
		{
			m_CeilingCheck = HumanCeilingCheck;
			m_CeilingCheck = HumanGroundCheck;
			box.size = humanBoxSize;
			circle.offset = humanCircleOffset;
			//print("isHUMAN");
		}
		
		else if (isTransformed)
		{
			m_CeilingCheck = FoxCeilingCheck;
			m_GroundCheck = FoxGroundCheck;
			box.size = foxBoxSize;
			circle.offset = foxCircleOffset;
			//print("isFOX");
		}
		
	}
	
}		