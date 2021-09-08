using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Enemy;
using Core;

namespace Player
{
    public class ShipController : MonoBehaviour
    {
        [SerializeField] float StartSpeed = 10f;
        [SerializeField] float ingameSpeed;
        [SerializeField] float lookRotateSpeed = 90f;
        [SerializeField] ParticleSystem[] thrustVFX;
        [SerializeField] ParticleSystem[] explodeEffect;
        [SerializeField] GameObject[] lasers;
        [SerializeField] int damage = 20;
        [SerializeField] AudioClip laserSound;
        [SerializeField] GameObject gameOverCanvas;


        float thrustSpeed;
        float horizontalInput;
        Vector2 lookInput, screenCenter, mouseDistance;
        AudioSource audioSource;


        Health health;
        EnemyController enemyController;
        ZoomCamera zoomCamera;

        void Start()
        {
            ingameSpeed = StartSpeed;
            thrustSpeed = StartSpeed * 3;

            screenCenter.x = Screen.width * .5f;
            screenCenter.y = Screen.height * .5f;

            health = GetComponent<Health>();
            enemyController = FindObjectOfType<EnemyController>();
            zoomCamera = GetComponent<ZoomCamera>();
            audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            MoveForward();
            RotateShip();
            Shoot();
            SpeedUp();
        }

        private void SpeedUp()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                ingameSpeed = thrustSpeed;
                foreach (var obj in thrustVFX)
                {
                    obj.Play();
                }
                StartCoroutine(zoomCamera.ZoomInCamera());
            }
            else
            {
                ingameSpeed = StartSpeed;
                foreach (var obj in thrustVFX)
                {
                    obj.Stop();
                }
                StartCoroutine(zoomCamera.ZoomOutCamera());
            }
        }

        #region Ship Manourver
        void MoveForward()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * ingameSpeed);
        }

        void RotateShip()
        {
            horizontalInput = Input.GetAxis("Horizontal");
            float xPos = horizontalInput * Time.deltaTime * lookRotateSpeed;
            lookInput.x = Input.mousePosition.x;
            lookInput.y = Input.mousePosition.y;

            mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
            mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

            transform.Rotate(Mathf.Clamp(-mouseDistance.y * Time.deltaTime * lookRotateSpeed, -20f, 20f), mouseDistance.x * Time.deltaTime * lookRotateSpeed, -xPos, Space.Self);

        }
        #endregion

        #region Shoot
        void Shoot()
        {
            if (Input.GetMouseButton(0))
            {
                ActivateLaser();
            }
            else
            {
                DeactivateLaser();
            }
        }

        private void ActivateLaser()
        {
            foreach (var laser in lasers)
            {
                var emissionModule = laser.GetComponent<ParticleSystem>().emission;
                emissionModule.enabled = true;
            }
            audioSource.PlayOneShot(laserSound, .1f);
        }

        private void DeactivateLaser()
        {
            foreach (var laser in lasers)
            {
                var emissionModule = laser.GetComponent<ParticleSystem>().emission;
                emissionModule.enabled = false;
            }
        }

        #endregion

        #region Health Decrease Affect
        private void OnParticleCollision(GameObject other)
        {
            health.DecreaseHitPoint(enemyController.ReturnDamageToPlayer());
            if (health.GetHitPoints() < 0)
            {
                StartCrashSequence();
            }
        }

        private void StartCrashSequence()
        {
            foreach (var obj in explodeEffect)
            {
                obj.Play();
            }
            GetComponent<ShipController>().enabled = false;
            GetComponent<MeshCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            BroadcastMessage("LoseCondition");
        }
        #endregion

        public int ReturnDamage()
        {
            return damage;
        }
    }
}

