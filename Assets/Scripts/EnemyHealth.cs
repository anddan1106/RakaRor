using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;


class EnemyHealth : NetworkBehaviour
{
    public const int maxHealth = 1;
    [SyncVar]
    public int currentHealth = maxHealth;
    public bool destroyOnDeath;
    private NetworkStartPosition[] spawnPoints;

    void Start()
    {
        if (isLocalPlayer)
        {
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("it is true");

        if (!isServer)
        {
            return;
        }

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            if (destroyOnDeath)
            {
                Destroy(gameObject);
            }
        }
    }

    //[ClientRpc]
    //void RpcRespawn()
    //{
    //    if (isLocalPlayer)
    //    {
    //        Vector3 spawnPoint = Vector3.zero;

    //        if (spawnPoints != null && spawnPoints.Length > 0)
    //        {
    //            spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
    //        }
    //        transform.position = spawnPoint;
    //    }
    //}

}

