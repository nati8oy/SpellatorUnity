﻿using System.Collections;
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


    private void Start()
    {
        //purchaseObject = GameObject.Find("purchase confirmation");
        
    }


    //Adds all of the content to the shop that is required for each of the tile types (shop items)
    public void AddContent(int arrayNumber)
    {
        shopArray = shopObject.shopSkinArray;

        itemImage.sprite = shopArray[arrayNumber].itemImage;
        itemPriceText.text = shopArray[arrayNumber].itemPrice.ToString();
        itemNameText.text = shopArray[arrayNumber].itemName;

        skinID = arrayNumber;
    }

    //this is the function to select the new skin.
    public void UpdateSkin()
    {
       

        //check if the GameState object exists
        if (GameObject.Find("GameState"))
        {
            goldAmount = configData.totalGoldAmount;
            //check if the price is less than the amount of currency available
            if (shopArray[skinID].itemPrice < goldAmount)
            {

                //set the current skin object to SkinID so that it can be accessed for the prices below
                shopObject.currentSkin = skinID;

                //add the purchased animation
                Instantiate(purchaseObject, Camera.main.transform);

                //reduce the total currency by the item price. 
                goldAmount -= shopArray[skinID].itemPrice;
                Debug.Log("skin bought for " + shopArray[skinID].itemPrice + ". Gold remaining: " + goldAmount);

                configData.totalGoldAmount = goldAmount;
                GameState.Instance.SaveGameData();
            }
            else
            {
                Debug.Log("not enough money");
            }

        }
      //GameManager.Instance.purchaseConfirm.SetActive(true);
        // Debug.Log("current skin ID: " + shopObject.currentSkin);

    }


}
