using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Translation : MonoBehaviour
{
    private TextMeshProUGUI text;

    [SerializeField]
    private GameObject goTranslation;

    public bool isshow;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        goTranslation = FindObjectOfType<GameObject>();
        text.text = "";
    }

    public void showTranslation(string word)
    {
        isshow = true;
        // Debug Purpose isshow
        // Debug.Log(isshow);
        text.text = "Indo : "+word;
    }

    // Update is called once per frame
    void Update()
    {
        if(isshow) gameObject.SetActive(true);

        if(!isshow) gameObject.SetActive(false);
        
    }

}
