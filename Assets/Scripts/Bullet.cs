using UnityEngine;
using System.Collections;


class Bullet : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hit = collision.gameObject;
        Health health = hit.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(1);
            Debug.Log("Du är skjuten trigger");
        }
        Destroy(gameObject);
    }

}

