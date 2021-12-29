using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator TransitionAnimation;
    public float transitionTime;
    public int NextScene;

    private void Update()
    {
        if (GameObject.FindWithTag("grandma").GetComponent<grandma>().health == 0)
        {
            LoadNextScene();
        }       
    }

    public void LoadNextScene()
    {
        StartCoroutine((string)LoadScene());        
    }

    IEnumerable LoadScene()
    {
        TransitionAnimation.SetTrigger("start"); //play animation

        yield return new WaitForSeconds(transitionTime); //wait

        SceneManager.LoadScene(NextScene); //load scene
    }
}
