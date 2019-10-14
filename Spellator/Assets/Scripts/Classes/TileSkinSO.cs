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


    [Header("Default")]
    //public Sprite tileBG;
    public Color colourOfTileText;
    public Color colourOfInactiveText;
    public Color correctWordTextColour;
    public ParticleSystem particles;

    [Header("Double Tile Colours")]
    public Color doubleLetterColour;
    public Color doubleTileColour;

    [Header("Triple Tile Colours")]
    public Color tripleLetterColour;
   public Color tripleTileColour;


}
