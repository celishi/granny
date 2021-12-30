using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    private void Update()
    {
        if(GameObject.FindWithTag("grandma").GetComponent<grandma>().health == 0)
        {
            LoadNextScene();
        }       
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadLevel());        
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start"); //play animation

        yield return new WaitForSeconds(transitionTime); //wait

        SceneManager.LoadScene("GameOver"); //load scene
    }
}
