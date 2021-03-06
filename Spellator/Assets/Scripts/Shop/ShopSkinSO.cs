﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Shop Skin", menuName = "New Skin")]


public class ShopSkinSO : ScriptableObject
{
	public int itemPrice;
	public string itemName;
	public Sprite itemImage;
    public string skinID;
    public int skinIDNumber;
}
