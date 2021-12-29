using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardCollider : MonoBehaviour
{
    public int damage;
    public float speed;
    public float XMin;

    // Update is called once per frame
    private void Update()
    {
        speed = GameObject.FindWithTag("grandma").GetComponent<grandma>().XSpeed;
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < XMin) 
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("grandma"))
        {
            other.GetComponent<grandma>().health -= damage;
            Debug.Log(other.GetComponent<grandma>().health);
            Destroy(gameObject);
        }
    }
}
