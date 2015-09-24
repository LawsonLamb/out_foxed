using UnityEngine;
using System.Collections;

public class Menu3 : MonoBehaviour {
	Rect rectangle;
	Rect batteryRectangle;
	bool canToggle;
	string currentColl;
	enum menuState{isMenu,isPause,isJournal,off};
	menuState state;
	bool show;
	public static int numFoundRocks;
	int numNeededRocks;
	public static float timer;
	public Texture2D batteryOutline;
	public Texture2D batteryJuice;
	public static string hintContent;
	private DigTest digTest;
	//bool isLightOn;
	// Use this for initialization
	void Start () 
	{
		rectangle = new Rect (0, 0, 200, 200);
		batteryRectangle = new Rect (500, 0, 200, 50);
		show = false;
		state = menuState.off;
		numFoundRocks = 0;
		numNeededRocks = 5;
		timer = 100.0f;
		RenderSettings.ambientLight = Color.black;
		hintContent = "";
		currentColl = "";
		digTest = GameObject.Find("Fox").GetComponent<DigTest>();

	}

	// Update is called once per frame
	void Update () {

	
		bool isLight = digTest.turnedOn;
		if(isLight){
			timer-=Time.deltaTime;
		}
			else if(!isLight){
			float tempTimer = timer;
				timer= tempTimer;
		}

	

		if(timer<=0)
			Application.LoadLevel("EndMenu");

		
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
	public void OnGUI () 
	{
		if(show)
		{
			if(state==menuState.isMenu)//Scanner
			{
				GUI.Box(rectangle,"Menu Window");
				GUI.Label (new Rect (10, 10, 100, 20), currentColl); 

			}
			
			if(state==menuState.isPause)
			{
				GUI.Box(rectangle,"Pause Window");
				GUI.Label (new Rect (10, 110, 50, 20), ""+currentColl);
				
				//Start Menu Button
				//Restart Level Button
			}
			
			if(state==menuState.isJournal)
			{
				GUI.Box(rectangle,"Scanner"); 
				//Tabs
				//Store Rock
				//Store Area
				GUI.Label(new Rect(10,25,200,20),"Current Goal:");
				GUI.Label(new Rect(25,45, 200,20),"Find 10 Sedimentary Rocks");
				GUI.Label(new Rect(10,65,200,20),"Found Rocks: "+numFoundRocks+"/"+numNeededRocks);
				GUI.Label(new Rect(10,85,200,20),hintContent);
				//Lost Pages
				//Teleport
			}
		}
		if(true)
		{
			//GUI.Box(batteryRectangle,""); 
			//GUI.Label(Rect(500,20,200,200),"Battery: "+parseInt(timer)+"%");
			GUI.DrawTexture(new Rect(550,0,200,59),batteryOutline);
			GUI.DrawTextureWithTexCoords(new Rect(576-156*(timer-100)/100,15,156*timer/100,26),batteryJuice,new Rect(0,0,156,26));
			//Energy Bar
			//Location Label
		}
		
		//Rope Button
		
		//Pick Button
		//Transform Button
	}
	public void FoundRock()
	{
		numFoundRocks++;
	}
}
