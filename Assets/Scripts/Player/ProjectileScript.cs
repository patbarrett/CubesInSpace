using UnityEngine;
using System.Collections;



public class ProjectileScript : MonoBehaviour {
	
	
	public float projectileSpeed = 1;
	PlayerHealth ph;
	EnemyHealth eh;
	AllyHealth ah;
	
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate(Vector3.forward * projectileSpeed);
		Destroy(gameObject,0.6f);
		
	}
	
	void OnTriggerEnter(Collider other) {
		
		if (other.gameObject.transform.tag == "Player") {
						ph = (PlayerHealth)other.gameObject.GetComponent ("PlayerHealth");
						ph.AddjustCurrentHealth (-25);
						Destroy (gameObject);
			
				} else if (other.gameObject.transform.tag == "Ally") {
						ah = (AllyHealth)other.gameObject.GetComponent ("AllyHealth");
						ah.AddjustCurrentHealth (-12);
						Destroy (gameObject);
			
				} else if (other.gameObject.transform.tag == "EvilEnemy") {
						eh = (EnemyHealth)other.gameObject.GetComponent ("EnemyHealth");
						eh.AddjustCurrentHealth (-12);
						Destroy (gameObject);
			
				} else {

					Destroy(gameObject);
				
		}
		
		
		
	}
}