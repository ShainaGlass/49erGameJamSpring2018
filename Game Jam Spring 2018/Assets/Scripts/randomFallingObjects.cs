using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomFallingObjects : MonoBehaviour 
{

	// Use this for initialization

	public GameObject prefab;
	public float MAX_SPAWN_TIME = 50;
	public float remainingTime =0;
	public float objectsRemaining = 10;
		// Instantiate the prefab somewhere between -10.0 and 10.0 on the x-z plane
		void Start()
	{
		
	}
	private void FixedUpdate() 
	{
		if (remainingTime > 0) 
		{
			remainingTime--;
		} 
		else 
		{
			if (objectsRemaining > 0) 
			{
				Vector3 position = new Vector3 (Random.Range (-7f, 7f), Random.Range (0f, 5f),0);
				Instantiate (prefab, position, Quaternion.identity);
				remainingTime = MAX_SPAWN_TIME;
				objectsRemaining--;

				if (MAX_SPAWN_TIME > 50) 
				{
					MAX_SPAWN_TIME -= 10;
				}
			}
		}
	}
}
