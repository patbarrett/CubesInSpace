using UnityEngine;
using System.Collections;

public class InstructionsButton : MonoBehaviour {

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
		Application.LoadLevel ("InstructionsScene");
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
