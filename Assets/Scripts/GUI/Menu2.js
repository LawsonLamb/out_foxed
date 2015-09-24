#pragma strict
var rectangle:Rect;
var batteryRectangle:Rect;
var canToggle:boolean;
var currentColl:String;
enum menuState{isMenu,isPause,isJournal,off};
var state:menuState;
var show;
var numFoundRocks:int;
static var numNeededRocks:int;
var timer: float = 300;
var batteryOutline:Texture2D;
var batteryJuice:Texture2D;
static var hintContent:String;
function Start () 
{
	rectangle=new Rect(0,0,200,200);
	batteryRectangle=new Rect(500,0,200,50);
	show=false;
	state=menuState.off;
	numFoundRocks=0;
	numNeededRocks=3;
	timer=100.0f;
	RenderSettings.ambientLight=Color.black;
	hintContent="";
}


function Update () {
	timer-=Time.deltaTime;
	if(Input.GetKey(KeyCode.M)&&canToggle)
	{
		if(state==menuState.off)
		{
			state=menuState.isMenu;
			show=true;
		}
		else
		{
			show=false;
			state=menuState.off;
		}
		canToggle=false;
	}
	
	
	if(Input.GetKey(KeyCode.P)&&canToggle)
	{
		if(state==menuState.off)
		{
			state=menuState.isPause;
			show=true;
		}
		else
		{
			show=false;
			state=menuState.off;
		}
		canToggle=false;
	}
	
	if(Input.GetKey(KeyCode.J)&&canToggle)
	{
		if(state==menuState.off)
		{
			state=menuState.isJournal;
			show=true;
		}
		else
		{
			state=menuState.off;
			show=false;
		}
		canToggle=false;
	}
	
	if((!Input.GetKey(KeyCode.M)) && (!Input.GetKey(KeyCode.P))
	&& (!Input.GetKey(KeyCode.J)))
	{
		canToggle=true;
	}

}
function OnCollisionStay2D(coll: Collision2D)
{  
        //currentColl=coll.gameObject.typeOfRock;
        currentColl=coll.gameObject.tag;
        //coll.collider.GetComponent(TEST).TypeOfRock();
       
}
function OnGUI () 
{
	if(show)
	{
		if(state==menuState.isMenu)//Scanner
		{
			GUI.Box(rectangle,"Menu Window");
			GUI.Label (Rect (10, 10, 100, 20), currentColl); 
		}
	
		if(state==menuState.isPause)
		{
			GUI.Box(rectangle,"Pause Window");
			GUI.Label (Rect (10, 110, 50, 20), currentColl);
		
		//Start Menu Button
		//Restart Level Button
		}
	
		if(state==menuState.isJournal)
		{
			GUI.Box(rectangle,"Scanner"); 
			//Tabs
			//Store Rock
			//Store Area
			GUI.Label(Rect(10,25,200,20),"Current Goal:");
			GUI.Label(Rect(25,45, 200,20),"Find 10 Sedimentary Rocks");
			GUI.Label(Rect(10,65,200,20),"Found Rocks: "+numFoundRocks+"/"+numNeededRocks);
			//Lost Pages
			//Teleport
		}
	}
	if(true)
	{
		//GUI.Box(batteryRectangle,""); 
		//GUI.Label(Rect(500,20,200,200),"Battery: "+parseInt(timer)+"%");
		GUI.DrawTexture(Rect(550,0,200,59),batteryOutline);
		GUI.DrawTextureWithTexCoords(Rect(576-156*(timer-100)/100,15,156*timer/100,26),batteryJuice,Rect(0,0,156,26));
		
	//Energy Bar
	//Location Label
	}
	
		//Rope Button
		
		//Pick Button
		//Transform Button
}