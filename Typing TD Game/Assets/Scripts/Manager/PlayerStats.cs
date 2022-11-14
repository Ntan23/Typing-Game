using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 500;
    public static float health;
    public float startingHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        money = startMoney;
        health = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
