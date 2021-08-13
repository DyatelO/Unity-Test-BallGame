using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    private static float spawnRange = 10f;
    public static int enemyCount;
    public static int waveNumber = 1;

    void Start()
    {
        SpawnEnemyWaves(waveNumber);
    }

    void FixedUpdate()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        RespawnEnemy(1);
    }

    private void SpawnEnemyWaves( int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private void RespawnEnemy(int countEnemy)
    {
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWaves(waveNumber);   
        }
    }

    public static Vector3 GenerateSpawnPosition()
    {
        float spawnPositonX = Random.Range(-spawnRange, spawnRange);
        float spawnPositonZ = Random.Range(-spawnRange, spawnRange);        

        Vector3 randomPosition = new Vector3(spawnPositonX, 0, spawnPositonZ);

        return randomPosition;
    }
}
