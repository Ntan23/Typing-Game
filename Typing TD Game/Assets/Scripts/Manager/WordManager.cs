using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordManager : MonoBehaviour
{

    #region Word
    [Header("Word Section")]
    public List<Word> words;

    public WordSpawner wordSpawner;

    public WordDisplay wordDisplay;

    public static bool hasActiveWord = false;

    [SerializeField]
    private Word activeWord;

    #endregion
    

    // #region Mana
    [Header("Mana Section")]
    [SerializeField]
    // private Animator anim;
    private CooldownTimer cooldownTimer;
    private Translation translation;
    public int manaCount = 15;

    GameManager gm;
    AudioManager am;


    // Start is called before the first frame update
    private void Start()
    {
        gm = GameManager.instance;
        am = AudioManager.instance;

        cooldownTimer = FindObjectOfType<CooldownTimer>();
        AddWordToList();
        translation = FindObjectOfType<Translation>();
    }


    public void AddWordToList()
    {
        wordDisplay = wordSpawner.SpawnTheWord();

        Word word = new Word(WordGenerator.GetRandomWord(), wordDisplay);

        //Debug Purpose show random word
        //Debug.Log(word.word);
        am.PlayAudio("WordSpawn");
        words.Add(word);
        
        // play animation
        //anim.Play("TextFadein");
    }
    
    public void TypingLetter(char alphabet)
    {
        if(hasActiveWord)
        {
            if(activeWord.GetNextAlphabet() == alphabet || activeWord.GetNextAlphabet() == alphabet)
            {
                activeWord.TypeAlphabet();
                am.PlayAudioShot("Typing");
            }
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
           
            am.PlayAudio("TypeComplete");
            hasActiveWord = false;
            words.Remove(activeWord);

            // Debug purpose indoWord
            // Debug.Log(WordGenerator.indoWord);

            translation.gameObject.SetActive(true);
            translation.showTranslation(WordGenerator.indoWord);
            cooldownTimer.gameObject.SetActive(true);
            StartCoroutine(WordDelay(1.5f));
            // cooldownTimer.Begin(3);
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