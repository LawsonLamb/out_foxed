using UnityEngine;
using System.Collections;
[RequireComponent(typeof(BoxCollider2D))]
public class EnemyTurnON : MonoBehaviour {


	// Use this for initialization
	void Start () {

		gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
		foreach(Transform child in transform){
			child.gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		//print ("enter");
		if(col.tag == "Player"){
			foreach(Transform child in transform){
				child.gameObject.SetActive(true);
			}
		
		}
	}

	void OnTriggerStay2D(Collider2D col){
		//print ("stay");
		if(col.tag == "Player"){
			foreach(Transform child in transform){
				child.gameObject.SetActive(true);
			}
			
		}
	}

	void OnTriggerExit2D(Collider2D col){
	//	print ("exit");
		if(col.tag == "Player"){
			foreach(Transform child in transform){
				child.gameObject.SetActive(false);
			}
		}
	}
}
