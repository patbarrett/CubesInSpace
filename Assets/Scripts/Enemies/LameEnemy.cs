using UnityEngine;
using System.Collections;

public class LameEnemy : MonoBehaviour {

	private Transform myTransform;
	private GameObject target;
	public NavMeshAgent nav;  
	private float distanceToTarget;
	public int attackPower;

	AITargeting targetting;

	void Awake()
	{
		this.transform.renderer.material.color = Color.blue;
		myTransform = transform;
		nav = GetComponent<NavMeshAgent>();
		targetting = (AITargeting)gameObject.GetComponent ("AITargeting");
		//nav.destination = target.transform.position;

	}

	// Use this for initialization
	void Start () {
	



	}
	
	// Update is called once per frame
	void Update () {
	
		target = targetting.selectedTarget;




		distanceToTarget = Vector3.Distance(gameObject.transform.position, target.transform.position);
		//print (distanceToTarget);

		if (distanceToTarget < 20) {
				
			this.nav.destination = target.transform.position;

		
		}


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
