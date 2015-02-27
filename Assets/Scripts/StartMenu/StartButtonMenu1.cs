using UnityEngine;
using System.Collections;

public class StartButtonMenu1 : MonoBehaviour {

	// Use this for initialization
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
		Application.LoadLevel (4);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}



