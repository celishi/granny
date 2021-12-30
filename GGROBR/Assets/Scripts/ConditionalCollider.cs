using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalCollider : MonoBehaviour
{
    public int damage;
    public float speed;

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
        speed = GameObject.FindWithTag("grandma").GetComponent<grandma>().XSpeed;
        transform.Translate(Vector2.left * speed * Time.deltaTime);
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
