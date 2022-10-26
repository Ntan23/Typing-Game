using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5.0f;
    public float countdown = 2.0f;
    private int waveIndex = 0;
    public float delayTime;

    private void Update()
    {
        if(countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for(int i = 0;i < waveIndex;i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(delayTime);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab,spawnPoint.position,spawnPoint.rotation);
    }
}
