using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testFall : MonoBehaviour {

	// Use this for initialization
	public Transform prefab;
	void Start()
	{
	}
	private void fall() {
		for (int i = 0; i < 10; i++)
		{
			Instantiate(prefab, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
		}
	}
}
