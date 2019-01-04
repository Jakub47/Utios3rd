using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour 
{
	//public
	[SerializeField] float maxHealthPoints = 100f;

	float currentHealthPoints = 100f;
	public float healthAsPercentage
	{
		get 
		{
			return currentHealthPoints / (float)maxHealthPoints;
		}
	}


	//HUD
	public Texture2D[] healthStatus;
	public RawImage healthStatusGUI;
	public Text healthText;

	public Texture2D[] manaStatus;
	public RawImage manaStatusGUI;
	public Text manaText;

	public Texture2D[] staminaStatus;
	public RawImage staminaStatusGUI;
	public Text staminaText;

	//private
	private float Timer;
	Player player;


	// Use this for initialization
	void Start () 
	{
		player = FindObjectOfType<Player>();
		healthStatusGUI.texture = healthStatus[5];
		manaStatusGUI.texture = manaStatus[5];
		staminaStatusGUI.texture = staminaStatus[5];
	}
	
	// Update is called once per frame
	void Update () 
	{
		//float xValue = -(player.healthAsPercentage * 2f) * -.5f ;
		healthText.text = player.currentHealthPoints.ToString() + '%';


		int health = (int)player.currentHealthPoints;
			if(health>=100) 
			healthStatusGUI.texture = healthStatus [5];

			if(health <100 && health >= 75)
			healthStatusGUI.texture = healthStatus [4];

			if(health <75 && health >= 50)
			healthStatusGUI.texture = healthStatus [3];
			
			if(health <50 && health >= 25)
			healthStatusGUI.texture = healthStatus [2];
			
			if(health <25 && health >= 1)
				healthStatusGUI.texture = healthStatus [1];
			
			if(health < 1)
				healthStatusGUI.texture = healthStatus [0];
	}
	/*
	public void HeathPickUp()
	{
		if(health < 5)
		{
			health++;
			healthStatusGUI.texture = healthStatus[health];
		}
		Debug.Log("health is " + health);
		Debug.Log("mana is " + mana);
		Debug.Log("stamina is " + stamina);
	}*/

}
