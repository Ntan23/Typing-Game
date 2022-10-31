using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] wordList =
    {
        "jar","tap","pickle","accept","visitor","ink","prevent","disgusting","halting","relax","arm","resolute","grateful","skinny","early","disarm","parsimonious","gratis","signal"
    };

    public static string GetRandomWord()
    {
        int randIndex = Random.Range(0, wordList.Length);
        string randWord = wordList[randIndex];

        return randWord;
    }

    private void Start() {

        //Debug.Log(wordList.Length);
    }
}
