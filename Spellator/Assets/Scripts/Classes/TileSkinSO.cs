using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Skin",menuName = "Tile Skin")]
public class TileSkinSO : ScriptableObject
{
    public string nameOfSkin;
//    public Button mainButton;


    //dark skin
    [Header("Default")]
    public Sprite tileBG;
    public Color colourOfTileText;

    // Light skin
    [Header("Dark Skin")]
    public Sprite lightTileBG;

    [Header("Light Skin")]
    public Sprite darkTileBG;

}
