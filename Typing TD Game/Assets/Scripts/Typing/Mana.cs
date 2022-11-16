using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{

    private int ManaCount = 0;

    public Text Manatext;

    // Start is called before the first frame update
    void Start()
    {
        Manatext = GetComponent<Text>();
    }

    public void IncreaseMana()
    {
        ManaCount++;
        Manatext.text = "Mana : "+ManaCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
