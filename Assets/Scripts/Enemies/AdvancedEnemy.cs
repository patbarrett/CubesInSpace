using UnityEngine;
using System.Collections;

public class AdvancedEnemy : MonoBehaviour {

	private Transform myTransform;
	private GameObject target;
	public NavMeshAgent nav;  
	private float distanceToTarget;
	public int attackPower;

	public GameObject projectile;
	public Transform projectileSpawn;


	bool isWandering;
	bool isAttacking;

	float attackTimer;
	public float coolDown;


	AITargeting targetting;

	void Awake()
	{
		myTransform = transform;
		nav = GetComponent<NavMeshAgent>();
		targetting = (AITargeting)gameObject.GetComponent ("AITargeting");

	}

	// Use this for initialization
	void Start () {
	
		isWandering = true;
		randomRotation();

	}


	// Update is called once per frame
	void Update () {
	
		target = targetting.selectedTarget;

		distanceToTarget = Vector3.Distance(target.transform.position,transform.position);
		//print (distanceToTarget);
//		print (isWandering);



		if(isWandering){
		
		this.transform.Translate(Vector3.forward * 0.05f);

		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		
			//check to see if we are about to run into a wall
		if(Physics.Raycast(transform.position,fwd,out hit,10))
			{
				if(hit.transform.tag == "Wall")
				{
				//if we do we must look the opposite way
				 turnAround();
				}

			}
		}

		if(distanceToTarget < 20)
		{


			transform.LookAt(target.transform);

			Vector3 fwd = transform.TransformDirection(Vector3.forward);
			RaycastHit hit;

			if (Physics.Raycast (transform.position, fwd, out hit, 100)) {

//				
				if (hit.transform.tag == "Wall") {

					isWandering = true;
				
				
			}else{
			

			isWandering = false;
			
			
			}
		}

		}else if (distanceToTarget > 20){

			isWandering = true;
		}

		if (isWandering == false) {


			if(attackTimer > 0)
				attackTimer -= Time.deltaTime;
			if (attackTimer< 0)
				attackTimer = 0;
			
			if(attackTimer == 0)
			
			{
				AttackPlayer();
				attackTimer = coolDown;
			}

		}

	}


	void randomRotation()
	{
		if(isWandering == true){
		InvokeRepeating("randomRotation",5,5);
		transform.eulerAngles = new Vector3(0,Random.Range(80,360),0);
		}
	}

	void turnAround()
	{

		Vector3 targetAngles = transform.eulerAngles + 180f * Vector3.up;
		transform.eulerAngles = targetAngles;
	
	}
	



	void AttackPlayer()
	{


		transform.LookAt(target.transform);

		Instantiate(projectile,projectileSpawn.position,projectileSpawn.rotation);

	}



}
