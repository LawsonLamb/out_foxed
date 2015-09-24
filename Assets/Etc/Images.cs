using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Images : MonoBehaviour {

	Image pic;
	public static int numImages;
	public Sprite[] pictures = new Sprite[numImages];
	public int x;
	Vector2 posImage;

	RectTransform recTransform;

	// Use this for initialization
	void Start () {

		recTransform = GetComponent<RectTransform> ();
		posImage.y = (Screen.height * 0);
		pic = GetComponent<Image> ();
		x = 0;
		posImage = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		pic.sprite = pictures[x];

		if (recTransform.position.y > (Screen.height)+100) {
			x++;
			posImage.y = (Screen.height*0);
			posImage.x = Random.Range(((Screen.width*0)+50),((Screen.width)-50));
		}

		posImage.y++;

		if (x >= 20) {
			x =0;
		}

		gameObject.transform.position = posImage;
	}
}
