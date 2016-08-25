﻿using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class MoveBullet : MonoBehaviour
    {
        public float maxSpeed = 5f;

        void Start()
        {
            transform.Rotate(0, 0, 90);
        }
        void FixedUpdate()
        {
            Vector3 pos = transform.position;
            Vector3 velocity = new Vector3(maxSpeed * Time.deltaTime, 0,  0);

            pos += transform.rotation * velocity;
            transform.position = pos;
        }

        void OnCollisionEnter2D()
        {
           // Destroy(this.gameObject);
        }
    }
}