﻿using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    class EnemyShooting : MonoBehaviour
    {
        #region Properties

        public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

        public GameObject bulletPrefab;
        int bulletLayer;

        public float fireDelay = 0.50f;
        float cooldownTimer = 0;

        Transform player;

        #endregion
        void Start()
        {
            bulletLayer = gameObject.layer;
        }

        // Update is called once per frame
        void Update()
        {
            if (player == null)
            {
                //Fienden hittar spelaren
                GameObject go = GameObject.FindWithTag("Player");

                if (go != null)
                {
                    player = go.transform;
                }
            }

            cooldownTimer -= Time.deltaTime;

            if (cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < 4) //Skjuter spelaren inom en viss distans
            {
                // SHOOT!
                cooldownTimer = fireDelay;

                Vector3 offset = transform.rotation * bulletOffset;

                GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
                bulletGO.SetActive(true);
                //Destroy(bulletGO, 3f); //Klonerna av skottet förstörs här
                bulletGO.layer = bulletLayer;
            }
        }
    }
}
