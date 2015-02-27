using UnityEngine;
using System.Collections;

public class QUIT : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Screen.showCursor = true;

		gameObject.renderer.material.color = Color.gray;
	
	}


	void OnMouseOver()
	{
		gameObject.renderer.material.color = Color.magenta;
	}
	void OnMouseExit()
	{
		gameObject.renderer.material.color = Color.gray;
	}



	void OnMouseDown()
	{
		Application.Quit ();
	}
}
