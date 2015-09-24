using UnityEngine;
using System.Collections;

public class DigTest : MonoBehaviour {
	public Light light;
	public bool turnedOn;
	public bool canToggle;
	private Animator anim;
	// Use this for initialization
    
	void Start () {
		//light.range = 3;
		anim = gameObject.GetComponent<Animator>();
		light.range = 3;
		light.color = Color.white;
		turnedOn = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (turnedOn && Input.GetKey (KeyCode.F)&&canToggle) {

			turnedOn=false;

			light.range=2;
			light.color=Color.blue;
			canToggle=false;
		}
		if (!turnedOn && Input.GetKey (KeyCode.F)&&canToggle) {
			turnedOn=true;
			light.range=3;
			light.color=Color.white;
			canToggle=false;
		}
		if (!Input.GetKey (KeyCode.F)) {
			canToggle=true;
		}
		anim.SetBool("Flash",turnedOn);

	}

    public void OnCollisionEnter2D(Collision2D coll)
    {
        
        
       
            
          
    }
	//Use a raycast to check the position of the mouse when the click goes out, then destroy the tile at that position
    public void OnCollisionStay2D(Collision2D coll)
    {  
        /*if (coll.gameObject.tag == "Grass")
            {
					
                if (Input.GetKeyDown(KeyCode.E))
                {
                    print("Destroyed");
                    Destroy(coll.gameObject);
                   
                }
            }
        }*/

    }

}




	/*if (Input.GetMouseButtonDown(0)) {
		var ray : Ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		var hit : RaycastHit;
		if (Physics.Raycast (ray, hit)) {
			if (hit.collider.tag == "destroyable") {
				Destroy(hit.collider.gameObject);
			}
		}
	}*/
