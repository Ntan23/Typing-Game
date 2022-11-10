using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordDisplay : MonoBehaviour
{
    // private Text text;
    private TextMeshProUGUI text;

    public void ShowWord(string word)
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = word;
    }

    public void removeAlpha()
    {
        text.text = text.text.Remove(0,1);
        text.fontStyle = FontStyles.Italic | FontStyles.Bold;
        text.color = Color.yellow;
    }

    public void RemoveWord()
    {
        // pool idk
        Destroy(gameObject);
    }

    private void Update() {
        
    }
}
