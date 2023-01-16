using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownTimer : MonoBehaviour
{
    private float RemainingDuration;
    public Image img;
    public GameObject Cooldown;
    private Color color;


    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        Cooldown = GameObject.FindObjectOfType<GameObject>();
        
        img.fillAmount = 0;
        // gameObject.SetActive(false);
        // wordManager = FindObjectOfType<WordManager>();

        // Begin(Duration);
    }

    // Update is called once per frame
    void Update()
    {
        // img.fillAmount -= 0.5f * Time.deltaTime;
        // Duration--;
        if(img.fillAmount <= 1)
        {
            img.fillAmount -= 0.5f * Time.deltaTime;
            img.color = Color.green;
            ChangeAlpha(1f);
        }

        if(img.fillAmount <= 0.5)
        {
            img.color = Color.yellow;
            ChangeAlpha(0.5f);
        }

        if(img.fillAmount <= 0.25)
        {
            img.color = Color.red;
            ChangeAlpha(0.25f);
        }
        
        if(img.fillAmount == 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Begin(float Duration)
    {
        img.fillAmount = 1;
        gameObject.SetActive(true);
        RemainingDuration = Duration;
    }

    private void ChangeAlpha(float value)
    {
        color = img.color;
        color.a = value;
        img.color = color;
    }

    private void OnEnd()
    {

    }
}
