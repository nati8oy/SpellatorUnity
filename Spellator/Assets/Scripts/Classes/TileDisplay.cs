using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TileDisplay : MonoBehaviour
{
    public TileSkinSO tileSkin;


//public Sprite tileBackground;
//public Image tileBackground;
    public Color tileTextColour;
    public Color tileDisabledColour;
    public Color doubleLetterColour;
    public Color correctWordTextColour;

    public Color tripleLetterColour;

    public Color doubleTileColour;

    //public string skinName;
    public TextMeshProUGUI letterText;
    public TextMeshProUGUI pointsText;
    public ParticleSystem particles;
    

    // Start is called before the first frame update
    void Start()
    {
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

    }


}
