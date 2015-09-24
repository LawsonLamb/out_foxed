using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]

public class EnemyAI: MonoBehaviour
{
 
    
   


    public Transform[] waypoints;
    private int currentWayPoint = 0;
    public float MoveSpeed;
    private Rigidbody2D rb;
     private float speed;
    private Animator anim;  
	public bool isFox;
	private bool m_FacingRight = true;
	// Use this for initialization
	void Start ()
	{
	    rb = GetComponent<Rigidbody2D>();
	    anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
        
        Vector3 target = waypoints[currentWayPoint].position;
        target.y = transform.position.y; 
        Vector3 moveDirection = target - transform.position;

    if (moveDirection.magnitude < .5f)
	    {
        if (currentWayPoint == waypoints.Length - 1)
	        {
	            currentWayPoint = 0;
	        }
        else
	        currentWayPoint++;
	    }
        //pos += target;
	  rb.velocity = moveDirection.normalized*MoveSpeed;
	
	    speed = rb.velocity.normalized.x;
		if(isFox){
			anim.SetBool("Ground",true);
			anim.SetFloat("Speed",Mathf.Abs(speed));
			Direction();

		}
		else
       anim.SetFloat("Speed",speed);
	}

	void Direction () {
		
		if(speed>0 && !m_FacingRight)
			
			Flip (); 

		
		else if (speed < 0 && m_FacingRight)
			Flip();
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


}
