using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CanvasManager
{
    public class LevelManagement : MonoBehaviour
    {
        [SerializeField] GameObject enemyPool;
        [SerializeField] GameObject gameOverCanvas;
        [SerializeField] GameObject winStageCanvas;

        int numberOfEnemy;
        void Start()
        {
            gameOverCanvas.SetActive(false);
            winStageCanvas.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            numberOfEnemy = enemyPool.transform.childCount;
            if (numberOfEnemy <= 0)
            {
                WinCondition();
            }
        }

        public int GetEnemyNumber()
        {
            return numberOfEnemy;
        }

        void WinCondition()
        {
            winStageCanvas.SetActive(true);
        }

        public void LoseCondition()
        {
            gameOverCanvas.SetActive(true);
        }
    }
}

