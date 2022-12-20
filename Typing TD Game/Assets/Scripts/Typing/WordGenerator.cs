using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WordGenerator : MonoBehaviour
{
    [Header("Text Asset")]
    #region TextAsset
    [SerializeField]
    private TextAsset textAssetwordList;

    [SerializeField]
    private TextAsset textAssetindoList;

    #endregion

    #region List
    private static string[] wordList;

    private static string[] indoList;

    #endregion
   
    public static string indoWord;

    public static string GetRandomWord()
    {
        int randIndex = Random.Range(0, wordList.Length);
        string randWord = wordList[randIndex];
        indoWord = indoList[randIndex];
        return randWord;
    }

    private void Awake()
    {
        ReadTextAsset();
        // debug purpose
        // Debug.Log(wordList.Length);
        // Debug.Log(indoList.Length);
    }

    private void ReadTextAsset()
    {
        wordList = textAssetwordList.text.Split(new string[] {"," ,"\n"}, System.StringSplitOptions.None);
        indoList = textAssetindoList.text.Split(new string[] {"," ,"\n"}, System.StringSplitOptions.None);
    }
}
