using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteriod
{
    public class AsteriodSpawner : MonoBehaviour
    {
        [SerializeField] GameObject asteriods;
        float randomPosX = 0f;
        float randomPosY = 0f;
        float randomPosZ = 0f;
        float minValue = 200f;
        float maxValue = 250f;
        int[,,] AsteriodArray = new int[20, 20, 20];

        void Start()
        {
            AsteriodInstantiate();
        }

        private void Update()
        {
            RotateAsteriod();
        }

        void AsteriodInstantiate()
        {
            for (int x = 0; x < AsteriodArray.GetLength(0); x++)
            {
                float xOffset = Random.Range(minValue, maxValue);
                randomPosX += xOffset;
                randomPosY = 0f;
                for (int y = 0; y < AsteriodArray.GetLength(1); y++)
                {
                    float yOffset = Random.Range(minValue, maxValue);
                    randomPosY += yOffset;
                    randomPosZ = 0f;
                    for (int z = 0; z < AsteriodArray.GetLength(2); z++)
                    {
                        float randomRot = Random.Range(-180f, 180f);

                        float zOffset = Random.Range(minValue, maxValue);
                        randomPosZ += zOffset;
                        Vector3 spawnPoint = new Vector3(randomPosX, randomPosY, randomPosZ);

                        GameObject asteriod = Instantiate(asteriods, spawnPoint, Quaternion.Euler(randomRot, randomRot, randomRot));
                        asteriod.transform.parent = GameObject.FindWithTag("AsteriodPlaceholder").transform;
                    }
                }

            }

        }

        private void RotateAsteriod()
        {
            asteriods.transform.Rotate(0f, 30f, 30f);
        }
    }
}

