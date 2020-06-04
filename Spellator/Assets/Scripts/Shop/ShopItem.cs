using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{
    public ShopSO shopObject;
    public ShopSkinSO[] shopArray;
    public TextMeshProUGUI itemPriceText;
    public TextMeshProUGUI itemNameText;
    public Image itemImage;
    public GameObject gameStateObject;
    public int skinID;
    public GameObject purchaseObject;
    public int goldAmount;
    public ConfigSO configData;

    [Header("Button Items")]
    public Button buyButton;
    public TextMeshProUGUI goldText;
    public Image coinSprite;
    public Text buttonText;

    public bool productPurchased;


    //Adds all of the content to the shop that is required for each of the tile types (shop items)
    public void AddContent(int arrayNumber)
    {
        shopArray = shopObject.shopSkinArray;

        itemImage.sprite = shopArray[arrayNumber].itemImage;
        itemPriceText.text = shopArray[arrayNumber].itemPrice.ToString();
        itemNameText.text = shopArray[arrayNumber].itemName;

        skinID = arrayNumber;

        //checks in the configData object if the skin has been purchased already
        if (configData.skinsPurchased.Contains(skinID))
        {
            buttonText.text = "select";
            
            //buyButton.interactable = false;
            Debug.Log("you already bought this skin " + skinID);

        } 

    }

    //this is the function to select the new skin.
    public void UpdateSkin()
    {

            goldAmount = configData.totalGoldAmount;
            //check if the price is less than the amount of currency available
            //and check if the item has already been purchased or not
            if (shopArray[skinID].itemPrice < goldAmount)
            {

                //set the current skin object to SkinID so that it can be accessed for the prices below
                shopObject.currentSkin = skinID;

                //add the purchased animation
                Instantiate(purchaseObject, Camera.main.transform);

                //reduce the total currency by the item price. 
                goldAmount -= shopArray[skinID].itemPrice;
                Debug.Log("skin bought for " + shopArray[skinID].itemPrice + ". Gold remaining: " + goldAmount);

                //set the gold amount in the SO to be the correct amount
                configData.totalGoldAmount = goldAmount;

                //add the skin to the ones that have been purchased List.
                configData.skinsPurchased.Add(skinID);
                GameEvents.OnSaveInitiated();

                //Debug.Log(configData.skinsPurchased.Count);

                //save the game
                // GameState.Instance.SaveGameData();

                if (AudioManager.Instance)
                {
                    AudioManager.Instance.PlayAudio(AudioManager.Instance.sfxUserInterface[1]);

                }

            }

            else
            {
                Debug.Log("not enough money");

            }


    }


}
