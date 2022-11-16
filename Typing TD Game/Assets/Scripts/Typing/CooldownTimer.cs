using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownTimer : MonoBehaviour
{
    public int Duration = 3;
    private int RemainingDuration;
    public Image img;
    public GameObject Cooldown;

    // private WordManager wordManager;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        Cooldown = GameObject.FindObjectOfType<GameObject>();
        Cooldown.SetActive(false);
        // wordManager = FindObjectOfType<WordManager>();

        Begin(Duration);
    }

    // Update is called once per frame
    void Update()
    {
        img.fillAmount -= 0.5f * Time.deltaTime;
        // Duration--;
    }

    public void Begin(int Duration)
    {
        RemainingDuration = Duration;
        gameObject.SetActive(true);
    }

    private void OnEnd()
    {

    }
}
