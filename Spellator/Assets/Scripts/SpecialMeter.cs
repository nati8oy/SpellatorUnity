using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialMeter : MonoBehaviour
{
    private SpecialMeterClass initClass;
    private GameObject bar;
    private Vector3 barSize;
    private ParticleSystem starParticles;


    // Start is called before the first frame update
    void Start()
    {
        starParticles = GameObject.Find("Star Particles").GetComponent<ParticleSystem>();
        starParticles.Stop();
        initClass = new SpecialMeterClass();
        bar = GameObject.Find("Special Bar");

        bar.transform.localScale = new Vector3(0, bar.transform.localScale.y);

    }

    // Update is called once per frame
    void Update()
    {


        if (SpecialMeterClass.meterPercent < 1)
        {
            bar.transform.localScale = new Vector3(SpecialMeterClass.meterPercent, bar.transform.localScale.y);

        }

        if(SpecialMeterClass.meterPercent >= 1)
        {
            SetToZero();
        }

    }

    private void SetToZero()
    {
        var specialButton = GameObject.Find("SpecialButton").GetComponent<Button>();
        specialButton.interactable = true;

        iTween.ScaleTo(bar, new Vector3(0, bar.transform.localScale.y), 0.2f);
    }


    /*
    public void IEnumerator ()
    {
        while (bar.GetComponent<Image>().color != Color.red)
        {
            bar.GetComponent<Image>().color = Color.yellow;
        }
        yield return new WaitForSeconds(0.2f);

    }*/

}
