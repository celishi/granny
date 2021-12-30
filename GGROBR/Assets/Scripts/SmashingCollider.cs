using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashingCollider : MonoBehaviour
{
    public Transform grandma;
    public int damage;
    public float speed;
    private bool sameyasgrandma;

    void Start()
    {
        if (transform.position.y > 1) 
        {
            //GetComponent<SpriteRenderer>().sortingLayerID = -1794490669;
        }
        if (1 > transform.position.y && transform.position.y > -1)
        {
            //GetComponent<SpriteRenderer>().sortingLayerID = -1794490669;
        }
        if (transform.position.y < -1)
        {
            //GetComponent<SpriteRenderer>().sortingLayerID = -1794490669;
        }
    }
    // Update is called once per frame
    private void Update()
    {
        if (transform.position.y > 1 && grandma.position.y == 2)
        {
            sameyasgrandma = true;
        }
        else if (1 > transform.position.y && transform.position.y > -1 && grandma.position.y == 0)
        {
            sameyasgrandma = true;
        }
        else if (transform.position.y < -1 && grandma.position.y == -2)
        {
            sameyasgrandma = true;
        }
        else 
        {
            sameyasgrandma = false;
        }
        speed = GameObject.FindWithTag("grandma").GetComponent<grandma>().XSpeed;
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (GameObject.FindWithTag("grandma").GetComponent<grandma>().smashing == true && transform.position.x <= -4 && transform.position.x >= -6 && sameyasgrandma == true) 
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("grandma") && other.GetComponent<grandma>().jumping != true)
        {
            other.GetComponent<grandma>().health -= damage;
            Debug.Log(other.GetComponent<grandma>().health);
            Destroy(gameObject);
        }
    }
}
