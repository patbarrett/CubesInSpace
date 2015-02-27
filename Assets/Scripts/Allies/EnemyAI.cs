using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public GameObject target;
	public int moveSpeed;
	public int rotationSpeed;
	public int maxDistance;

	private Transform myTransform;
	private GameObject master;

	public NavMeshAgent nav;  
	public bool isAttacking = false;

	Targetting tg;


	void Awake()
	{
		myTransform = transform;
		nav = GetComponent<NavMeshAgent>();

	}


	// Use this for initialization
	void Start () {
	
		master = GameObject.FindGameObjectWithTag("Player");
		target = master;
		maxDistance = 4;
		tg = (Targetting)master.GetComponent("Targetting");
		nav.destination = master.transform.position;


	}
	
	// Update is called once per frame
	void Update () {

		if(target == null)
		{
			target = master;
		}

		if(isAttacking == false)
		{
			nav.destination = master.transform.position;

		}else if ( isAttacking == true){

			nav.destination = tg.selectedTarget.transform.position;

		}


		Debug.DrawLine(target.transform.position, myTransform.position,Color.cyan);
		//look at the target
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation,Quaternion.LookRotation(target.transform.position- myTransform.position), rotationSpeed * Time.deltaTime);




		// move towards target

	}

	public void SetTarget()
	{
		target = tg.selectedTarget;
	}

}
