using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int maxHealth = 100;
	public int currHealth = 100;

	public float healthBarLength;




	// Use this for initialization
	void Start () {
	
		//ea = (EnemyAI)gameObject.GetComponent("EnemyAI");
		healthBarLength = Screen.width/2;


	}
	
	// Update is called once per frame
	void Update () {
		//print (currHealth);
		if(currHealth <= 0)
		{
			Destroy(gameObject);
		}

		AddjustCurrentHealth(0);
	
	}


 	public void AddjustCurrentHealth(int adj)
	{

		currHealth += adj;
		if(currHealth < 0)
			currHealth = 0;
		if(currHealth > maxHealth)
			currHealth = maxHealth;
		if(maxHealth  < 1)
			maxHealth = 1;
		healthBarLength = (Screen.width/2)*(currHealth/(float) maxHealth);
	}
}
