using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
        public string SceneName;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneName);
    }
}
