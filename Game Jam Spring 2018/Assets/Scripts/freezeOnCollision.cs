using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezeOnCollision : MonoBehaviour {
    public Rigidbody2D rb2d;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
           // rb2d.angularVelocity = Vector2.zero;
            //rb2d.isKinematic = true;

            transform.parent = other.transform;
        }
    }

}
