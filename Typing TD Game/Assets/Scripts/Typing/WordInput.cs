using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour
{
    public WordManager wordManager;

    // Update is called once per frame
    void Update()
    {
       if(GameManager.instance.gameEnded == false)
       {
            foreach(char alphabet in Input.inputString)
            {
                wordManager.TypingLetter(char.ToLower(alphabet));
            }
       }
    }
}
