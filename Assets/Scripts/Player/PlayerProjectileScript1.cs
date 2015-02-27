using UnityEngine;
using System.Collections;

public class PlayerProjectileScript1 : MonoBehaviour {
		
		
		public float projectileSpeed = 1;
		PlayerHealth ph;
		EnemyHealth eh;
		BossHealth bh;
		public int attackPower;
		GameObject spawner;

		
		// Use this for initialization
		void Start () {
			
		spawner = GameObject.FindGameObjectWithTag ("Spawner");
			
		}
		
		// Update is called once per frame
		void Update () {
			
			transform.Translate(Vector3.forward * projectileSpeed);
			Destroy(gameObject,0.6f);
			
		}
		
		void OnTriggerEnter(Collider other) {
			
			if (other.gameObject.transform.tag == "Boss") {
						bh = (BossHealth)other.gameObject.GetComponent ("BossHealth");
						bh.AddjustCurrentHealth (-(attackPower-5));
						if (bh.currHealth <= 1) {
								EnemySpawnerCount esc = (EnemySpawnerCount)spawner.GetComponent ("EnemySpawnerCount");
								esc.currentEnemiesSpawned += 1;
						}
						Destroy (gameObject);
				
				} else if (other.gameObject.transform.tag == "EvilEnemy") {
						eh = (EnemyHealth)other.gameObject.GetComponent ("EnemyHealth");
						eh.AddjustCurrentHealth (-attackPower);
						if (eh.currHealth <= 1) {
								EnemySpawnerCount esc = (EnemySpawnerCount)spawner.GetComponent ("EnemySpawnerCount");
								esc.currentEnemiesSpawned += 1;
						}
						Destroy (gameObject);
				
				} else if (other.gameObject.transform.tag == "BossMinion1") {
						eh = (EnemyHealth)other.gameObject.GetComponent ("EnemyHealth");
						eh.AddjustCurrentHealth (-attackPower);
						if (eh.currHealth <= 1) {
								EnemySpawnerCount esc = (EnemySpawnerCount)spawner.GetComponent ("EnemySpawnerCount");
								esc.currentEnemiesSpawned += 1;
						}
						Destroy (gameObject);
				
				} else if (other.gameObject.transform.tag == "BossMinion2") {	
						eh = (EnemyHealth)other.gameObject.GetComponent ("EnemyHealth");
						eh.AddjustCurrentHealth (-attackPower);
						if (eh.currHealth <= 1) {
								EnemySpawnerCount esc = (EnemySpawnerCount)spawner.GetComponent ("EnemySpawnerCount");
								esc.currentEnemiesSpawned += 1;
						}
						Destroy (gameObject);
				
				} else {

						Destroy (gameObject);
				}
			
			
			
		}
	}
