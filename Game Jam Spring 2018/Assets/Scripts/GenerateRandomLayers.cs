using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandomLayers : MonoBehaviour {


    public List<GameObject> foodLayers;
    public float MAX_SPAWN_TIME = 50;
    public float remainingTime = 0;
    public float objectsRemaining = 10;

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
                int objectIndex = Random.Range(0, foodLayers.Count);
                Vector3 position = new Vector3(Random.Range(-7f, 7f), Random.Range(0f, 5f), 0);

                //Make an instance of the layer
                Instantiate(foodLayers[objectIndex], position, Quaternion.identity);


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
