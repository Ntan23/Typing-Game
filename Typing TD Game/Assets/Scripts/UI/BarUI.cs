using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarUI : MonoBehaviour
{
    public Image moneyBarImg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMoneyBar()
	{
		moneyBarImg.fillAmount = PlayerStats.moneyBar/5;
		
		if(moneyBarImg.fillAmount > 0.5f)
        {
            moneyBarImg.color = Color.green;
        }
        else if(moneyBarImg.fillAmount <= 0.5f && moneyBarImg.fillAmount > 0.2f)
        {
            moneyBarImg.color = Color.yellow;
        }
        else if(moneyBarImg.fillAmount <= 0.2f)
        {
            moneyBarImg.color = Color.red;
        }

        if(moneyBarImg.fillAmount == 1)
        {
            StartCoroutine(resetBar());
        }
	}

    IEnumerator resetBar()
    {
        yield return new WaitForSeconds(0.2f);
        moneyBarImg.fillAmount = 0;
    }
}
