using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {


	public GameObject Minion1;
	public GameObject Minion2;
	public Transform minion1Spawn;
	public Transform minion2Spawn;

	float spawnTimer1;
	float spawnTimer2;
	float coolDown;


	// Use this for initialization
	void Start () {
	
		spawnTimer1 = 0;
		spawnTimer2 = 0;
		coolDown = 3.0f;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(GameObject.FindWithTag("BossMinion1") == null)
		{

			if(spawnTimer1 > 0)
				spawnTimer1 -= Time.deltaTime;
			if (spawnTimer1< 0)
				spawnTimer1 = 0;
			
			if(spawnTimer1 == 0)
			{
				SpawnMinion1();
				spawnTimer1 = coolDown;
			}

			//Invoke ("SpawnMinion1",3);

		}

		if(GameObject.FindWithTag("BossMinion2") == null)
		   {

			if(spawnTimer2 > 0)
				spawnTimer2 -= Time.deltaTime;
			if (spawnTimer2< 0)
				spawnTimer2 = 0;
			
			if(spawnTimer2 == 0)
			{
				SpawnMinion2();
				spawnTimer2 = coolDown;
			}

			}

			


	}

	void SpawnMinion1()
	{
		Instantiate(Minion1,minion1Spawn.position, minion1Spawn.rotation);

	}
	void SpawnMinion2()
	{
		Instantiate(Minion2,minion2Spawn.position, minion2Spawn.rotation);
	}
}

