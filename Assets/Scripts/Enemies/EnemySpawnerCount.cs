using UnityEngine;
using System.Collections;

public class EnemySpawnerCount : MonoBehaviour {


	public int MaxEnemiesCount;
	public int currentEnemiesSpawned;
	public int Level;

	public int spawnCountDown;
	float timeToNextSpawn;

	public GameObject Boss;

	bool bossSpawned;

	float timeToBoss;
	public bool bossLevel;


	// Use this for initialization
	void Start () {
		currentEnemiesSpawned = 0;
		timeToNextSpawn = spawnCountDown;
		bossSpawned = false;
		timeToBoss = 10;
	
	}


	void OnGUI()
	{
		
		GUI.Box(new Rect(Screen.width/2 + Screen.width/4,10,120,20), "KILLS: " +currentEnemiesSpawned + "/" + MaxEnemiesCount);
		GUI.Box(new Rect(Screen.width/2 + Screen.width/8,30,300,20), "TIME TILL NEXT WAVE OF ENEMIES: " +timeToNextSpawn);
		if (currentEnemiesSpawned == MaxEnemiesCount & bossLevel == true) {

			GUI.Box(new Rect(Screen.width/2 + Screen.width/4,50,120,20), "BOSS INC!! :" +timeToBoss);

				} 
		
	}


	// Update is called once per frame
	void Update () {


		if(timeToNextSpawn > 0)
			timeToNextSpawn -= Time.deltaTime;
		if (timeToNextSpawn < 0)
						timeToNextSpawn = spawnCountDown;
			//timeToNextSpawn = 0;


		if(currentEnemiesSpawned == MaxEnemiesCount && bossLevel == true)
		timeToBoss -= Time.deltaTime;

		if(timeToBoss < 0)
			timeToBoss = 0;


		//HealTimer = coolDown;



		if (timeToBoss <= 0 && bossSpawned == false) 
		{
		
			SpawnBoss();
		}

		if (bossSpawned == true && GameObject.FindGameObjectWithTag ("Boss") == false  && bossLevel == true){

			Application.LoadLevel(Level);
				
		}

		if (currentEnemiesSpawned == MaxEnemiesCount && bossLevel == false) 
		{
			Application.LoadLevel(Level);
		}

	
	}
	void SpawnBoss(){

				Instantiate (Boss, gameObject.transform.position, Quaternion.identity);
				bossSpawned = true;

		}
}
