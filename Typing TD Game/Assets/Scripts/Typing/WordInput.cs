using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour
{
    public WordManager wordManager;

    // Update is called once per frame
    void Update()
    {
       foreach(char alphabet in Input.inputString)
       {
            wordManager.TypingLetter(alphabet);
            //Debug.Log(alphabet);
       }
    }
}
