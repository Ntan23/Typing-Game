using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] wordList =
    {
        "jar","tap","pickle","accept","visitor","ink","prevent","disgusting","halting","relax","arm","resolute","grateful","skinny","early","happy","command","free","signal"
    };

    private static string[] indoList =
    {
        "toples","tekan","acar","terima","pengunjung","tinta","mencegah","menjijikan","terhenti","santuy","lengan","tegas","syukur","kurus","awal","senang","perintah","gratis","sinyal"
    };

    public static string indoWord;

    public static string GetRandomWord()
    {
        int randIndex = Random.Range(0, wordList.Length);
        string randWord = wordList[randIndex];
        indoWord = indoList[randIndex];
        return randWord;

    
    }

    private void Start()
    {
        //Debug.Log(wordList.Length);
    }
}
