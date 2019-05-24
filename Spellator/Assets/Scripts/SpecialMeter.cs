using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMeter : MonoBehaviour
{
    private SpecialMeterClass initClass;
    private GameObject bar;
    private Vector3 barSize;
    
    // Start is called before the first frame update
    void Start()
    {
        initClass = new SpecialMeterClass();
        bar = GameObject.Find("Dynamic Bar");

        bar.transform.localScale = new Vector3(0, bar.transform.localScale.y);

    }

    // Update is called once per frame
    void Update()
    {
        bar.transform.localScale = new Vector3(SpecialMeterClass.meterPercent, bar.transform.localScale.y);


       // initClass.IncreaseMeter(0.01f);
    }

}
