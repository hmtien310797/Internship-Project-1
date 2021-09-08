using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LevelManager;

namespace CanvasManager
{
    public class MenuCanvas : MonoBehaviour
    {
        [SerializeField] GameObject menuCanvas;
        [SerializeField] GameObject guideCanvas;
        [SerializeField] GameObject whiteCurtain;

        CanvasGroup guildCanvasAlpha;
        CanvasGroup menuCanvasAlpha;
        CanvasGroup whiteCurtainAlpha;

        SceneLoader sceneLoader;
        private void Start()
        {
            guildCanvasAlpha = guideCanvas.GetComponent<CanvasGroup>();
            menuCanvasAlpha = menuCanvas.GetComponent<CanvasGroup>();
            whiteCurtainAlpha = whiteCurtain.GetComponent<CanvasGroup>();

            guildCanvasAlpha.alpha = 0;
            guideCanvas.SetActive(false);
            whiteCurtain.SetActive(false);
            sceneLoader = FindObjectOfType<SceneLoader>();

        }
        public void IntoGuideCanvas()
        {
            menuCanvasAlpha.alpha = 0;
            guildCanvasAlpha.alpha = 1;

            menuCanvas.SetActive(false);
            guideCanvas.SetActive(true);
        }

        public void OutGuideCanvas()
        {
            menuCanvasAlpha.alpha = 1;
            guildCanvasAlpha.alpha = 0;

            menuCanvas.SetActive(true);
            guideCanvas.SetActive(false);
        }

        public void SetActiveCurtain()
        {
            StartCoroutine(nameof(LoadSmoothScene));
        }

        IEnumerator LoadSmoothScene()
        {
            whiteCurtain.SetActive(true);

            yield return new WaitForSeconds(1.2f);

            sceneLoader.LoadNextScene();
        }
    }
}

