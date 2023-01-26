using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void retry()
    {
        Time.timeScale = 1;
        WordManager.hasActiveWord= false;
        WaveSpawner.nextwave = false;
        WaveSpawner.waveIndex = 0;
        PlayerStats.moneyBar = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        WordManager.hasActiveWord= false;
        WaveSpawner.waveIndex = 0;
        PlayerStats.moneyBar = 0;
        SceneManager.LoadScene("Main Menu");
    }
}
