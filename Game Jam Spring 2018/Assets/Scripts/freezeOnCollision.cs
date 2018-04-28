using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezeOnCollision : MonoBehaviour {
    Rigidbody2D rb2d;
    GameObject topObject;
    Rigidbody2D orb2d;
    public float timeToLive = 300f;
    public string layerType;
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
        if (timeToLive <= 0 && CompareTag("FallingObject"))
        {
            Destroy(gameObject);
        }
        timeToLive--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Floor") && CompareTag("FallingObject"))
        {
            Destroy(gameObject);
            Debug.Log("BOOM");
        }
        else if (topObject == null)
        {
            if (other.CompareTag("FallingObject"))
            {
                other.tag = "StackedObject";
                topObject = other;
                orb2d = other.GetComponent<Rigidbody2D>();
            }
        }        
    }

    public bool CheckBurgerChain(List<GameObject> layers, int index)
    {
        if (layers[index].GetComponent<freezeOnCollision>().layerType == layerType)
        {
            if(index >= layers.Count -1)
            {
                return true;
            }
            else
            {
                index++;
                if(topObject == null)
                {
                    return false;
                }
                bool output = topObject.GetComponent<freezeOnCollision>().CheckBurgerChain(layers, index);
                if (!output)
                {
                    Destroy(topObject);
                }
                return output;
            }
        }
            return false;
    }

}
