﻿using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public GameObject target;
	public float attackTimer;
	public float coolDown;

	// Use this for initialization
	void Start () {


	
		attackTimer = 0;
		coolDown = 2.0f;

	}
	
	// Update is called once per frame
	void Update () {

		if(attackTimer > 0)
			attackTimer -= Time.deltaTime;
		if (attackTimer< 0)
			attackTimer = 0;

		//checking key pres
		if(Input.GetKeyUp(KeyCode.F) && attackTimer == 0)
		{
			Attack();
			attackTimer = coolDown;
		}
	
	}
	private void Attack()
	{
		float distance = Vector3.Distance(target.transform.position,transform.position);

		Vector3 dir = (target.transform.position - transform.position).normalized;

		float direction = Vector3.Dot(dir, transform.forward);



		if(distance<2.5 && direction > 0){
		EnemyHealth eh = (EnemyHealth)target.GetComponent("EnemyHealth");
		eh.AddjustCurrentHealth(-10);
		
		}
	}
}
