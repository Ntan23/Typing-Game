using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{

    public GameObject wordPrefab;

    // For reference only could be change
    public Transform wordCanvas;
    public WordDisplay SpawnTheWord()
    {
        // create obj
        GameObject wordObj = Instantiate(wordPrefab, wordCanvas);

        // get reference from WordDisplay Script
        WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();

        return wordDisplay;
    }
}