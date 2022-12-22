using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordManager : MonoBehaviour
{

    // For Translating Purpose
    /*public Dictionary<string, string> kamus = new Dictionary<string, string>()
    {
        {"ayam","chicken"},
        {"anjing","dog"}

    }; */
    #region Word
    [Header("Word Section")]
    public List<Word> words;

    public WordSpawner wordSpawner;

    public WordDisplay wordDisplay;

    [SerializeField]
    private bool hasActiveWord;

    [SerializeField]
    private Word activeWord;

    #endregion
    

    // #region Mana
    // [Header("Mana Section")]

    // #endregion

    [SerializeField]
    // private Animator anim;
    private CooldownTimer cooldownTimer;
    private Translation translation;
    public static int manaCount = 10;

   GameManager gm;


    // Start is called before the first frame update
    private void Start()
    {
        gm = GameManager.instance;
        // if(kamus.ContainsKey("ayam"))
        // {
        //     Debug.Log(kamus["anjing"]);
        // }
        cooldownTimer = FindObjectOfType<CooldownTimer>();
        AddWordToList();
        // AddWordToList();
        translation = FindObjectOfType<Translation>();
    }


    public void AddWordToList()
    {
       wordDisplay = wordSpawner.SpawnTheWord();

       Word word = new Word(WordGenerator.GetRandomWord(), wordDisplay);

       //Debug Purpose show random word
       //Debug.Log(word.word);
       
       words.Add(word);
       // play animation
    //    anim.Play("TextFadein");
    }
    
    public void TypingLetter(char alphabet)
    {
        if(hasActiveWord)
        {
            // Check if alphabet was next
            if(activeWord.GetNextAlphabet() == alphabet || activeWord.GetNextAlphabet() == alphabet)
            {
                activeWord.TypeAlphabet();
            }


            // Change active word to another word
            // else if(Word.AlphaIdx == 3)
            // {
            //     // Word.AlphaIdx = 0;
            //     hasActiveWord = false;
            // }
        }
        else
        {
            foreach(Word word in words)
            {
                Word.AlphaIdx = 0;

                //Debug purpose v
                // Debug.Log(Word.AlphaIdx);
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
            if(gm.ManaCount < gm.MaxMana)
            {
                gm.IncreaseMana(manaCount);
            }
           
            hasActiveWord = false;
            words.Remove(activeWord);

            // Debug purpose indoWord
            // Debug.Log(WordGenerator.indoWord);

            translation.gameObject.SetActive(true);
            translation.showTranslation(WordGenerator.indoWord);
            cooldownTimer.gameObject.SetActive(true);
            StartCoroutine(WordDelay(1.5f));
            // cooldownTimer.Begin(3);\
        }
    }

    public IEnumerator WordDelay(float Time)
    {
        cooldownTimer.Begin(Time);
        yield return new WaitForSeconds(Time+0.5f);
        //Debug purpose Time
        //Debug.Log(Time);
        translation.isShow = false;
        AddWordToList();
    }

  
    // Update is called once per frame
    void Update()
    {
        
    }
}
