using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShakeDamage : MonoBehaviour
{
    // Start is called before the first frame update
    private float duration = 0.5f;
    private Image dmgIndicator;

    public bool isDmged;

    Color dmgcolor;

    public AnimationCurve curve;
    void Start()
    {
       dmgIndicator = GameObject.FindGameObjectWithTag("Indicator").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dmgIndicator.color.a > 0)
        {
            IndicatorFadeout();
        }

        if(!isDmged)
        {
            return;
        }

        if(isDmged)
        {
            StartCoroutine(Shake());
            getDmged();
            isDmged = false;
        }
    }

    IEnumerator Shake()
    {
        Vector3 startpos = transform.localPosition;
        float currenttime = 0f;

        while(currenttime < duration)
        {
            startpos = transform.localPosition;
            currenttime +=Time.deltaTime;
            float strength = curve.Evaluate(currenttime / duration);
            transform.localPosition = startpos + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.localPosition = startpos;
    }

    public void getDmged()
    {
        dmgcolor = dmgIndicator.color;
        dmgcolor.a = 0.8f;

        dmgIndicator.color = dmgcolor;
    }

    public void IndicatorFadeout()
    {
        dmgcolor = dmgIndicator.color;
        dmgcolor.a -= 0.02f;
        dmgIndicator.color = dmgcolor;
    }
}
