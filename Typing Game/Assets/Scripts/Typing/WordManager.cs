using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{

    // For Translating Purpose
    /*public Dictionary<string, string> kamus = new Dictionary<string, string>()
    {
        {"ayam","chicken"},
        {"anjing","dog"}

    }; */
    public List<Word> words;

    [SerializeField]
    private bool hasActiveWord;
    private Word activeWord;

    // Start is called before the first frame update
    private void Start()
    {
        // if(kamus.ContainsKey("ayam"))
        // {
        //     Debug.Log(kamus["anjing"]);
        // }
        
        AddWordToList();
        AddWordToList();
    }


    public void AddWordToList()
    {
       Word word = new Word(WordGenerator.GetRandomWord());

       //Debug Purpose show random word
       //Debug.Log(word.word);

       words.Add(word);
    }
    
    public void  TypingLetter(char alphabet)
    {
        if(hasActiveWord)
        {
            // Check if alphabet was next
            if(activeWord.GetNextAlphabet() == alphabet)
            {
                activeWord.TypeAlphabet();
            }
                // Remove the mark from the Word
            else if(Word.AlphaIdx == 3)
            {
                Word.AlphaIdx = 0;
                hasActiveWord = false;
            }
        }
        else
        {
            foreach(Word word in words)
            {
                if(word.GetNextAlphabet() == alphabet)
                {
                    // mark curr active word
                    activeWord = word;

                    // mark the bool
                    hasActiveWord = true;

                    word.TypeAlphabet();
                    break;
                }
            }
        }

        if(hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
