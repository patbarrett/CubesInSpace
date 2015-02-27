using UnityEngine;
using System.Collections;

public class Resume : MonoBehaviour {

	Pause isPaused;

	void Start () {

		isPaused = GameObject.FindGameObjectWithTag ("Player").GetComponent<Pause> ();
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

		isPaused.pauseGame = false;
		print (isPaused.pauseGame);


	}
}
