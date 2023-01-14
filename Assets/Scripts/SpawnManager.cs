using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[]  enemyPrefabs;
    [SerializeField] GameObject powerUpPrefab;
    float spawnRange = 9f;
    public int enemyCount;
    public int waveNumber = 1;

    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerUp();
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyAI>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerUp();

        }
    }

    private void SpawnPowerUp()
    {
        Instantiate(powerUpPrefab, GenerateRandomPos(), gameObject.transform.rotation);
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefabs[enemyIndex], GenerateRandomPos(), enemyPrefabs[enemyIndex].    transform.rotation);
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
