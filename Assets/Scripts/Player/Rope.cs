
using UnityEngine;
using System.Collections;

public class Rope : MonoBehaviour
{
    

    [SerializeField] public LayerMask RayCastMask;  
    private Rigidbody2D rb;
    public float rayDistince = 100.0f;
    public GameObject ropeTop;
    public GameObject ropeCenter;
    public GameObject ropeBottom;
    private LineRenderer line;
    public float lineWidth;
   // public Sprite ropeTopSprite;
    //public BoxCollider2D boxCol;

    // public float offset = .05f;
   private bool Top = false;
	// Use this for initialization
	void Start ()
	{
    	//boxCol.GetComponent<BoxCollider2D>();
	    //boxCol.isTrigger = true;
	    line = ropeTop.GetComponent<LineRenderer>();
        line.SetWidth(lineWidth,lineWidth);
	    rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per framae
	void Update ()
	{
       

	    if (Input.GetKeyDown(KeyCode.UpArrow))
	    {
	       // print("SHOOT RAY PEW PEW PEW PEW");
	        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, rayDistince,RayCastMask);

	 
	        if (hit)
	        {
              //  GameObject tile  =  tileMap.TileAt(hit.transform.position, 0);
	          //  print(tileMap.TransformPositionToGridIndex(new Vector2(transform.position.x, transform.position.y)));
               // print(tile.name);
	           
               // print("HIT: " + hit.transform.name);

	            if (hit.collider.gameObject.tag == "Grass" || hit.collider.gameObject.tag =="Dirt")
	            { 
                    Debug.DrawLine(transform.position, Vector2.up*rayDistince, Color.green,1.0f);
                  //  print("hit X:" + hit.transform.position.x+"hit y: "+ hit.transform.position.y);
	                
	                
	                        NewRope(hit);
    
	                
	            }
	        }
	      

	    }



	}


    void NewRope()
    {
        /*
        ropeTop = new GameObject("ropeTop");
	    ropeTop.AddComponent<SpriteRenderer>();
	    ropeTop.GetComponent<SpriteRenderer>().sprite = ropeTopSprite;
         line =  ropeTop.AddComponent<LineRenderer>();
        ropeBottom = new GameObject("ropeBottom");
        SpriteRenderer bottomSpriteRenderer =    ropeBottom.AddComponent<SpriteRenderer>();
        bottomSpriteRenderer.sprite = ropeTopSprite;
         */

    }

    void NewRope(RaycastHit2D hit)
    {
		//need to check if object already exist;
        GameObject top = Instantiate(ropeTop);
        top.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y - hit.transform.GetComponent<SpriteRenderer>().bounds.size.y, 0.0f);
      
        float topSpriteHeight = top.GetComponent<SpriteRenderer>().bounds.size.y/2;
		float topSpriteWidth = top.GetComponent<SpriteRenderer>().bounds.size.x/2;
		Vector3 topLinePos = new Vector3(top.transform.position.x-.01f, top.transform.position.y-topSpriteHeight);

		//line.SetVertexCount(2);

        //line.enabled = true;

       	GameObject bottom = Instantiate(ropeBottom);
        bottom.transform.position = new Vector3(hit.transform.position.x, transform.position.y, 0.0f);
        float bottomSpriteHeight = bottom.GetComponent<SpriteRenderer>().bounds.size.y/2;
		float bottomSpritewidth = bottom.GetComponent<SpriteRenderer>().bounds.size.x/2;
		Vector3 botLinePos =  new Vector3(bottom.transform.position.x-.01f,bottom.transform.position.y+bottomSpriteHeight);
       
		line.SetPosition(0,botLinePos);
        
		line.SetPosition(1,topLinePos);
		Top = false;
	
        BoxCollider2D box = bottom.GetComponent<BoxCollider2D>();
        float boxsizeY = box.size.y;
        boxsizeY = Vector2.Distance(bottom.transform.position, top.transform.position);
		float offset = boxsizeY/2;
        box.offset = new Vector2(box.offset.x,offset);
        box.size = new Vector2(box.size.x, boxsizeY);
      
       


    }





    
}
