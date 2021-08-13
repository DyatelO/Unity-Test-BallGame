using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUP : MonoBehaviour
{
    [SerializeField] private GameObject powerupPrefab;
    
    public int powerupCount;

    void FixedUpdate()
    {
        powerupCount = FindObjectsOfType<PowerUP>().Length;

        RespawnPowerUp(0);
    }

    private void RespawnPowerUp(int respawnCount)
    {
        if((SpawnEnemy.waveNumber == SpawnEnemy.enemyCount) && powerupCount < 1)
        {
            Instantiate(powerupPrefab, SpawnEnemy.GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }
}
