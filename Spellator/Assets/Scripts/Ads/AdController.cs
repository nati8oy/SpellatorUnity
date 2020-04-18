using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.Advertisements;

public class AdController : MonoBehaviour
{
    private string store_id = "3243070";
    private string interstitial_ad = "Interstitial";
    public ShowAdPlacementContent ad;

    public static AdController Instance;


    //this is the singleton code to ensure there's not more than one instance running
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    [System.Obsolete]
    void Start()
    {
        //change to false on proper release of game
        Monetization.Initialize(store_id, true);
    }

    [System.Obsolete]
    public void RunInterstitial()
    {
        //is the video ad ready?
        if (Monetization.IsReady(interstitial_ad))
            //if true

            ad = Monetization.GetPlacementContent(interstitial_ad) as ShowAdPlacementContent;
        if (ad != null)
        {
            ad.Show();
        }
    }
}
