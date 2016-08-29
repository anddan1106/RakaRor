using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    class EnemyShooting : MonoBehaviour
    {
        #region Properties
        public AudioClip shotSound;

        public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

        public GameObject bulletPrefab;
        int bulletLayer;

        public float fireDelay = 3f;
        public float soundDelay = 3f;

        float cooldownTimer = 0;
        float FireSoundDelay = 3f;


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

            if (FireSoundDelay == 3 && player != null && Vector3.Distance(transform.position, player.position) < 6)
            {
                GetComponent<AudioSource>().PlayOneShot(shotSound);

                FireSoundDelay -= Time.deltaTime;
            }
            else if (FireSoundDelay!=3)
            {
            FireSoundDelay -= Time.deltaTime;
            cooldownTimer -= Time.deltaTime;
            }
            if (player != null && Vector3.Distance(transform.position, player.position) < 6) //Skjuter spelaren inom en viss distans
            {
                //cooldownTimer = fireDelay;
                if (FireSoundDelay <= 1)
                {

                    // SHOOT!

                    Vector3 offset = transform.rotation * bulletOffset;

                    GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
                    bulletGO.SetActive(true);
                    //Destroy(bulletGO, 3f); //Klonerna av skottet förstörs här
                    bulletGO.layer = bulletLayer;
                    FireSoundDelay = soundDelay;
                }

            }
        }
    }
}
