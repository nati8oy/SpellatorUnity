using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TileDisplay : MonoBehaviour
{
    public TileSkinSO tileSkin;

    public enum TileSkinType{ original, dark, wood};

    public TileSkinType tileSkinType;


//public Sprite tileBackground;
//public Image tileBackground;
    [HideInInspector]
    public Color tileTextColour;
    [HideInInspector]
    public Color tileDisabledColour;
    [HideInInspector]
    public Color doubleLetterColour;
    [HideInInspector]
    public Color correctWordTextColour;
    [HideInInspector]
    public Color tripleLetterColour;
    [HideInInspector]
    public Color doubleTileColour;

    [HideInInspector]
    public Sprite[] tileAgeSprites;

    //public Color tileTextColour;

    //public string skinName;
    public TextMeshProUGUI letterText;
    public TextMeshProUGUI pointsText;
    public ParticleSystem particles;
    

    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("there are " + tileSkin.dark_tile_ages.Length + " tile age sprites");

        switch (tileSkinType)
        {
            case TileSkinType.original:

            tileAgeSprites = tileSkin.TileAgeSprites;

            correctWordTextColour = tileSkin.correctWordTextColour;
            tileDisabledColour = tileSkin.colourOfInactiveText;
            //tileBackground.sprite = tileSkin.tileBG;
            tileTextColour = tileSkin.colourOfTileText;
            letterText.color = tileTextColour;
            pointsText.color = tileTextColour;
            particles = tileSkin.particles;
            doubleLetterColour = tileSkin.doubleLetterColour;
            tripleLetterColour = tileSkin.tripleLetterColour;

            //set the double tile background colour to whatever is in the scriptable object
            doubleTileColour = tileSkin.doubleTileColour;

            //set the double tile background colour to whatever is in the scriptable object
            tripleLetterColour = tileSkin.tripleLetterColour;
            break;


            //if the enum is set to dark, use this skin
            case TileSkinType.dark:

                tileAgeSprites = tileSkin.dark_tile_ages;

                tileDisabledColour = tileSkin.dark_tile_text_inactive;
                tileTextColour = tileSkin.dark_tile_text_colour;
                letterText.color = tileSkin.dark_tile_text_colour;
                pointsText.color = tileSkin.dark_tile_text_colour;
                doubleLetterColour = tileSkin.dark_tile_double_colour;
                tripleLetterColour = tileSkin.dark_tile_triple_colour;

                break;

            //if the enum is set to dark, use this skin
            case TileSkinType.wood:

                tileAgeSprites = tileSkin.wood_tile_ages;

                tileDisabledColour = tileSkin.wood_tile_text_inactive;
                tileTextColour = tileSkin.wood_tile_text_colour;
                letterText.color = tileSkin.wood_tile_text_colour;
                pointsText.color = tileSkin.wood_tile_text_colour;
                doubleLetterColour = tileSkin.wood_tile_double_colour;
                tripleLetterColour = tileSkin.wood_tile_triple_colour;

                break;
        }

        //Debug.Log("tile skin type: " + tileSkinType);




    }


}
