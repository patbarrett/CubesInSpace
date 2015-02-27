using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public bool pauseGame = false;
	private bool showGui = false;

	public TextMesh resume;
	public TextMesh mainMenu;


	// Use this for initialization
	void Start () {

		resume.renderer.enabled = false;
		mainMenu.renderer.enabled = false;




	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("p")) {
			

						pauseGame = !pauseGame;
			
						
				}

		if (pauseGame == true) {
			Screen.showCursor = true;
			
			Time.timeScale = 0;
			pauseGame = true;
			showGui = true;
			
			GetComponent<ShootingScript> ().enabled = false;
			GetComponent<MouseLook> ().enabled = false;
			GetComponent<Targetting> ().enabled = false;
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<MouseLook> ().enabled = false;
			
			
			
			}
			
			if(pauseGame == false)
			{
				Screen.showCursor = false;
				Time.timeScale = 1;
				pauseGame = false;
				GetComponent<ShootingScript>().enabled =true;
				GetComponent<MouseLook>().enabled =true;
				GetComponent<Targetting>().enabled =true;
				GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<MouseLook> ().enabled = true;
				showGui = false;
				
			}
			
			if (showGui)
			{
				resume.renderer.enabled = true;
				mainMenu.renderer.enabled = true;
				mainMenu.collider.enabled = true;
				resume.collider.enabled = true;
			}else
			{
				resume.renderer.enabled = false;
				mainMenu.renderer.enabled = false;
				mainMenu.collider.enabled = false;
				resume.collider.enabled = false;
			}
		
		
	}
}
