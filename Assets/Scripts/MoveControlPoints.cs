using UnityEngine;
using System.Collections;

public class MoveControlPoints : MonoBehaviour {

	// Use this for initialization
    private Vector3 gameObjectPos;
    private Vector3 mousePos;
	private RopeMouse rope;
	public bool isPlaced;
	private Sprite bottomSprite;
	private LineRenderer line;
	private SpriteRenderer sRender;


	void Awake(){
		gameObjectPos = new Vector3(0,0);
		line = gameObject.GetComponent<LineRenderer>();
		sRender = gameObject.GetComponent<SpriteRenderer>();
		rope = GameObject.Find("Fox").GetComponent<RopeMouse>();
		line.SetWidth(rope.lineWidth,rope.lineWidth);
		line.material = rope.LineMaterial;
		bottomSprite = rope.ropeBottomSprite;
		isPlaced= false;
	}

	// Update is called once per frame
	void Update () {


	if(!isPlaced){
		if(Input.GetMouseButtonDown(0)){

				Placed();
				isPlaced= true;

		}
			Move();
		}
	}
void OnMouseDrag()
{
  
    

}
void Move(){

		mousePos = Input.mousePosition;
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);
		gameObject.transform.position = gameObjectPos;
		gameObjectPos.x = mousePos.x;
		gameObjectPos.y = mousePos.y;

}

void Placed(){



		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, rope.rayDistince,rope.RayCastMask);


	if (hit)
			{
				
				print("HIT: " + hit.transform.name);
				
			if (hit.collider.gameObject.tag == "Grass"|| hit.collider.gameObject.tag =="Dirt")
				{ 
					Debug.DrawLine(transform.position, -Vector2.up*rope.rayDistince, Color.green,1.0f);
					print("hit X:" + hit.transform.position.x+"hit y: "+ hit.transform.position.y);
					
						GameObject bottom = new GameObject("RopeBottom");
						bottom.transform.position = new Vector2(transform.position.x,hit.transform.position.y+hit.transform.GetComponent<SpriteRenderer>().bounds.size.y);
						bottom.AddComponent<SpriteRenderer>();
						bottom.GetComponent<SpriteRenderer>().sprite = bottomSprite;	
						bottom.AddComponent<CanClimb>();

				BoxCollider2D box = bottom.AddComponent<BoxCollider2D>();
				box.isTrigger = true;
				float boxsizeY = box.size.y;
				boxsizeY = Vector2.Distance(bottom.transform.position, transform.position);
				float offset = boxsizeY/2;
				box.offset = new Vector2(box.offset.x,offset);
				box.size = new Vector2(box.size.x, boxsizeY);
			

				float topSpriteHeight = sRender.bounds.size.y/2;
				Vector3 topLinePos = new Vector3(transform.position.x-.01f, transform.position.y-topSpriteHeight);

				float bottomSpriteHeight = bottom.GetComponent<SpriteRenderer>().bounds.size.y/2;
				Vector3 botLinePos =  new Vector3(bottom.transform.position.x-.01f,bottom.transform.position.y+bottomSpriteHeight);

				line.SetWidth(rope.lineWidth,rope.lineWidth);
				line.material = rope.LineMaterial;
				line.SetPosition(0,botLinePos);
				line.SetPosition(1,topLinePos);

				}
				
			}


	}



}
