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
    public GameState currentGameState;
    public int skinID;
    


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
        shopObject.currentSkin = skinID;

//        currentGameState.premiumCurrency -= shopArray[skinID].itemPrice;
  //      Debug.Log("premium currency remaining"  + currentGameState.premiumCurrency);

    }


}
