using UnityEngine;
using System.Collections;

public class BossHealth : MonoBehaviour {

	public int maxHealth = 100;
	public int currHealth = 100;
	
	public float healthBarLength;


	// Use this for initialization
	void Start () {

		healthBarLength = Screen.width/10.0f;
	
	}
	
	// Update is called once per frame
	void Update () {

		AddjustCurrentHealth(0);
		if(currHealth <= 0)
		{
			Application.LoadLevel(6);
		}
	
	}

	void OnGUI()
	{
		
		GUI.Box(new Rect(Screen.width/2 + Screen.width/4,10,200,20), "BOSS: " +currHealth + "/" + maxHealth);
		
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
