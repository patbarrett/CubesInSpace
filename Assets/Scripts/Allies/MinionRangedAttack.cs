using UnityEngine;
using System.Collections;

public class MinionRangedAttack : MonoBehaviour {

	public GameObject projectile;

	public Transform projectileSpawn;

	public GameObject target;
	public float attackTimer;
	public float coolDown;
	private bool isAttacking;
	EnemyAI ea;


	// Use this for initialization
	void Start () {
	
		ea = (EnemyAI)gameObject.GetComponent("EnemyAI");
	}
	
	// Update is called once per frame
	void Update () {


		if(target == null){
			isAttacking  = false;
			ea.isAttacking = false;
			ea.nav.stoppingDistance = 1;
		
		}
		
		
		if( Input.GetKeyUp(KeyCode.E) && ea.target != null)
		{
			ea.SetTarget();
			ea.maxDistance = 8;
			target = ea.target;
			ea.isAttacking = true;
			isAttacking = true;
			ea.nav.stoppingDistance = 8;
		}
		
		
		if(isAttacking){
			
			if(attackTimer > 0)
				attackTimer -= Time.deltaTime;
			if (attackTimer< 0)
				attackTimer = 0;
			
			if(attackTimer == 0)
			{
				Attack();
				attackTimer = coolDown;
			}
		}
	
	}

	private void Attack()
	{
		float distance = Vector3.Distance(target.transform.position,transform.position);
		Vector3 dir = (target.transform.position - transform.position).normalized;
		float direction = Vector3.Dot(dir, transform.forward);
		
		
		
		if(distance < 8.1){

			Instantiate(projectile,projectileSpawn.position,projectileSpawn.rotation) ;
		

			//EnemyHealth eh = (EnemyHealth)target.GetComponent("EnemyHealth");
			//eh.AddjustCurrentHealth(-10);
		}
	}
}
