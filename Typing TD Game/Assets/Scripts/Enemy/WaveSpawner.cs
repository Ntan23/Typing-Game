using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5.0f;
    public float countdown = 2.0f;
    private int waveIndex = 0;
    public TextMeshProUGUI waveCountdownText;
    public TextMeshProUGUI waveIndexText;
    GameManager gm;
    
    void Start()
    {
        gm = GameManager.instance;
    }

    private void Update()
    {
        if(enemiesAlive > 0)
        {   
            return;
        }

        if(countdown <= 0)
        {   
            ConvertManaToMoney();
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown,0f,Mathf.Infinity);

        waveCountdownText.text = countdown.ToString("00.00");
    }

    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveIndex];

        for(int i = 0;i < wave.enemyCount;i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1.0f/wave.rate);
        }
        
        waveIndex++;

        waveIndexText.text = "Wave " + waveIndex.ToString() + "/" + waves.Length.ToString();

        if(waveIndex == waves.Length)
        {
            Debug.Log("You Win The Game !");
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy,spawnPoint.position,spawnPoint.rotation);
        enemiesAlive++;
    }

    void ConvertManaToMoney()
    {
        PlayerStats.money += gm.ManaCount*0.1f;
        MoneyUI.needUpdate = true;
        gm.ManaCount = 0;
        gm.UpdateManaBar();
    }

    public float GetEnemyStartSpeed()
    {
        return waves[waveIndex].enemy.GetComponent<NavMeshAgent>().speed;
    }
}
