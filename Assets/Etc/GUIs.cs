using UnityEngine;
using System.Collections;

public class GUIs : MonoBehaviour {

	Rect startButton = new Rect((Screen.width/2) - 50, (Screen.height/2) - 75, 100, 50);
	Rect controlButton = new Rect((Screen.width/2) - 50, Screen.height/2, 100, 50);
	Rect creditsButton = new Rect((Screen.width/2) - 50, (Screen.height/2) + 75, 100, 50);
	Rect homeButton = new Rect((Screen.width*0)+100, Screen.height/4, 100, 50);

	public GameObject background;
	public ArrayList imageBuffer = new ArrayList();
	public GameObject image;

	string[] pages = new string[] {"Player", "Skills", "Items"};
	int pageInt = 0;

	Rect toolBarRect = new Rect((Screen.width/2)-100,(Screen.height)-50,200,25);
	Rect pageLines = new Rect((Screen.width/2), (Screen.height/2), 425, 350);
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Awake()
	{
		//Saves the GUI object through the different loads.
		//DontDestroyOnLoad(this);
		//DontDestroyOnLoad(background);
		//Deletes any Extra GUI Objects
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
			Destroy(background);
		}
	}
	void OnGUI()
	{
		//The Difference In each Scene's GUI
		//Sends the player through the different scenes
		if (Application.loadedLevel.Equals (0)) { //Load Up Game 
			if (GUI.Button (startButton, "Start")) { 
				Application.LoadLevel (1);
			}
			if (GUI.Button (controlButton, "Teach Me")) {
				Application.LoadLevel (2);
			}
			if (GUI.Button (creditsButton, "Credits")) {
				Application.LoadLevel (3);

			}
		}
		if (Application.loadedLevel.Equals (1)) { //Game Scene
		}
		
		if (Application.loadedLevel.Equals (2)) { //Controls Scene
			GUI.Window (0, new Rect (0, 0, Screen.width, Screen.height), ControlBox, "Controls");//Window for the control scene
		}

		if (Application.loadedLevel.Equals (3)) { //Credits Scene

			if(GUI.Button (homeButton, "Home")){
				Application.LoadLevel (0);
			}
		}
	}

	void ControlBox(int windowID)
	{
		if(GUI.Button (homeButton, "Home")){
			Application.LoadLevel (0);
		}

		pageInt = GUI.Toolbar (toolBarRect, pageInt, pages);

		if (pageInt == 0) {

			PlayerInter();
		}
		if (pageInt == 1) {
			Skills ();
		}
		if (pageInt == 2) {
			Items ();
		}
	}

	void PlayerInter()
	{
		string infoSection = "Left Arrow or A: Allows the player to move towards the left direction. \n" +
		                     "Right Arrow or D: Allows the player to move towards the right direction. \n" +
		                     "Spacebar: Allows the player to Jump.\n" +
				             "Pause: Press P to pause the game.\n";

		GUI.Label (pageLines, infoSection);

	}

	void Skills()
	{
		string infoSection = "Rope: Press R after Digging a bit underground inorder to return to the " +
			                 "surface.\n" +
		                     "Left Mouse Click: Click the Left Mouse over a tile you want to destroy.\n" +
		                     "Scanner: Press S to open up the Scanner and learn about a rock or mineral " +
		                     "you are over.\n" +
		                     "Flash Light: Press F to turn your Flash Light on and Off.\n" +
		                     "Transform: Press T to transform between your Human and Animal Form\n";

		GUI.Label (pageLines, infoSection);
	}

	void Items()
	{
		string infoSection = "Direction Item: Use the Directional Item to help you identify where a mineral " +
			                 "may be located.\n" +
			                 "Shield: Use the Shield Item to protect yourself from the enemies touch.\n" +
			                 "Battery: Use the Battery Item to restore your energy.\n";

		GUI.Label (pageLines, infoSection);

	}
}