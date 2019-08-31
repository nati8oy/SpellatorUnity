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
    public Sprite tileBG;
    public Color colourOfTileText;
    public Color colourOfInactiveText;
    public ParticleSystem particles;





}
