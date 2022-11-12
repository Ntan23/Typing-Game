using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    Text text;
    public static bool needUpdate = true;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(!needUpdate)
        {
            return;
        }
        else if(needUpdate)
        {
            text.text = "$" + PlayerStats.money.ToString();
            needUpdate = false;
        }
    }
}
