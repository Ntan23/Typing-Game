using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public static float ManaCount = 0f;

    public static float MaxMana = 100f;
    // public Text Manatext;

    public Image ManaImg;

    // Start is called before the first frame update
    void Start()
    {
        ManaImg = GetComponent<Image>();
        // Manatext = GetComponent<Text>();
    }

    public static void IncreaseMana()
    {
        ManaCount+=10f;
        // Manatext.text = "Mana : "+ManaCount.ToString();
        // Debug.Log(ManaCount);
    }

    // Update is called once per frame
    void Update()
    {
        // if(ManaCount <= MaxMana)
        // {
        //     ManaImg.fillAmount = ManaCount;
        // }

        // Debug.Log(ManaCount);
        ManaImg.fillAmount = (ManaCount / MaxMana);


        // if(ManaCount == MaxMana)
        // {
        //     ManaImg.fillAmount = 1;
        // }
    }
}
