using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioJingleBells : MonoBehaviour
{
    private GameObject[] audioboi;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        audioboi = GameObject.FindGameObjectsWithTag("Audio Source");
        if (audioboi.Length > 1)
        {
            Destroy(audioboi[0]);
        }
    }
}
