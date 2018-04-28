using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItem : MonoBehaviour {
    public List<GameObject> foodLayers;
    public List<GameObject> chosenFoodLayers;
    int numFoodLayers = 6;
    // Use this for initialization
    void Start () {
        Vector3 spawnPos = transform.position;
		for(int i = 0; i < numFoodLayers; i++)
        {
            chosenFoodLayers.Add(Instantiate(foodLayers[Random.Range(0, 5)], spawnPos, Quaternion.identity, transform));
            chosenFoodLayers[i].GetComponent<Rigidbody2D>().isKinematic = true;
            spawnPos.x += 3;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
