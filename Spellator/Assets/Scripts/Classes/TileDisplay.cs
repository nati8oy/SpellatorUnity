﻿using System.Collections;
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
    //public string skinName;
    public TextMeshProUGUI letterText;
    public TextMeshProUGUI pointsText;

    // Start is called before the first frame update
    void Start()
    {
        tileBackground.sprite = tileSkin.tileBG;
        tileTextColour = tileSkin.colourOfTileText;
        letterText.color = tileTextColour;
        pointsText.color = tileTextColour;

    }


}
