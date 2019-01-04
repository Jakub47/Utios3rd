using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	[SerializeField] float maxHealthPoints = 100f;

	public float currentHealthPoints = 100f;
	public float healthAsPercentage
	{
		get 
		{
			return currentHealthPoints / (float)maxHealthPoints;
		}
	}

	[SerializeField] float maxManaPoints = 100f;

	float currentManaPoints = 100f;
	public float ManaAsPercentage
	{
		get 
		{
			return currentHealthPoints / (float)maxHealthPoints;
		}
	}

	[SerializeField] float maxStaminaPoints = 100f;

	float currentStaminaPoints = 100f;
	public float StaminaAsPercentage
	{
		get 
		{
			return currentHealthPoints / (float)maxHealthPoints;
		}
	}

}
