using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardCollider : MonoBehaviour
{
    public int damage;
    public float speed;
    public GameObject Emitter;

    void Start()
    {
        if (transform.position.y > 1)
        {
            GetComponent<SpriteRenderer>().sortingLayerName = "lane1";
        }
        if (1 > transform.position.y && transform.position.y > -1)
        {
            GetComponent<SpriteRenderer>().sortingLayerName = "lane2";
        }
        if (transform.position.y < -1)
        {
            GetComponent<SpriteRenderer>().sortingLayerName = "lane3";
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
            other.GetComponent<grandma>().health -= damage;
            GameObject.FindWithTag("audio").GetComponent<AudioSourceCrash>().crash = true;
            Instantiate(Emitter, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
