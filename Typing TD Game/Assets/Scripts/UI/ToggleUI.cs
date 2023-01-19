using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleUI : MonoBehaviour
{
    public Image image_toggleoff;
    public Image image_toggleon;


    // Start is called before the first frame update
    void Start()
    {
        int index = transform.GetSiblingIndex();
        // Debug.Log(index);
        image_toggleoff = transform.parent.GetChild(index + 1).GetComponent<Image>();
        image_toggleon = transform.parent.GetChild(index + 2).GetComponent<Image>();
        image_toggleon.gameObject.SetActive(true);
        image_toggleoff.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Toggle_ON()
    {
        image_toggleoff.gameObject.SetActive(false);
        image_toggleon.gameObject.SetActive(true);
        
    }

    public void Toggle_OFF()
    {
        image_toggleon.gameObject.SetActive(false);
        image_toggleoff.gameObject.SetActive(true);
    }
}
