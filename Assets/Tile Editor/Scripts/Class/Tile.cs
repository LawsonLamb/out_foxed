using UnityEngine;
using System.Collections;

namespace TileEditor
{
    public class Tile : MonoBehaviour
    {

        #region Public Fields
        [HideInInspector]
        public CollisionType Collision;
        #endregion
		//public GameObject menu;
		string hint;
		int selectedHint;

		//static Random r=new Random();
		string[] hints = {
			"Formed from many small rocks",
			"Most of the rocks in the world",
			"Made from cooled melted rocks",
			"Formed deep in the earths crust"
		};

		void Start()
		{

			selectedHint = (int)(Random.value * 4);
			hint = hints [selectedHint];
			SetMatieral();
			//menu = GetComponent<Menu3> ();
		}
		[ContextMenu("SetMaterial")]
		void SetMatieral()
		{
			Material newMat = Resources.Load("customMaterial", typeof(Material)) as Material;
			gameObject.GetComponent<SpriteRenderer>().material = newMat;
		}
		void OnMouseOver()
		{
			//print ("over");
			//player.GetComponent<Menu2> ();
			if (Input.GetMouseButtonDown (0)) 
			{
				//print ("CLICK");
				if((Input.GetKey(KeyCode.LeftShift)||Input.GetKey(KeyCode.RightShift))&&GetComponent<SpriteRenderer>().sprite.name=="dirtCenter")
				{
					Menu3.hintContent=hint;
					//Menu3.numFoundRocks++;
					//Destroy (gameObject);
				}
				else if(GetComponent<SpriteRenderer>().sprite.name=="grassMid"||GetComponent<SpriteRenderer>().sprite.name=="grassCenter")
				{
					Destroy(gameObject);
				}
				else if(GetComponent<SpriteRenderer>().sprite.name=="dirtCenter")
				{
					Destroy(gameObject);
					Menu3.timer-=5;
					if(selectedHint==0||selectedHint==1)
						Menu3.numFoundRocks++;

				}
				
			}
		}
    }

}