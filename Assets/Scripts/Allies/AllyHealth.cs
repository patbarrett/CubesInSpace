using UnityEngine;
using System.Collections;

public class AllyHealth : MonoBehaviour {

	public int maxHealth = 50;
	public int currHealth = 50;
	
	public float healthBarLength;

	public int Offset;



	// Use this for initialization
	void Start () {
	

		healthBarLength = Screen.width /4 ;

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

	void OnGUI()
	{
		
		
		GUI.Box(new Rect(10,40+Offset,healthBarLength,20),  gameObject.name + "  "+ currHealth + "/" + maxHealth);
		
		
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
		healthBarLength = (Screen.width/4)*(currHealth/(float) maxHealth);
	}
}
