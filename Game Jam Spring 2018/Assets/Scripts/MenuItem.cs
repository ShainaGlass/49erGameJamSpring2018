using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuItem : MonoBehaviour {
    public List<GameObject> foodLayers;//0 is bottombun, 1 is top, others random layers
    public List<GameObject> chosenFoodLayers;
    public int numFoodLayers = 6;
    GameObject player;
    //public Text winText;
    // Use this for initialization
    void Start () {
       // winText.text = "";
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 spawnPos = transform.position;
        chosenFoodLayers.Add(Instantiate(foodLayers[0], spawnPos, Quaternion.identity, transform));

        for (int i = 1; i < numFoodLayers -1; i++)
        {
            spawnPos.x += 3;
            chosenFoodLayers.Add(Instantiate(foodLayers[Random.Range(2, foodLayers.Count)], spawnPos, Quaternion.identity, transform));
        }
        spawnPos.x += 3;
        chosenFoodLayers.Add(Instantiate(foodLayers[1], spawnPos, Quaternion.identity, transform));

        for (int i = 0; i < numFoodLayers; i++)
        {
           chosenFoodLayers[i].GetComponent<Rigidbody2D>().isKinematic = true;
            chosenFoodLayers[i].GetComponent<BoxCollider2D>().enabled = false;
            chosenFoodLayers[i].tag = "Menu";
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void CheckBurger()
    {
        bool output = player.GetComponent<playerMovement>().topObject.GetComponent<freezeOnCollision>().CheckBurgerChain(chosenFoodLayers, 0);
        if (!output)
        {
            Destroy(player.GetComponent<playerMovement>().topObject);
        }
        else
        {
            //player.GetComponent<SpriteRenderer>().color = Color.magenta;
            //winText.text = "YOU WON!";
            SceneManager.LoadScene("winScene");
        }
        
    }
}
