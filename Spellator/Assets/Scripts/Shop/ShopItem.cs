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


    private void Start()
    {

        shopArray = shopObject.shopSkinArray;

        for (int i = 0; i < 8; i++)
        {
            itemImage.sprite = shopArray[i].itemImage;
            itemPriceText.text = shopArray[i].itemPrice.ToString();
            itemNameText.text = shopArray[i].itemName;
        }
    }


      

}
