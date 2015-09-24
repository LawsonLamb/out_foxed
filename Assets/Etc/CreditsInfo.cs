using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreditsInfo : MonoBehaviour {

	RectTransform recTransform;
	Vector2 pos;
	Text instruction;
	
	// Use this for initialization
	void Start () {

		//Gets the objects "Text" and "RectTransform"
		instruction = GetComponent<Text> ();
		recTransform = GetComponent<RectTransform> ();

		//Sets a new pos var to recTansform and changes it x and y
		pos = recTransform.position;
		pos.x = (Screen.width / 2);
		pos.y = (Screen.height*0)-450;

		//Creates a line in the Textbox for each string in Credits.txt
		string stringPath = Application.dataPath + "/Etc/Credits.txt";
		string[] lines = System.IO.File.ReadAllLines (stringPath);
		foreach (string line in lines) {
		instruction.text += line + "\n";
		}

	}

	// Update is called once per frame
	void Update () {

		//Maks the text move
		pos.y++;

		if(recTransform.position.y >= (Screen.height))
		{
			pos.y = (Screen.height*0)-450;
		}

		recTransform.position = pos;

	}
}