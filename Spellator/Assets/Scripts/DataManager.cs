using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public static DataManager Instance;

	private int goldAmount;
	private bool noAds = false;
    private bool darkSkinPurchased = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void AddGold(int amount)
	{
		goldAmount += amount;
		Debug.Log("Gold: " + goldAmount);
	}
	public void RemoveAds()
	{
		noAds = true;
		Debug.Log("Ads off: " + noAds);
	}

    public void BuyDarkSkin()
    {
        darkSkinPurchased = true;
        Debug.Log("Dark Skin bought = " + darkSkinPurchased);
    }


}
