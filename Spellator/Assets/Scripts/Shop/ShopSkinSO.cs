using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Shop Skin", menuName = "New Skin")]


public class ShopSkinSO : ScriptableObject
{
    //public ShopSO[] shopSOArray;

	public int itemPrice;
	public string itemName;
	public Sprite itemImage;
}
