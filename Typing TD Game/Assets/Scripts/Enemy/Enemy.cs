using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	private float startHealth = 100;
	private float health;
	private int reward;
	public GameObject deathEffect;

	[Header("Unity Stuff")]
	public Image healthBar;
	public GameObject healthImage;
	private bool isDead = false;
	GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
		gameManager = GameManager.instance;
        health = startHealth;
		healthBar.color = Color.green;
    }

	public void TakeDamage (float damage)
	{
		health -= damage;
		
		UpdateHealthBar();

		if(health <= 0 && !isDead) 
		{
			Debug.Log("Enemy Killed!");
			Die();
		}
	}

	void Die ()
	{
		isDead = true;

		PlayerStats.moneyBar++;
		gameManager.UpdateMoneyBar();

		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		
        Destroy(effect,3f);

		Destroy(gameObject);
	}

	void UpdateHealthBar()
    {
        healthBar.fillAmount = health/startHealth;

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

    // Update is called once per frame
    void Update()
    {
        healthImage.transform.rotation = Quaternion.Euler(40,0,0);
    }
}
