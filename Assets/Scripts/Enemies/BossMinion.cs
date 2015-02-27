using UnityEngine;
using System.Collections;

public class BossMinion : MonoBehaviour {

	GameObject master;
	GameObject target;
	bool isAttacking;
	public float spacing;
	public NavMeshAgent nav; 
	float distanceToTarget;
	public int attackPower;

	AITargeting aIT;

	// Use this for initialization
	void Start () {

		spacing = 0.1f;

		nav = GetComponent<NavMeshAgent>();
		master = GameObject.FindGameObjectWithTag("Boss");
		target = master;
		aIT = (AITargeting)master.GetComponent("AITargeting");
		isAttacking = false;

	
	}
	
	// Update is called once per frame
	void Update () {

		nav.destination = master.transform.position;

		target = aIT.selectedTarget;

		distanceToTarget = Vector3.Distance(gameObject.transform.position, target.transform.position);


		if(distanceToTarget < 22)
		{
			Attack ();
		}



	}

	void Attack()
	{
		this.nav.destination = target.transform.position;
		nav.stoppingDistance = 0;
		nav.speed = 8.5f;
		nav.autoBraking = false;
		if(distanceToTarget < 2.0f)
		{
			
			
			if(target.tag == "Player")
			{
				
				PlayerHealth ph = (PlayerHealth)target.GetComponent("PlayerHealth");
				ph.AddjustCurrentHealth(-attackPower);
				Destroy(gameObject);
				
			}else if(target.tag == "Ally")
			{
				AllyHealth eh = (AllyHealth)target.GetComponent("AllyHealth");
				eh.AddjustCurrentHealth(-attackPower);
				Destroy(gameObject);
				
			}
			
		}


	}


}
