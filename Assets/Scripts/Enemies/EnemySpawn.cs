using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {


	bool isEnemySpawned;
	public float respawnTime;
	public GameObject[] enemy;
	public GameObject spawnPoint;
	public int maxSpawns;
	public int spawns;




	// Use this for initialization
	void Start () {
	
		isEnemySpawned = false;

	}
	
	// Update is called once per frame
	void Update () {



		if(isEnemySpawned == false)
		{
			isEnemySpawned = true;
			EnemyRespawn();


		}
	
	}

	void SpawnEnemy()
	{

		int r = Random.Range (0, enemy.Length);
		spawns++;
		if(spawns < maxSpawns)
		Instantiate(enemy[r], spawnPoint.transform.position,Quaternion.identity);




	}

	void EnemyRespawn()
	{


		InvokeRepeating("SpawnEnemy",respawnTime,respawnTime);
		//SpawnEnemy();
	}


}
