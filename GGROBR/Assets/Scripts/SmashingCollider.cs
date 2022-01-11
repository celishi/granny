using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashingCollider : MonoBehaviour
{
    public Transform grandma;
    public int damage;
    public float speed;
    private bool sameyasgrandma;
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
        if (transform.position.y > 1 && grandma.position.y > 1)
        {
            sameyasgrandma = true;
        }
        else if (1 > transform.position.y && transform.position.y > -1 && grandma.position.y < 1 && grandma.position.y > -1)
        {
            sameyasgrandma = true;
        }
        else if (transform.position.y < -1 && grandma.position.y < -1)
        {
            sameyasgrandma = true;
        }
        else 
        {
            sameyasgrandma = false;
        }
        speed = GameObject.FindWithTag("grandma").GetComponent<grandma>().XSpeed;
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (GameObject.FindWithTag("grandma").GetComponent<grandma>().smashing == true && transform.position.x <= -3.5 && transform.position.x >= -6 && sameyasgrandma == true) 
        {
            GameObject.FindWithTag("audio").GetComponent<AudioSourceCrash>().crash = true;
            Instantiate(Emitter, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("grandma") && other.GetComponent<grandma>().smashing != true)
        {
            other.GetComponent<grandma>().health -= damage;
            GameObject.FindWithTag("audio").GetComponent<AudioSourceCrash>().crash = true;
            Instantiate(Emitter, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (other.CompareTag("grandma")) 
        {
            GameObject.FindWithTag("audio").GetComponent<AudioSourceCrash>().crash = true;
            Instantiate(Emitter, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
