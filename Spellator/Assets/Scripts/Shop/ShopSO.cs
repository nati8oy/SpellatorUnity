using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Shop Data", menuName = "Shop")]

[System.Serializable]

public class ShopSO : ScriptableObject
{
    public int currentSkin;
    public ShopSkinSO[] shopSkinArray;

}
