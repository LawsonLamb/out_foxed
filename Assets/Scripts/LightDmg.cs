using UnityEngine;
using System.Collections;

public class LightDmg : MonoBehaviour {
	
	private DigTest digTest;
	private bool isTurnedOn;
	public float dmg;
	// Use this for initialization
	void Start () {
		digTest = GameObject.Find("Fox").GetComponent<DigTest>();

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
	if(col.tag == "Enemy"){
		if(digTest.turnedOn){

			Destroy(col.gameObject);
			}

		else
				Menu3.timer-=dmg;

		}

	

	}

	void OnTriggerStay2D(Collider2D col){

		if(col.tag == "Enemy"){
			if(digTest.turnedOn){
				
				Destroy(col.gameObject);
			}
			
			else
				Menu3.timer-=dmg;
			
		}
		


	}
	
}
