using UnityEngine;
using System.Collections;

public class BackToMain : MonoBehaviour {

	void Start () {
		
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
		Application.LoadLevel (0);
	}
}
