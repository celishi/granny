using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftCollider : MonoBehaviour
{
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
        if (other.CompareTag("grandma"))
        {
            other.GetComponent<grandma>().slowed = true;
            Destroy(gameObject);
        }
    }
}
