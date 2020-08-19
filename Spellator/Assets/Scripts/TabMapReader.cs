using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TabMapReader : MonoBehaviour
{
   // public TabMap tabmap;

    public GameObject tab1;
    public GameObject tab2;
    public GameObject tab3;
    public GameObject tab4;
    public AudioSO audioObject;
    public TextMeshProUGUI goldAmount;
    public ConfigSO configObject;
    public GameObject goldObject;
    public Color inactiveTabColour;
    public Color activeTabColour;

    public Image statsTabIcon;
    public Image achievementTabIcon;
    public Image shopTabIcon;


    public GameObject mainCamera;

    private void Start()
    {
        //define the colour of the icons
        inactiveTabColour = new Color(244, 205, 54, 0.4f); 
        activeTabColour = new Color(244, 205, 54, 1f);

        //set the icons to the right colours on start up
        statsTabIcon.color = activeTabColour;
        achievementTabIcon.color = inactiveTabColour;
        shopTabIcon.color = inactiveTabColour;


    }
    //public GameObject activeTab;
    // Start is called before the first frame update
    private void Update()
    {
        goldAmount.text = configObject.totalGoldAmount.ToString();

    }

    public void ResetCamersPosition()
    {
        iTween.MoveTo(mainCamera, iTween.Hash("x", 320, "y", 568, "time", 1f));

    }


    public void TabSelector(string tabName)
    {
        //AudioManager.Instance.PlayAudio(audioObject.sfxUserInterface[0]);

        

        switch (tabName)
        {




            case "stats":
                //Debug.Log("word list");
                goldObject.SetActive(false);

                tab1.SetActive(false);
                tab2.SetActive(true);
                tab3.SetActive(false);
                tab4.SetActive(false);

                statsTabIcon.color = activeTabColour;
                achievementTabIcon.color = inactiveTabColour;
                shopTabIcon.color = inactiveTabColour;
                //iTween.MoveTo(mainCamera, iTween.Hash("x", 960, "time", 1f));


                break;
            case "achievements":
                goldObject.SetActive(false);

                //Debug.Log("achievements");
                tab1.SetActive(false);
                tab2.SetActive(false);
                tab3.SetActive(true);
                tab4.SetActive(false);


                statsTabIcon.color = inactiveTabColour;
                achievementTabIcon.color = activeTabColour;
                shopTabIcon.color = inactiveTabColour;
                break;
            case "shop":
                //Debug.Log("settings");
                goldObject.SetActive(true);

                tab1.SetActive(false);
                tab2.SetActive(false);
                tab3.SetActive(false);
                tab4.SetActive(true);

                statsTabIcon.color = inactiveTabColour;
                achievementTabIcon.color = inactiveTabColour;
                shopTabIcon.color = activeTabColour;
                break;
        }


    }
}
