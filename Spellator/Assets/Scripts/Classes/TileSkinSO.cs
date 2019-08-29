using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "New Skin",menuName = "Tile Skin")]
public class TileSkinSO : ScriptableObject
{


    public Sprite[] TileAgeSprites;
    public string nameOfSkin;
//    public Button mainButton;


    //dark skin
    [Header("Default")]
    public Sprite tileBG;
    public Color colourOfTileText;



}
