using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AITargeting : MonoBehaviour {

	public List<GameObject> targets;
	public GameObject selectedTarget;
	private Transform myTransform;


	// Use this for initialization
	void Start () {
		
		myTransform= transform;
		targets = new List<GameObject>();
		AddAllEnemies();
		SortTargetsByDistance();

		
		
	}
	
	public void AddAllEnemies()
	{
		GameObject []go = GameObject.FindGameObjectsWithTag("Ally");
		foreach(GameObject enemy in go)
			AddTarget(enemy);
		AddTarget(GameObject.FindGameObjectWithTag("Player"));
		
	}
	public void AddTarget(GameObject enemy)
	{
		targets.Add(enemy);
	}
	
	private void SortTargetsByDistance()
	{


		targets.Sort(delegate(GameObject t1, GameObject t2) {


		return Vector3.Distance (t1.transform.position,myTransform.position).CompareTo(Vector3.Distance (t2.transform.position,myTransform.position));
		
		});
		selectedTarget = targets[0] ;

	}

	public void RefreshList()
	{
		for( int i = 0; i < targets.Count; i++)
		{
			if(targets[i] == null)
			{
				targets.Remove(targets[i]);
			}else{

				i++;
			}

		}
	}
	

	
	// Update is called once per frame
	void Update () {

		RefreshList();
		SortTargetsByDistance();

		
	}
	
	
}
