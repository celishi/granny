using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator CircleZoomMain;
    public float transitionTime = 1f;
    public int NextScene;

    public void LoadNextLevel()
    {
        StartCoroutine((string)Loadlevel(NextScene));        
    }

    IEnumerable Loadlevel(int SceneIndex)
    {
        CircleZoomMain.SetTrigger("start"); //play animation

        yield return new WaitForSeconds(transitionTime); //wait

        SceneManager.LoadScene(SceneIndex); //load scene
    }
}
