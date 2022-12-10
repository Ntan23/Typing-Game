using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Translation : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private GameObject translateContainer;
    // private GameObject goTranslation;

    [SerializeField]
    private Animator anim;

    public bool isshow;

    // Start is called before the first frame update
    void Start()
    {
        // goTranslation = FindObjectOfType<GameObject>();
        text.text = "";
        anim=GameObject.FindGameObjectWithTag("transcontainer").GetComponent<Animator>();
    }

    public void showTranslation(string word)
    {
        isshow = true;
        // Debug Purpose isshow
        // Debug.Log(isshow);
        text.text = word;
    }

    // Update is called once per frame
    void Update()
    {
        if(isshow)
        {
            translateContainer.SetActive(true);
        }
        else if(!isshow)
        {
            translateContainer.SetActive(false);
        } 
    }

}
