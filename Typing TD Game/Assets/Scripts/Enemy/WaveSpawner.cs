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
    public static int waveIndex;
    public TextMeshProUGUI waveCountdownText;
    public TextMeshProUGUI waveIndexText;
    public static bool nextwave = false;
    
    GameManager gm;
    AudioManager am;
    
    void Start()
    {
        gm = GameManager.instance;
        am = AudioManager.instance;
        waveIndex = 0;
        waveIndexText.text = "Wave " + waveIndex.ToString() + "/" + waves.Length.ToString();
    }

    private void Update()
    {
        if(enemiesAlive > 0)
        {   
            return;
        }

        if(enemiesAlive == 0 && nextwave == false)
        {
            ConvertManaToMoney();
            nextwave = true;
        }

        if(countdown <= 0 && nextwave && !gm.gameEnded)
        {   
            am.PlayAudio("WaveSpawn");
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            nextwave = false;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown,0f,Mathf.Infinity);

        waveCountdownText.text = countdown.ToString("00.00");
    }

    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveIndex];

        enemiesAlive = wave.enemyCount;

        waveIndex++;
       
        waveIndexText.text = "Wave " + waveIndex.ToString() + "/" + waves.Length.ToString();

        if(waveIndex == waves.Length)
        {
            this.enabled = false;
        }

        for(int i = 0;i < wave.enemyCount;i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1.0f/wave.rate);
        }

    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy,spawnPoint.position,spawnPoint.rotation);
    }

    void ConvertManaToMoney()
    {
        am.PlayAudio("Currency");
        PlayerStats.money += Mathf.Floor(gm.ManaCount*0.05f);
        MoneyUI.needUpdate = true;
        gm.ManaCount = 0;
        gm.UpdateManaBar();
    }
}
