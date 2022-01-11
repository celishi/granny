using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    private GameObject[] score;
    public int DistanceTravelled;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("grandma") != null) 
        {
            DistanceTravelled = GameObject.FindGameObjectWithTag("grandma").GetComponent<grandma>().NewDistance;
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        score = GameObject.FindGameObjectsWithTag("scoreboard");
        if (score.Length > 1)
        {
            Destroy(score[0]);
        }
    }
}