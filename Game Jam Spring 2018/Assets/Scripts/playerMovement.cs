using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
    public Vector2 mousePos;
    public Camera mainCamera;
    public Rigidbody2D rb2d;
    public float playerSpeed = 50;
    public float currentVelocity;
    public GameObject MenuBox;

    public GameObject topObject;
    Rigidbody2D orb2d;
    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        mousePos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, mousePos.y, mainCamera.nearClipPlane));
        //Vector3 temp = transform.position;
        //temp.x = mousePos.x;
        //rb2d.MovePosition(temp);
        Vector2 tempVelocity = rb2d.velocity;
        tempVelocity.x = Mathf.Clamp(mousePos.x - transform.position.x, -1, 1) * playerSpeed;
        currentVelocity = tempVelocity.x;
        rb2d.velocity = tempVelocity;

        if (topObject != null)
        {
            orb2d.velocity = rb2d.velocity;
        }
        if(Input.GetAxis("Fire1") > 0)
        {
            MenuBox.GetComponent<MenuItem>().CheckBurger();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (topObject == null)
        {
            GameObject other = collision.gameObject;
            if (other.CompareTag("FallingObject"))
            {
                other.tag = "StackedObject";
                topObject = other;
                orb2d = other.GetComponent<Rigidbody2D>();
            }
        }
    }
}
