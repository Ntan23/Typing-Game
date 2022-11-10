using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour
{
   private Text text;

    public void ShowWord(string word){
        text = GetComponent<Text>();
        text.text = word;
    }

    public void removeAlpha()
    {
        text.text = text.text.Remove(0,1);
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
