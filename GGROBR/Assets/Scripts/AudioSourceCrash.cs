using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceCrash : MonoBehaviour
{
    public bool crash;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (crash == true) 
        {
            audio.Play();
            crash = false;
        }
    }
}
