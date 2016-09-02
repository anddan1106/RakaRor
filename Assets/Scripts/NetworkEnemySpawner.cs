using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


class NetworkEnemySpawner : NetworkBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemies;
    private NetworkStartPosition[] spawnPoints;
    float enemyRate = 5f;
    float nextEnemy = 1f;

    public override void OnStartServer()
    {

        RpcSpawnEnemies();

        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8.0f, 8.0f), 0.0f, Random.Range(-8.0f, 8.0f));
            Quaternion spawnRotation = Quaternion.Euler(0.0f, Random.Range(0.0f, 180.0f), 0);

            GameObject enemy = (GameObject)Instantiate(enemyPrefab, spawnPosition, spawnRotation);
            NetworkServer.Spawn(enemy);
        }
    }
    void Update()
    {
        nextEnemy -= Time.deltaTime;

        if (nextEnemy <= 0)
        {
                nextEnemy = enemyRate;
                enemyRate *= 0.5f; // hur ofta de spawnar
            if (enemyRate < 1f)
            {
                enemyRate = 1f;
            }
            Vector3 spawnPosition = new Vector3(Random.Range(-8.0f, 8.0f), Random.Range(-8.0f, 8.0f), Random.Range(-8.0f, 8.0f));
                Quaternion spawnRotation = Quaternion.Euler(0.0f, Random.Range(0.0f, 180.0f), 0);


                Vector3 offset = Random.onUnitSphere;
                offset.z = 0;
                GameObject enemy = (GameObject)Instantiate(enemyPrefab, spawnPosition, spawnRotation);
                NetworkServer.Spawn(enemy);

            
        }
    }

    [ClientRpc]
    private void RpcSpawnEnemies()
    {

        nextEnemy -= Time.deltaTime;

        if (nextEnemy <= 0)
        {
            nextEnemy = enemyRate;
            enemyRate *= 0.9f; // hur ofta de spawnar
            if (enemyRate < 2f)
            {
                enemyRate = 2f;
                Vector3 spawnPoint = Vector3.zero;
                for (int i = 0; i < numberOfEnemies; i++)
                {
                    if (spawnPoints != null && spawnPoints.Length > 0)
                    {
                        spawnPoint = spawnPoints[Random.Range(4, 9)].transform.position;
                        GameObject enemy = (GameObject)Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
                        NetworkServer.Spawn(enemy);
                    }
                    transform.position = spawnPoint;

                }
            }

        }
    }
}

