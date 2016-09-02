using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;


class Health : NetworkBehaviour
{
    public const int maxHealth = 10;
    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth = maxHealth;
    public RectTransform healthBar;
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
            else
            {
                if (gameObject.GetComponent<SetupLocalPlayer>().SpawnsLeft())
                {
                    Debug.Log(gameObject.GetComponent<SetupLocalPlayer>().spawns);
                    currentHealth = maxHealth;
                    RpcRespawn();
                }
                else
                {
                    gameObject.GetComponent<SetupLocalPlayer>().SendScoreToDb();
                    Destroy(gameObject);

                }
            }
        }
    }

    void OnChangeHealth(int health)
    {
        healthBar.sizeDelta = new Vector3(health * 5, healthBar.sizeDelta.y);
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            Vector3 spawnPoint = Vector3.zero;

            if (spawnPoints != null && spawnPoints.Length > 0)
            {
                spawnPoint = spawnPoints[Random.Range(0, 3)].transform.position;
            }
            transform.position = spawnPoint;
        }
    }

}

