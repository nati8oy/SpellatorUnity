using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public enum ItemType{
        Gold50,
        Gold100,
        Gold250,
        Gold500,
        Gold1000,
        Gold2000,
        NoAds
    }


    public ItemType itemType;
    public Text priceText;
    private string defaultText;

    private void Start()
    {

        // defaultText = priceText.text;
        StartCoroutine(LoadPriceRoutine());
    }

    public void ClickBuy()
    {
        switch (itemType)
        {
            case ItemType.Gold50:
                IAPManager.Instance.Buy50Gold();
                break;
            case ItemType.Gold100:
                IAPManager.Instance.Buy100Gold();
                break;
            case ItemType.Gold250:
                IAPManager.Instance.Buy250Gold();
                break;
            case ItemType.Gold500:
                IAPManager.Instance.Buy500Gold();
                break;
            case ItemType.Gold1000:
                IAPManager.Instance.Buy1000Gold();
                break;
            case ItemType.Gold2000:
                IAPManager.Instance.Buy2000Gold();
                break;
            case ItemType.NoAds:
                IAPManager.Instance.BuyNoAds();
                break;
      
        }
    }

    private IEnumerator LoadPriceRoutine()
    {
        while (!IAPManager.Instance.IsInitialized())
            yield return null;
        string loadedPrice = "";


        switch (itemType)
        {
            case ItemType.Gold50:
                loadedPrice = IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.GOLD_50);
                break;
            case ItemType.Gold100:
                loadedPrice = IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.GOLD_100);
                break;
            case ItemType.Gold250:
                loadedPrice = IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.GOLD_250);
                break;
            case ItemType.Gold500:
                loadedPrice = IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.GOLD_500);
                break;
            case ItemType.Gold1000:
                loadedPrice = IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.GOLD_1000);
                break;
            case ItemType.Gold2000:
                loadedPrice = IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.GOLD_2000);
                break;
            case ItemType.NoAds:
                loadedPrice = IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.NO_ADS);
                break;

           

        }

        //priceText.text = defaultText + " " + loadedPrice; 
    }

}
