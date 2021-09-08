using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManager
{
    public class SceneLoader : MonoBehaviour
    {
        int currentScene;
        // Start is called before the first frame update
        void Start()
        {
            currentScene = SceneManager.GetActiveScene().buildIndex;
        }

        public void LoadStartScene()
        {
            SceneManager.LoadScene("StartScene");
        }

        public void LoadNextScene()
        {
            SceneManager.LoadScene(currentScene + 1);
        }
        public void RestartScene()
        {
            SceneManager.LoadScene(currentScene);
        }
        public void QuitApp()
        {
            Application.Quit();
        }
    }
}

