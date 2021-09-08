using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace LevelManager
{
    public class ScoreManagement : MonoBehaviour
    {
        [SerializeField] TMP_Text scoreText;
        [SerializeField] int scorePerEnemy = 20;
        int currentScore = 0;
        // Start is called before the first frame update
        void Start()
        {
            scoreText.GetComponent<TMP_Text>();
        }

        public void AddScore()
        {
            currentScore += scorePerEnemy;
            scoreText.text = $"Score: {currentScore}";
        }
    }
}
