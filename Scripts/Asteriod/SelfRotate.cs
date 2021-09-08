using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteriod
{
    public class SelfRotate : MonoBehaviour
    {
        [SerializeField] float speed = 1f;

        // Update is called once per frame
        void Update()
        {
            float rotateSpeed = speed * Time.deltaTime;
            transform.Rotate(0f, rotateSpeed, rotateSpeed);
        }
    }
}

