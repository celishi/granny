using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTaker : MonoBehaviour
{
    public Text scoredisplay;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoredisplay.text = "Your Score: " + GameObject.FindGameObjectWithTag("scoreboard").GetComponent<Scoreboard>().DistanceTravelled.ToString();
    }
}
