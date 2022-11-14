using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameEnded;
    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        gameEnded = false;
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameEnded)
        {
            return;
        }

        if(PlayerStats.health <= 0)
        {
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        Time.timeScale = 0;
    }
}
