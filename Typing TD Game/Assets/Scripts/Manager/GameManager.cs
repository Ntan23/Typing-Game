using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance =  this;
        }
        else if(instance != null)
        {
            return;
        }
    }

    public bool gameEnded;
    float startingHealth;
    [SerializeField] private float EnemyHitDamage;
    public GameObject gameOverUI;
    [SerializeField] private Image moneyBarImg;
    [SerializeField] private Image healthBar;
    public float ManaCount = 0f;
    public float MaxMana = 100f;
    public Image ManaImg;

    // Start is called before the first frame update
    void Start()
    {
        gameEnded = false;
        startingHealth = PlayerStats.health;
        healthBar.color = Color.green;
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

     public void UpdateMoneyBar()
	{
		moneyBarImg.fillAmount = PlayerStats.moneyBar/5;
		
		if(moneyBarImg.fillAmount > 0.5f)
        {
            moneyBarImg.color = Color.green;
        }
        else if(moneyBarImg.fillAmount <= 0.5f && moneyBarImg.fillAmount > 0.2f)
        {
            moneyBarImg.color = Color.yellow;
        }
        else if(moneyBarImg.fillAmount <= 0.2f)
        {
            moneyBarImg.color = Color.red;
        }

        if(moneyBarImg.fillAmount == 1)
        {
            StartCoroutine(ResetBarAndAddMoney());
        }
	}

    IEnumerator ResetBarAndAddMoney()
    {
        yield return new WaitForSeconds(0.8f);
        PlayerStats.money += 1;
		MoneyUI.needUpdate = true;
		PlayerStats.moneyBar = 0;
        moneyBarImg.fillAmount = 0;
    }

    public void HitDamage()
    {
        PlayerStats.health -= EnemyHitDamage;

        healthBar.fillAmount = PlayerStats.health/startingHealth;

        if(healthBar.fillAmount > 0.5f)
        {
            healthBar.color = Color.green;
        }
        else if(healthBar.fillAmount <= 0.5f && healthBar.fillAmount > 0.2f)
        {
            healthBar.color = Color.yellow;
        }
        else if(healthBar.fillAmount <= 0.2f)
        {
            healthBar.color = Color.red;
        }
    }

    public void IncreaseMana(int manaCount)
    {
        if(ManaCount <= 100)
        {
            ManaCount += manaCount;
        }
        
        UpdateManaBar();
    }

    public void DecreaseMana(int manaCost)
    {
        ManaCount-=manaCost;
        UpdateManaBar();
        // Debug.Log(ManaCount);
    }

    public void UpdateManaBar()
    {
        ManaImg.fillAmount = ManaCount/MaxMana;
    }
}
