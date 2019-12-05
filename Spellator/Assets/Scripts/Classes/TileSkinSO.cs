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


    [Header("Dark")]
    public Sprite[] dark_tile_ages;
    public string dark_tile_name;
    public Color dark_tile_text_colour;
    public Color dark_tile_text_inactive;
    public Color dark_tile_double_colour;
    public Color dark_tile_triple_colour;

    [Header("Wood")]
    public Sprite[] wood_tile_ages;
    public string wood_tile_name;
    public Color wood_tile_text_colour;
    public Color wood_tile_text_inactive;
    public Color wood_tile_double_colour;
    public Color wood_tile_triple_colour;


}
