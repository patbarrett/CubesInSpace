using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targetting : MonoBehaviour {

	public List<GameObject> targets;
	public GameObject selectedTarget;
	private Transform myTransform;
	GameObject temp;

	bool addItem;

	// Use this for initialization
	void Start () {
	
		myTransform= transform;
		targets = new List<GameObject>();
		AddAllEnemies();
		//selectedTarget = targets[0] ;


	}

	public void AddAllEnemies()
	{

		if (GameObject.FindGameObjectsWithTag ("EvilEnemy")!= null) {
						GameObject [] go = GameObject.FindGameObjectsWithTag ("EvilEnemy");
						foreach (GameObject enemy in go)
								AddTarget (enemy);
				}


		if (GameObject.FindGameObjectWithTag ("Boss") != null) {
						
						temp = GameObject.FindGameObjectWithTag ("Boss");
						AddTarget (temp);
						
			}

		if (GameObject.FindGameObjectWithTag ("BossMinion1") != null) {
			GameObject temp2 = GameObject.FindGameObjectWithTag ("BossMinion1");
						AddTarget (temp2);
				}
		if (GameObject.FindGameObjectWithTag ("BossMinion2") != null) {
						GameObject temp3 = GameObject.FindGameObjectWithTag ("BossMinion2");
						AddTarget (temp3);
				}





	}
	public void AddTarget(GameObject enemy)
	{
		targets.Add(enemy);
	}

	private void SortTargetsByDistance()
	{
		if (targets.Count > 1) {
						targets.Sort (delegate(GameObject t1, GameObject t2) {

								return Vector3.Distance (t1.transform.position, myTransform.position).CompareTo (Vector3.Distance (t2.transform.position, myTransform.position));
						});
				}
	}



	private void SelectTarget()
	{
		selectedTarget.renderer.material.color = Color.red;
		PlayerAttack pa = (PlayerAttack)GetComponent("PlayerAttack");
		pa.target = selectedTarget.gameObject;
	}
	private void DeselectTarget()
	{
		selectedTarget.renderer.material.color = Color.blue;
		selectedTarget = null;

	}
	
	// Update is called once per frame
	void Update () {

		RefreshList();

		if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
		{

			AddAllEnemies();
			SortTargetsByDistance();
			TargetEnemy();
		}
	
	}



	private void TargetEnemy()
	{
		//if(selectedTarget == null)
		//{
			SortTargetsByDistance();
			selectedTarget = targets[0];
		for (int i = 0; i < targets.Count; i++) {

			targets[i].renderer.material.color = Color.blue;



		}

		//}else 
		//{
			//int index = targets.IndexOf(selectedTarget);
			//if(index < targets.Count -1)
			//{
			//	index++;
			//} else
			//{
				//index = 0;
			//}
			//DeselectTarget();
			//selectedTarget = targets[index];
			
		//}
		SelectTarget();
	}



	public void RefreshList()
	{
		for (int i = 0; i < targets.Count; i++) {


					
						targets.Remove (targets [i]);

				
			}
			
	}
}


