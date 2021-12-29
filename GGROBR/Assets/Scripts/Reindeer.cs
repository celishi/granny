using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reindeer : MonoBehaviour
{
    public Transform grandma;
    public float targetx;
    private Vector2 targetpos;
    private bool hasbeenhit;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        targetpos = new Vector2(targetx, grandma.position.y);
        transform.position = Vector2.MoveTowards(transform.position, (targetpos), speed * Time.deltaTime);
        if (GameObject.FindWithTag("grandma").GetComponent<grandma>().hit == 2)
        {
            hasbeenhit = true;
        }
        if (GameObject.FindWithTag("grandma").GetComponent<grandma>().health <= 0) 
        {
            targetx = -4;
            speed = 20;
        }
        else if (hasbeenhit == true)
        {
            targetx = -7;
        }
        else if (GameObject.FindWithTag("grandma").GetComponent<grandma>().SlowedState == true)
        {
            targetx = -8;
        }
        else if (transform.position.x != -12)
        {
            if (GameObject.FindWithTag("grandma").GetComponent<grandma>().SlowedState == false)
            {
                targetx = -12;
            }
        }
        if (transform.position.x == -7) 
        {
            hasbeenhit = false;
            GameObject.FindWithTag("grandma").GetComponent<grandma>().hit = 1;
        }
    }
}
