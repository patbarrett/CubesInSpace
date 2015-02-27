using UnityEngine;
using System.Collections;

public class MeleeMinionAttack : MonoBehaviour {

	public GameObject target;
	public float attackTimer;
	public float coolDown;
	private bool isAttacking;
	EnemyAI ea;
	public int attackPower;

	GameObject spawner;





	// Use this for initialization
	void Start () {

		isAttacking = false;
		attackTimer = 0;
		coolDown = 2.0f;
		ea = (EnemyAI)gameObject.GetComponent("EnemyAI");
		spawner = GameObject.FindGameObjectWithTag ("Spawner");

	

	}
	
	// Update is called once per frame
	void Update () {

		if(target == null){
			isAttacking  = false;
			ea.isAttacking = false;
			}


		if( Input.GetKeyUp(KeyCode.Q) && ea.target != null)
		{
			ea.SetTarget();
			ea.maxDistance = 2;
			target = ea.target;
			isAttacking = true;
			ea.isAttacking = true;
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



		if(distance <2.5){
		print ("working");
		EnemyHealth eh = (EnemyHealth)target.GetComponent("EnemyHealth");
			eh.AddjustCurrentHealth(-attackPower);

			if(eh.currHealth <= 1)
			{
				ea.target = null;
				EnemySpawnerCount esc = (EnemySpawnerCount)spawner.GetComponent ("EnemySpawnerCount");
				esc.currentEnemiesSpawned +=1;
			}
		}
	}
}
