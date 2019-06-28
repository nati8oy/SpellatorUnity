using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialMeter : MonoBehaviour
{
    private SpecialMeterClass specialMeter;
    private GameObject bar;



    // Start is called before the first frame update
    void Start()
    {

        specialMeter = new SpecialMeterClass();
        bar = GameObject.Find("Level 1");

        bar.transform.localScale = new Vector3(1, bar.transform.localScale.y);

    }

    // Update is called once per frame
    void Update()
    {

        bar.transform.localScale = new Vector3(SpecialMeterClass.meterPercent, bar.transform.localScale.y);
       // iTween.ScaleTo(bar, iTween.Hash("x", new Vector3(SpecialMeterClass.meterPercent, bar.transform.localScale.y), "time", "0.25f"));

        //iTween.MoveBy(gameObject, iTween.Hash("y", randomDistance, "time", randomTime, "easetype", "easeInOutExpo", "delay", randomTime, "oncomplete", "SetTileInactive"));


    }

     

    private void SetToZero()
    {
//        var specialButton = GameObject.Find("SpecialButton").GetComponent<Button>();
  //      specialButton.interactable = true;

     //   iTween.ScaleTo(bar, new Vector3(0, bar.transform.localScale.y), 0.2f);
      GameManager.Instance.GameOverMethod();
    }

}
