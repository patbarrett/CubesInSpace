using UnityEngine;
using System.Collections;

public class LoadNextlevel3 : MonoBehaviour {


	PlayerHealth ph;

	// Use this for initialization
	void Start () {

		ph = (PlayerHealth)gameObject.GetComponent ("PlayerHealth");
	
	}
	
	// Update is called once per frame
	void Update () {
	

		if (ph.currHealth == 100) 
		{
			Application.LoadLevel("FirstLevel");

		}

	}
}
