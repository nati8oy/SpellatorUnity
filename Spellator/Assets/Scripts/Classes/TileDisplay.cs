using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TileDisplay : MonoBehaviour
{
    public TileSkinSO tileSkin;


//public Sprite tileBackground;
public Image tileBackground;
    public Color tileTextColour;
    public Color tileDisabledColour;
    //public string skinName;
    public TextMeshProUGUI letterText;
    public TextMeshProUGUI pointsText;
    public ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        tileDisabledColour = tileSkin.colourOfInactiveText;
        tileBackground.sprite = tileSkin.tileBG;
        tileTextColour = tileSkin.colourOfTileText;
        letterText.color = tileTextColour;
        pointsText.color = tileTextColour;
        particles = tileSkin.particles;

    }


}
