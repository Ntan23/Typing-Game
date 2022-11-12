using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    Image healthBar;
    float startingHealth;
    public static bool canUpdate = true;
    
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        startingHealth = PlayerStats.health;
    }

    // Update is called once per frame
    void Update()
    {
        if(!canUpdate)
        {
            return;
        }
        else if(canUpdate)
        {
            UpdateHealthBar();
            canUpdate = false;
        }
    }

    void UpdateHealthBar()
    {
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
}
