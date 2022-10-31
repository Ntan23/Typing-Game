using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word 
{
   public string word;

[SerializeField]
   public static int AlphaIdx;

    // Constructor
   public Word(string word)
   {
    this.word = word;
    AlphaIdx = 0;
   }

   public char GetNextAlphabet()
   {
        return word[AlphaIdx];
   }

   public void TypeAlphabet()
   {
        AlphaIdx++;
        // Remove alphabet on screen
   }

   public bool WordTyped()
   {
     bool wordTyped = (AlphaIdx >= word.Length);
     if(wordTyped)
     {
        // Remove word on screen
     }
     return wordTyped;
   }
}
