using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AiHealing : MonoBehaviour {



	public List<GameObject> party;


	private PlayerHealth playerhealth;
	private AllyHealth minion1Health;
	private AllyHealth minion2Health;
	private AllyHealth minion3Health;

	public float HealTimer;
	public float coolDown;
	public float TimerBarLength;
	public float offset;
	public int healPower;


	// Use this for initialization
	void Start () {
	
		party = new List<GameObject> ();
		AddParty ();

		HealTimer = 0;
		coolDown = 6.0f;

		TimerBarLength = Screen.width /4 ;



	}
	
	// Update is called once per frame
	void Update () {



			if (HealTimer > 0) {
						HealTimer -= Time.deltaTime;
				}
			if (HealTimer< 0)
				HealTimer = 0;

		if (Input.GetKeyUp (KeyCode.F)) 
		{
			if(HealTimer == 0)
			{
				CastHeal();
				HealTimer = coolDown;
			}



		}
		   


	}

	void CheckPartyHealth()
	{

	
	
	}

	void OnGUI()
	{

		if (HealTimer > 0) {
			print ("fuck");
						GUI.Box (new Rect (10, 40 + offset, 150, 20), "Heal cool down: " + HealTimer);
				}

	}


	void CastHeal()
	{
		TimerBarLength = (150)*(3/2);



		if (playerhealth.currHealth < 100) {

						playerhealth.currHealth += healPower;
			
		}
		if (minion1Health.currHealth < 100)
		{
			minion1Health.currHealth += healPower;

		}
		if (minion2Health.currHealth < 100)
		{
			minion2Health.currHealth += healPower;

		}
		if (minion3Health.currHealth < 100)
		{

			minion3Health.currHealth += healPower;

		}





	}

	void Attack()
	    {


		}


	public void AddParty()
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");  
		party.Add (player);
		GameObject []go = GameObject.FindGameObjectsWithTag("Ally");
		foreach (GameObject partyMember in go)
						party.Add (partyMember);


		//ea = (EnemyAI)gameObject.GetComponent("EnemyAI");

		playerhealth = (PlayerHealth)party [0].GetComponent ("PlayerHealth");
		minion1Health = (AllyHealth)party [1].GetComponent ("AllyHealth");
		minion2Health = (AllyHealth)party [2].GetComponent ("AllyHealth");
		minion3Health = (AllyHealth)party [3].GetComponent ("AllyHealth");




	}


}
