using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] GameObject enemy;
        // Start is called before the first frame update
        private void Start()
        {
            StartCoroutine(nameof(SpawnEnemy));
        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator SpawnEnemy()
        {
            for (int i = 0; i < 3; i++)
            {
                float randomRot = Random.Range(0f, 90f);
                float randomPos = Random.Range(transform.position.x + 20f, transform.position.x + 40f);

                Quaternion spawnAngle = Quaternion.Euler(randomRot, randomRot, randomRot);
                Vector3 spawnPoint = new Vector3(randomPos, randomPos, randomPos);
                GameObject enemyShip = Instantiate(enemy, spawnPoint, spawnAngle);
                enemyShip.transform.parent = GameObject.FindWithTag("EnemyPlaceholder").transform;

                yield return new WaitForSeconds(3f);
            }
        }
    }

}
