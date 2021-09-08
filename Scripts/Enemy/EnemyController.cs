using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Core;
using Player;
using LevelManager;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] float movementSpeed = 10f;
        [SerializeField] GameObject[] lasers;
        [SerializeField] ParticleSystem[] explodeEffect;
        [SerializeField] int damage = 20;

        RaycastHit hit;

        GameObject player;
        Health health;
        ShipController shipController;
        ScoreManagement scoreManagement;
        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            health = GetComponent<Health>();
            shipController = FindObjectOfType<ShipController>();
            scoreManagement = FindObjectOfType<ScoreManagement>();
        }

        // Update is called once per frame
        void Update()
        {
            Turn();
            Move();
            Attack();
        }

        private void Move()
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }

        private void Turn()
        {
            Vector3 distance = player.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(distance);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
        }

        #region Attack Player
        private void Attack()
        {
            DeactivateLaser();
            if (Physics.Raycast(transform.position, transform.forward, out hit, 200f))
            {
                if (hit.transform.name != "Player")
                {
                    DeactivateLaser();
                }
                else
                {
                    ActiveLaser();
                }
            }
        }

        private void DeactivateLaser()
        {
            foreach (var laser in lasers)
            {
                var emissionModule = laser.GetComponent<ParticleSystem>().emission;
                emissionModule.enabled = false;
            }
        }

        private void ActiveLaser()
        {
            foreach (var laser in lasers)
            {
                var emissionModule = laser.GetComponent<ParticleSystem>().emission;
                emissionModule.enabled = true;
            }
        }
        #endregion

        private void OnParticleCollision(GameObject other)
        {
            health.DecreaseHitPoint(shipController.ReturnDamage());
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
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject, 1.5f);
            scoreManagement.AddScore();
        }

        public int ReturnDamageToPlayer()
        {
            return damage;
        }

    }
}

