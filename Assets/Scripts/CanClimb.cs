using UnityEngine;
using System.Collections;

public class CanClimb : MonoBehaviour {

	bool canClimb= false;
	public GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Fox");


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){


		if(col.gameObject.tag =="Player"){

			canClimb = true;

			//print ("enter");
			player.GetComponent<FoxMovement>().canClimb = canClimb;

		}

	}

	void OnTriggerStay2D(Collider2D col){

		
		if(col.gameObject.tag =="Player"){
			
			canClimb = true;
			//print ("stay");
			player.GetComponent<FoxMovement>().canClimb = canClimb;
		}
	}
	void OnTriggerExit2D(Collider2D col){

		if(col.gameObject.tag == "Player"){
			
			canClimb = false;

			player.GetComponent<FoxMovement>().canClimb = canClimb;
		}
	}
}
