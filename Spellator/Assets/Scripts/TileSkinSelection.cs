using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileSkinSelection : MonoBehaviour
{
    public TileSkinDefinition skinSelectionObject;
    public SkinSelectorSO currentSkin;

    public Color tileTextColour;
    public Color tileDisabledColour;
    public Color doubleLetterColour;
    public Color correctWordTextColour;
    public Color tripleLetterColour;
    public Sprite[] tileAgeSprites;
    public TileSkinDefinition[] skinArray;


    public TextMeshProUGUI letterText;
    public TextMeshProUGUI pointsText;
    public ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        skinArray = currentSkin.skinList;

        skinSelectionObject = currentSkin.skinList[0];

        tileTextColour = skinSelectionObject.tileTextColour;
        tileDisabledColour =skinSelectionObject.tileDisabledColour;
        doubleLetterColour =skinSelectionObject.doubleLetterColour;
        correctWordTextColour= skinSelectionObject.correctWordTextColour;
        tripleLetterColour = skinSelectionObject.tripleLetterColour;
        tileAgeSprites = skinSelectionObject.tileAgeSprites;
}

    
}
