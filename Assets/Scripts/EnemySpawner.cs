using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    #region Properties
    public GameObject enemyPrefab;
    float spawnDistance = 12f;
    float enemyRate = 5f;
    float nextEnemy = 1f;
    #endregion
	
	// Update is called once per frame
	void Update () {

        nextEnemy -= Time.deltaTime;

        if (nextEnemy <= 0)
        {
            nextEnemy = enemyRate;
            enemyRate *= 0.9f; // hur ofta de spawnar
            if (enemyRate < 2f)
            {
                enemyRate = 2f;
            }

            Vector3 offset = Random.onUnitSphere;
            offset.z = 0;
            offset = offset.normalized * spawnDistance;
            Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
        }
	}
}
