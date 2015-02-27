using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {


	public GameObject projectile;
	public Transform projectileSpawn;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0))
		{
			Instantiate(projectile,projectileSpawn.position,projectileSpawn.rotation); 
		}
	
	}
}
