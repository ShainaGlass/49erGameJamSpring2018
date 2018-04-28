using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezeOnCollision : MonoBehaviour {
    public Rigidbody2D rb2d;
    GameObject topObject;
    Rigidbody2D orb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (topObject != null)
        {
            orb2d.velocity = rb2d.velocity;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
