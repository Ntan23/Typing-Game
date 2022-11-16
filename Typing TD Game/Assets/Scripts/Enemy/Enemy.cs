using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	private float startHealth = 100;
	private float health;
	private int reward = 50;
	public GameObject deathEffect;

	[Header("Unity Stuff")]
	// public Image healthBar;
	private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
    }

	public void TakeDamage (float damage)
	{
		health -= damage;
        Debug.Log("Health : "+ health);

		// healthBar.fillAmount = health / startHealth;

		if (health <= 0 && !isDead)
		{
			Die();
		}
	}

	void Die ()
	{
		isDead = true;

		PlayerStats.money += reward;
        MoneyUI.needUpdate = true;

		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		
        Destroy(effect,5f);

		Destroy(gameObject);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
