using UnityEngine;
using System.Collections;

public class RopeMouse : MonoBehaviour {

	
	[SerializeField] public LayerMask RayCastMask;  
	public float rayDistince = 100.0f;
	public Material LineMaterial;
	public float lineWidth;
	public Sprite ropeTopSprite;
	public Sprite ropeBottomSprite;
	private Vector3 gameObjectPos;
	private GameObject top;
	bool isCreate;

	void Start ()
	{
		isCreate = false;
	}
	
	// Update is called once per framae
	void Update ()
	{

		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			// print("SHOOT RAY PEW PEW PEW PEW");

				
				isCreate = !isCreate;

				createTop();
		
			
		}
	
		else if(Input.GetKeyDown(KeyCode.DownArrow)){

		
		
		isCreate =!isCreate;
	
	}
	}

		



	void createTop(){
	

		if(isCreate== false && top.GetComponent<MoveControlPoints>().isPlaced == false) {
			Destroy(top);
		}
		else if(isCreate){
			top = new GameObject("RopeTop");
			top.AddComponent<SpriteRenderer>();
			top.GetComponent<SpriteRenderer>().sprite = ropeTopSprite;
			top.AddComponent<LineRenderer>();
			top.AddComponent<MoveControlPoints>();
			top.GetComponent<MoveControlPoints>().enabled = true;

		}
		}

	

}