using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject chickenPrefab;

    private EnemyHealth enemyHealth;
    private int waveNumber = 1;

    void Start()
    {
        enemyHealth = chickenPrefab.GetComponent<EnemyHealth>();
        SpawnEnemyWave(waveNumber);
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("chickenMob").Length <= 0)
        {
            waveNumber += 1;
            enemyHealth.maxHealth = waveNumber;
            SpawnEnemyWave(waveNumber);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        new Vector3(-126, 2, 6);
        float SpawnPosX = Random.Range(-129, -123);
        float SpawnPosZ = Random.Range(1, 11);
        Vector3 _randomPos = new Vector3(SpawnPosX, 2, SpawnPosZ);

        return _randomPos;
    }

    void SpawnEnemyWave(int waveNumber)
    {
        GenerateSpawnPosition();

        for (int i = 0; i < waveNumber; i++)
        {
            Instantiate(chickenPrefab, GenerateSpawnPosition(), chickenPrefab.transform.rotation);
        }
    }

}

