using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
    public Vector2 mousePos;
    public Camera mainCamera;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        mousePos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, mousePos.y, mainCamera.nearClipPlane));
        Vector3 temp = transform.position;
        temp.x = mousePos.x;
        transform.position = temp;
	}
}
