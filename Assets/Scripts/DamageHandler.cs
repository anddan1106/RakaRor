using UnityEngine;
using System.Collections;
using System;

public class DamageHandler : MonoBehaviour
{
    #region Properties
    public float invulnPeriod = 0;
    public int health = 1;
    float invulnTimer = 0;
    int correctLayer;
    SpriteRenderer spriteR;
    #endregion
    void Start()
    {
        correctLayer = gameObject.layer;

        spriteR = GetComponent<SpriteRenderer>();
        if (spriteR == null)
        {
            spriteR = transform.GetComponentInChildren<SpriteRenderer>();

            if (spriteR == null)
            {

                Debug.LogError("Object '" + gameObject.name + "' has no sprite renderer");
            }
        }
    }



    void OnTriggerEnter2D(Collider2D obj)
    {
        Debug.Log("Trigger!");

        if (obj.gameObject.tag == "Wall")
        {
            Debug.Log("Träff på vägg!");
            Destroy(this);
            return;
        }
        else
        {
            health--;
            invulnTimer = invulnPeriod;
            gameObject.layer = 10;
        }

    }

    void Update()
    {
        if (invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;
        }

        if (invulnTimer <= 0)
        {
            gameObject.layer = correctLayer;

            if (spriteR != null)
            {
                spriteR.enabled = true;
            }
        }
        else
        {

            if (spriteR != null)
            {
                spriteR.enabled = !spriteR.enabled;
            }
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
