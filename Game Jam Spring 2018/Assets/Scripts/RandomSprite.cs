using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour {

    public Sprite[] sprites;
    int spriteIndex;
	// Use this for initialization
	void Start () {
        spriteIndex = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex];
     }
	
	// Update is called once per frame
	void Update () {
		
	}
}
