using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word 
{
   public string word;

   public static int AlphaIdx;

   private WordDisplay wordDisplay;

   private WordManager wordManager;

    // Constructor
   public Word(string word, WordDisplay wordDisplay)
   {
    this.word = word;
    AlphaIdx = 0;

    this.wordDisplay = wordDisplay;
    wordDisplay.ShowWord(word);
   }

   public char GetNextAlphabet()
   {
        return word[AlphaIdx];
   }

   public void TypeAlphabet()
   {
        AlphaIdx++;
        // Remove alphabet on screen
        wordDisplay.removeAlpha();
   }

   public bool WordTyped()
   {
     bool wordTyped = (AlphaIdx >= word.Length);
     if(wordTyped)
     {
        // Remove word on screen
         wordDisplay.RemoveWord();
     }
     return wordTyped;
   }

}
