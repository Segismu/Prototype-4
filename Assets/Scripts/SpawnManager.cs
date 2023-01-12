using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject  enemyPrefab;
    float spawnRange = 9f;
    public int enemyCount;

    void Start()
    {
        SpawnEnemyWave(2);
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyAI>().Length;

        if (enemyCount == 0)
        {
            SpawnEnemyWave(1);
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomPos(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateRandomPos()
    {
        float spawnRangeX = Random.Range(-spawnRange, spawnRange);
        float spawnRangeZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnRangeX, 0, spawnRangeZ);
        return randomPos;
    }
}
